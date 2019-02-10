using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO.Ports;
using System.Speech.Synthesis;
using System.Threading;
using System.Deployment.Application;

namespace Repeater_Programming_Utility
{
    public partial class Form1 : Form
    {
        public SerialPort port;
        private Thread voxThread;
        
        // Change these to application level settings
        private Color transmittingColor = Color.Aquamarine;
        private int PauseBeforeAfterKeyup = 500;
        private int ExtraPauseForVox = 2000;
		private bool isCancelling = false;

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
			if (ApplicationDeployment.IsNetworkDeployed)
			{
				this.Text += " v" + ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString(4);
			}

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

            // Load last user settings
            txtCallsign.Text = Properties.Settings.Default.callSign;
            cbComPort.Text = Properties.Settings.Default.comPort;
            txtPauseBetweenDigits.Text = Properties.Settings.Default.pauseBetweenDigits;
            txtPauseBetweenLines.Text = Properties.Settings.Default.pauseBetweenLines;
            txtLengthOfEachTone.Text = Properties.Settings.Default.lengthOfEachTone;
            txtCommentCharacter.Text = Properties.Settings.Default.commentCharacter;
            txtLogonCode.Text = Properties.Settings.Default.logonCode;
            txtLogoffCode.Text = Properties.Settings.Default.logoffCode;
            //TODO: assign to file open/save dialog = Properties.Settings.Default.fileOpenSaveLocation;
            chkIdBefore.Checked = Properties.Settings.Default.idBeforeTones;
            chkIdAfter.Checked = Properties.Settings.Default.idAfterTones;

            userToolStripMenuItem.Checked = Properties.Settings.Default.viewUser;
            settingsToolStripMenuItem_Click(userToolStripMenuItem, new EventArgs());
            toneToolStripMenuItem.Checked = Properties.Settings.Default.viewTone;
            settingsToolStripMenuItem_Click(toneToolStripMenuItem, new EventArgs());
            securityToolStripMenuItem.Checked = Properties.Settings.Default.viewSecurity;
            settingsToolStripMenuItem_Click(securityToolStripMenuItem, new EventArgs());

