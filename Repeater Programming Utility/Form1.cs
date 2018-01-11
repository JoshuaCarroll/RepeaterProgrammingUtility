using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO.Ports;
using System.Speech.Synthesis;
using System.Threading;

namespace Repeater_Programming_Utility
{
    public partial class Form1 : Form
    {
        public SerialPort port;
        private Thread voxThread;
        private Color transmittingColor = Color.Aquamarine;
        private int PauseBeforeAfterKeyup = 500;
        private int ExtraPauseForVox = 1000;

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // Get and list the serial ports on this system
            List<string> s = new List<string>(SerialPort.GetPortNames());
            s.Add("VOX");
            s.Sort();
            foreach (string item in s)
            {
                cbComPort.Items.Add(item);
            }

            if (cbComPort.Items.Count > 0)
            {
                cbComPort.SelectedIndex = cbComPort.Items.Count - 1;
            }

            port = new SerialPort(cbComPort.Text);
            port.DataBits = 8;
            port.Parity = Parity.None;
            port.StopBits = StopBits.One;
            port.Handshake = Handshake.RequestToSend;
            controlPtt(port, PttState.Closed);

            txtCallsign.Text = Properties.Settings.Default.CallSign;
        }
        private void NumericTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Char.IsDigit(e.KeyChar)) || (Char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }
        enum PttState
        {
            Open,
            Closed
        }
        private void controlPtt(SerialPort port, PttState newState)
        {
            switch (newState)
            {
                case PttState.Open:
                    if (cbComPort.Text == "VOX")
                    {
                        ThreadStart childref = new ThreadStart(CallToVoxThread);
                        voxThread = new Thread(childref);
                        voxThread.Start();

                        toolStripStatusLabel1.Text = "VOX tone active.";

                        Pause(ExtraPauseForVox);
                    }
                    else
                    {
                        if (port.IsOpen)
                        {
                            port.Close();
                            Thread.Sleep(int.Parse(txtPauseBetweenLines.Text));
                        }

                        try
                        {
                            port.Open();
                            toolStripStatusLabel1.Text = "PTT open.";
                        }
                        catch (Exception ex)
                        {
                            toolStripStatusLabel1.Text = "Error opening PTT: " + ex.Message;
                        }
                    }
                    
                    statusStrip1.BackColor = transmittingColor;
                    break;
            case PttState.Closed:
                    if (cbComPort.Text == "VOX")
                    {
                        if (voxThread != null)
                        {
                            voxThread.Abort();
                        }

                        toolStripStatusLabel1.Text = "";
                        Pause(ExtraPauseForVox);
                    }
                    else
                    {
                        if (port.IsOpen)
                        {
                            try
                            {
                                port.Close();
                                toolStripStatusLabel1.Text = "PTT closed.";
                            }
                            catch (Exception ex)
                            {
                                toolStripStatusLabel1.Text = "Error closing PTT: " + ex.Message;
                            }
                        }
                    }
                    
                    statusStrip1.BackColor = SystemColors.Control;
                    break;
                default:
                    break;
            }
        }
        private void btnSend_Click(object sender, EventArgs e)
        {
            string CommentCharacter = txtCommentCharacter.Text;

            if (cbComPort.Text == string.Empty)
            {
                MessageBox.Show("Please select a COM port first.");
            }
            else
            {
                string strDtmf = txtDtmfTones.Text;

                for (int i = 0; i < strDtmf.Length; i++)
                {
                    if (strDtmf.Contains(CommentCharacter))
                    {
                        int posComment = strDtmf.IndexOf(CommentCharacter);
                        int posEndLine = strDtmf.IndexOf("\r\n", posComment);
                        if (posComment > -1)
                        {
                            if (posEndLine > -1)
                            {
                                strDtmf = strDtmf.Remove(posComment, posEndLine - posComment);
                            }
                            else
                            {
                                strDtmf = strDtmf.Remove(posComment);
                            }
                        }
                    }
                    else
                    {
                        break;
                    }
                }

                strDtmf = strDtmf.Replace(" ", "").Replace("\t","");
                string[] separator = { "\r\n" };
                string[] lines = strDtmf.Split(separator, StringSplitOptions.RemoveEmptyEntries);

                int PauseBetweenTones = int.Parse(txtPauseBetweenDigits.Text);
                int LengthOfEachTone = int.Parse(txtLengthOfEachTone.Text);
                int PauseBetweenLines = int.Parse(txtPauseBetweenLines.Text);
                int sampleRate = 8000;
                int bitRate = 16;
                BasicTelephony b = new BasicTelephony();

                string CallSign = toLetters(txtCallsign.Text);

                if (cbIdBefore.Checked)
                {
                    using (SpeechSynthesizer synth = new SpeechSynthesizer())
                    {
                        controlPtt(port, PttState.Open);
                        Pause(PauseBeforeAfterKeyup);
                        synth.Speak("This is " + CallSign + " on tones, sending " + lines.Length.ToString() + " lines.");
                        Pause(PauseBeforeAfterKeyup);
                        controlPtt(port, PttState.Closed);
                        Pause(PauseBetweenLines);
                    }
                }

                for (int i = 0; i < lines.Length; i++)
                {
                    // Move the cursor to show progress
                    int selectStart = txtDtmfTones.GetFirstCharIndexFromLine(i);
                    int selectEnd = txtDtmfTones.Text.IndexOf(Environment.NewLine, selectStart);
                    txtDtmfTones.Select(selectStart, selectEnd);

                    string tones = lines[i];
                    if (tones != string.Empty)
                    {
                        System.IO.MemoryStream dtmfStream = b.GenerateDTMF(tones, PauseBetweenTones, LengthOfEachTone, sampleRate, bitRate);
                        byte[] dtmfWav = b.WriteWAVFile(sampleRate, bitRate, 1, dtmfStream);

                        System.IO.MemoryStream wavStream = new System.IO.MemoryStream();
                        wavStream.Write(dtmfWav, 0, dtmfWav.Length);

                        List<byte> soundBytes = new List<byte>(dtmfWav);

                        //create media player loading the first half of the sound file
                        MediaPlayer mPlayer = new MediaPlayer(soundBytes.ToArray());

                        controlPtt(port, PttState.Open);
                        Pause(PauseBeforeAfterKeyup);

                        // play line number
                        SpeechSynthesizer synth3 = new SpeechSynthesizer();
                        synth3.Speak("Line " + i);
                        synth3.Dispose();

                        //begin playing the file
                        mPlayer.Play();
                        Pause(((LengthOfEachTone + PauseBetweenTones) * tones.Length) + PauseBeforeAfterKeyup);

                        controlPtt(port, PttState.Closed);

                        Pause(PauseBetweenLines);
                    }
                }

                if (cbIdAfter.Checked)
                {
                    using (SpeechSynthesizer synth2 = new SpeechSynthesizer())
                    {
                        controlPtt(port, PttState.Open);
                        Pause(PauseBeforeAfterKeyup);
                        synth2.Speak("Via the N 5 J L C repeater programming utility, " + CallSign + " clear.");
                        Pause(PauseBeforeAfterKeyup);
                        controlPtt(port, PttState.Closed);
                    }
                }

                txtDtmfTones.Select(txtDtmfTones.Text.Length, txtDtmfTones.Text.Length);
            }
        }
        public void Pause(int Milliseconds)
        {
            DateTime continueTime = DateTime.Now.Add(new TimeSpan(0, 0, 0, 0, Milliseconds));
            while (continueTime > DateTime.Now)
            {
                Application.DoEvents();
            }
        }

        private string toPhonetics(string str)
        {
            string[] strArr = new string[str.Length];
            string strReturn = "";

            for (var i = 0; i < str.Length; i++)
            {
                string letter = str.Substring(i, 1);

                switch (letter.ToLower())
                {
                    case "a":
                        strArr[i] = "alpha";
                        break;
                    case "b":
                        strArr[i] = "bravo";
                        break;
                    case "c":
                        strArr[i] = "charlie";
                        break;
                    case "d":
                        strArr[i] = "delta";
                        break;
                    case "e":
                        strArr[i] = "echo";
                        break;
                    case "f":
                        strArr[i] = "foxtrot";
                        break;
                    case "g":
                        strArr[i] = "golf";
                        break;
                    case "h":
                        strArr[i] = "hotel";
                        break;
                    case "i":
                        strArr[i] = "india";
                        break;
                    case "j":
                        strArr[i] = "juliette";
                        break;
                    case "k":
                        strArr[i] = "kilo";
                        break;
                    case "l":
                        strArr[i] = "lee-mah";
                        break;
                    case "m":
                        strArr[i] = "mike";
                        break;
                    case "n":
                        strArr[i] = "november";
                        break;
                    case "o":
                        strArr[i] = "oscar";
                        break;
                    case "p":
                        strArr[i] = "papa";
                        break;
                    case "q":
                        strArr[i] = "quebec";
                        break;
                    case "r":
                        strArr[i] = "romeo";
                        break;
                    case "s":
                        strArr[i] = "sierra";
                        break;
                    case "t":
                        strArr[i] = "tango";
                        break;
                    case "u":
                        strArr[i] = "uniform";
                        break;
                    case "v":
                        strArr[i] = "victor";
                        break;
                    case "w":
                        strArr[i] = "whiskey";
                        break;
                    case "x":
                        strArr[i] = "x-ray";
                        break;
                    case "y":
                        strArr[i] = "yankee";
                        break;
                    case "z":
                        strArr[i] = "zulu";
                        break;
                    case "0":
                        strArr[i] = "zero";
                        break;
                    case "1":
                        strArr[i] = "one";
                        break;
                    case "2":
                        strArr[i] = "two";
                        break;
                    case "3":
                        strArr[i] = "three";
                        break;
                    case "4":
                        strArr[i] = "four";
                        break;
                    case "5":
                        strArr[i] = "five";
                        break;
                    case "6":
                        strArr[i] = "six";
                        break;
                    case "7":
                        strArr[i] = "seven";
                        break;
                    case "8":
                        strArr[i] = "eight";
                        break;
                    case "9":
                        strArr[i] = "nine";
                        break;
                    default:
                        strArr[i] = letter;
                        break;
                }
            }

            for (var i = 0; i < strArr.Length; i++)
            {
                strReturn += strArr[i] + " ";
            }

            return strReturn;
        }
        private string toLetters(string str)
        {
            string rtn = string.Empty;
            for (int i = 0; i < str.Length; i++)
            {
                rtn += str[i] + " ";
            }
            return rtn;
        }
        private void CallToVoxThread()
        {
            toneGenerator tg = new toneGenerator();
            int voxToneHertz = 100;
            tg.start(voxToneHertz);
        }

        private void btnLogon_Click(object sender, EventArgs e)
        {
            cbIdBefore.Checked = true;
            cbIdBefore.Checked = false;
            string originalValue = txtDtmfTones.Text;
            txtDtmfTones.Text = txtLogonCode.Text;
            btnSend_Click(sender, e);
            txtDtmfTones.Text = originalValue;
        }

        private void btnLogoff_Click(object sender, EventArgs e)
        {
            cbIdBefore.Checked = false;
            cbIdBefore.Checked = true;
            string originalValue = txtDtmfTones.Text;
            txtDtmfTones.Text = txtLogoffCode.Text;
            btnSend_Click(sender, e);
            txtDtmfTones.Text = originalValue;
        }
    }
}