            if (Properties.Settings.Default.windowLocation == new Point(-1,-1))
            {
                this.CenterToScreen();
            }
            else
            {
                this.Location = Properties.Settings.Default.windowLocation;
            }
            this.WindowState = Properties.Settings.Default.windowState;

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
			isCancelling = false;
			transmitTones();
		}
		private int numberOfLines(string s)
		{
			string[] separator = { "\r\n" };
			string[] lines = s.Split(separator, StringSplitOptions.None);
			return lines.Length;
		}
		private void transmitTones()
		{
			string CommentCharacter = txtCommentCharacter.Text;

			if (cbComPort.Text == string.Empty)
			{
				MessageBox.Show("Please select a COM port first.");
				return;
			}

			int PauseBetweenTones = int.Parse(txtPauseBetweenDigits.Text);
			int LengthOfEachTone = int.Parse(txtLengthOfEachTone.Text);
			int PauseBetweenLines = int.Parse(txtPauseBetweenLines.Text);
			int sampleRate = 8000;
			int bitRate = 16;
			BasicTelephony b = new BasicTelephony();

			string CallSign = toLetters(txtCallsign.Text);
			int totalNumberOfLines = numberOfLines(txtDtmfTones.Text);

			if (chkIdBefore.Checked)
			{
				using (SpeechSynthesizer synth = new SpeechSynthesizer()) 
				{
					synth.Volume = 100;
					controlPtt(port, PttState.Open);
					Pause(PauseBeforeAfterKeyup);
					string statement = "This is " + CallSign + " on tones, sending " + totalNumberOfLines + " line";
					if (totalNumberOfLines > 1) { statement += "s"; }
					synth.Speak(statement);
					Pause(PauseBeforeAfterKeyup);
					controlPtt(port, PttState.Closed);
					Pause(PauseBetweenLines);
				}
			}

			txtDtmfTones.Focus();

			#region Loop through each line in txtDtmfTones
			int cursorPosition = 0;
			while (txtDtmfTones.Text.Length > cursorPosition)
			{
				if (isCancelling)
				{
					break;
				}

				string tones = "";
				int eolPosition = 0;
				int lineNumber = 0;

				eolPosition = txtDtmfTones.Text.IndexOf("\r\n", cursorPosition);
				lineNumber = numberOfLines(txtDtmfTones.Text.Substring(0, cursorPosition));
				if (eolPosition > -1)
				{
					tones = txtDtmfTones.Text.Substring(cursorPosition, eolPosition - cursorPosition);
				}
				else
				{
					eolPosition = txtDtmfTones.Text.Length;
					tones = txtDtmfTones.Text.Substring(cursorPosition);
				}

				// Ignore tabs and spaces, stop at comment character, ignore blank lines
				tones = tones.Replace("\t", "").Replace(" ", "");
				int commentPosition = tones.IndexOf(";");
				if (commentPosition > -1)
				{
					tones = tones.Substring(0, commentPosition);
				}
				tones = tones.Trim();

				if (tones != string.Empty)
				{
					// Highlight the line being sent
					txtDtmfTones.Select(cursorPosition, eolPosition - cursorPosition);

					tones = txtPrefaceCode.Text + tones;

					// Generate the tones on this line
					System.IO.MemoryStream dtmfStream = b.GenerateDTMF(tones, PauseBetweenTones, LengthOfEachTone, sampleRate, bitRate);
					byte[] dtmfWav = b.WriteWAVFile(sampleRate, bitRate, 1, dtmfStream);
					System.IO.MemoryStream wavStream = new System.IO.MemoryStream();
					wavStream.Write(dtmfWav, 0, dtmfWav.Length);
					List<byte> soundBytes = new List<byte>(dtmfWav);
					MediaPlayer mPlayer = new MediaPlayer(soundBytes.ToArray());

					controlPtt(port, PttState.Open);
					Pause(PauseBeforeAfterKeyup);

					// Announce every other line number
					if (lineNumber % 2 == 0)
					{
						using (SpeechSynthesizer synth = new SpeechSynthesizer())
						{
							synth.Volume = 100;
							synth.Speak("Line " + lineNumber);
							synth.Dispose();
						}
					}

					//begin playing the file
					mPlayer.Play();
					Pause((LengthOfEachTone * tones.Length) + (PauseBetweenTones * (tones.Length - 1)) + PauseBeforeAfterKeyup);

					controlPtt(port, PttState.Closed);
					Pause(PauseBetweenLines);
				}

				// Get ready for the next loop
				cursorPosition = eolPosition + 2; // Add two to account for carriage return and line feed
			}
			#endregion

			txtDtmfTones.Select(0, 0);

			if (chkIdAfter.Checked)
			{
				using (SpeechSynthesizer synth = new SpeechSynthesizer())
				{
					synth.Volume = 100;
					controlPtt(port, PttState.Open);
					Pause(PauseBeforeAfterKeyup);
					synth.Speak("Via the N 5 J L C repeater programming utility, " + CallSign + " clear.");
					Pause(PauseBeforeAfterKeyup);
					controlPtt(port, PttState.Closed);
				}
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
            bool chkBefore = chkIdBefore.Checked;
            bool chkAfter = chkIdAfter.Checked;
            string originalValue = txtDtmfTones.Text;

            chkIdBefore.Checked = true;
            chkIdAfter.Checked = false;
            txtDtmfTones.Text = txtLogonCode.Text;
            Application.DoEvents();

            btnSend_Click(sender, e);
            Application.DoEvents();

            txtDtmfTones.Text = originalValue;
            chkIdBefore.Checked = chkBefore;
            chkIdAfter.Checked = chkAfter;
            Application.DoEvents();
        }

        private void btnLogoff_Click(object sender, EventArgs e)
        {
            bool chkBefore = chkIdBefore.Checked;
            bool chkAfter = chkIdAfter.Checked;
            string originalValue = txtDtmfTones.Text;

            chkIdBefore.Checked = false;
            chkIdAfter.Checked = true;
            txtDtmfTones.Text = txtLogoffCode.Text;
            Application.DoEvents();

            btnSend_Click(sender, e);
            Application.DoEvents();

            txtDtmfTones.Text = originalValue;
            chkIdBefore.Checked = chkBefore;
            chkIdAfter.Checked = chkAfter;
            Application.DoEvents();
        }

        private void linkLabelCancel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
			isCancelling = true;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/JoshuaCarroll/RepeaterProgrammingUtility#user-content-n5jlc-repeater-programming-utility");
        }

        private void reportAProblemToolStripMenuItem_Click(object sender, EventArgs e)
        {
			string version = ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString(4);
			System.Diagnostics.Process.Start("https://github.com/JoshuaCarroll/RepeaterProgrammingUtility/issues/new?body=-%20What%20were%20you%20trying%20to%20do%3F%20%0D%0A%0D%0A%0D%0A-%20What%20happened%20instead%3F%0D%0A%0D%0A%0D%0A_____%0D%0AOS%3A%20Windows%0D%0ASoftware%20version%3A%20" + version + "&labels=bug");
        }

        private void provideASuggestionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/JoshuaCarroll/RepeaterProgrammingUtility/issues/new?labels=enhancement");
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem ts = (ToolStripMenuItem)sender;
            GroupBox gb = (GroupBox)this.Controls.Find(ts.Tag.ToString(), true)[0];
            
            gb.Visible = ts.Checked;
            layoutSettings();
        }

        private void layoutSettings()
        {
            int numVisible = 0;
            numVisible += (groupBoxUser.Visible) ? 1 : 0;
            numVisible += (groupBoxTone.Visible) ? 1 : 0;
            numVisible += (groupBoxSecurity.Visible) ? 1 : 0;

            List<GroupBox> boxes = new List<GroupBox>();
            boxes.Add(groupBoxUser);
            boxes.Add(groupBoxTone);
            boxes.Add(groupBoxSecurity);

            int posY = 29;
            for (int i = 0; i < boxes.Count; i++)
            {
                if (boxes[i].Visible)
                {
                    boxes[i].Top = posY;
                    posY += 66;
                }
            }

            groupBoxDtmf.Location = new Point(14, posY);
            groupBoxDtmf.Height = this.Height - groupBoxDtmf.Top - 99;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.callSign = txtCallsign.Text;
            Properties.Settings.Default.comPort = cbComPort.Text;
            Properties.Settings.Default.pauseBetweenDigits = txtPauseBetweenDigits.Text;
            Properties.Settings.Default.pauseBetweenLines = txtPauseBetweenLines.Text;
            Properties.Settings.Default.lengthOfEachTone = txtLengthOfEachTone.Text;
            Properties.Settings.Default.commentCharacter = txtCommentCharacter.Text;
            Properties.Settings.Default.logonCode = txtLogonCode.Text;
            Properties.Settings.Default.logoffCode = txtLogoffCode.Text;
            //TODO: assign from file open/save dialog = Properties.Settings.Default.fileOpenSaveLocation;
            Properties.Settings.Default.idBeforeTones = chkIdBefore.Checked;
            Properties.Settings.Default.idAfterTones = chkIdAfter.Checked;
            Properties.Settings.Default.viewUser = userToolStripMenuItem.Checked;
            Properties.Settings.Default.viewTone = toneToolStripMenuItem.Checked;
            Properties.Settings.Default.viewSecurity = securityToolStripMenuItem.Checked;
            Properties.Settings.Default.windowLocation = this.Location;
            Properties.Settings.Default.windowState = this.WindowState;
            
            Properties.Settings.Default.Save();
        }

		private void openToolStripMenuItem_Click(object sender, EventArgs e)
		{
			openFileDialog1.ShowDialog();
		}
		private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
		{
			string text = System.IO.File.ReadAllText(openFileDialog1.FileName);
			Properties.Settings.Default.fileOpenSaveLocation = openFileDialog1.FileName;
			saveFileDialog1.FileName = openFileDialog1.FileName;
			txtDtmfTones.Text = text;
		}

		private void saveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if ((saveFileDialog1.FileName != "") && (saveFileDialog1.FileName != "saveFileDialog1"))
			{
				System.IO.File.WriteAllText(openFileDialog1.FileName, txtDtmfTones.Text);
			}
			else
			{
				saveFileDialog1.ShowDialog();
			}
		}
		private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			saveFileDialog1.ShowDialog();
		}
		private void saveFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
		{
			Properties.Settings.Default.fileOpenSaveLocation = saveFileDialog1.FileName;
			System.IO.File.WriteAllText(saveFileDialog1.FileName, txtDtmfTones.Text);
		}

		private void sSHMenuToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Properties.Settings.Default.defaultForm = "SSH";
			this.Hide();
			var form2 = new FormSSH();
			form2.Closed += (s, args) => this.Close();
			form2.Show();
		}
	}
}