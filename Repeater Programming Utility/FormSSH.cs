using Renci.SshNet;
using Renci.SshNet.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Repeater_Programming_Utility
{
	public partial class FormSSH : Form
	{
		private SshClient sshClient;
		private int inputLineNumber = 0;
		private bool readyForNextLine = true;

		MemoryStream memoryStream = new MemoryStream(new byte[1000000]);
		TextWriter outputWriter;
		TextReader shellOutput;
		ShellStream shellStream;
		StreamReader streamReader;
		StreamWriter streamWriter;
		public const int COMMAND_TIMEOUT = 5000;
		public event EventHandler<NewOutputEventArgs> NewOutput;

		public FormSSH()
		{
			InitializeComponent();
		}

		private void FormSSH_Load(object sender, EventArgs e)
		{
			txtServer.Text = Properties.Settings.Default.sshServer;
			txtUsername.Text = Properties.Settings.Default.sshUsername;
			txtPassword.Text = Properties.Settings.Default.sshPassword;
			txtWaitForPrompt.Text = Properties.Settings.Default.sshWaitForPrompt;
		}

		private void btnConnect_Click(object sender, EventArgs e)
		{
			if ((sshClient != null) && (sshClient.IsConnected))
			{
				txtOutput.AppendText("\r\n\r\nDisconnecting...\r\n\r\n");
				sshClient.Disconnect();
				txtOutput.AppendText("Disconnected.\r\n\r\n");
				btnConnectDisconnect.Text = "Connect";
				btnStartStop.Text = "Start";
				btnStartStop.Enabled = false;
			}
			else
			{
				txtOutput.AppendText("\r\n\r\nConnecting...\r\n\r\n");
				sshClient = new SshClient(txtServer.Text, txtUsername.Text, txtPassword.Text);
				sshClient.Connect();
				if (!sshClient.IsConnected)
				{
					txtOutput.AppendText("** Unable to connect to host: " + sshClient.ConnectionInfo.Host);
				}
				else
				{
					txtOutput.AppendText("Connected.\r\n\r\n");
					btnConnectDisconnect.Text = "Disconnect";
					btnStartStop.Enabled = true;
					SshStream();
				}
			}
		}

		private void btnStartStop_Click(object sender, EventArgs e)
		{
			if (!timer1.Enabled) {
				btnStartStop.Text = "Stop";
				inputLineNumber = 0;
				txtScript.ReadOnly = readyForNextLine = true;
				timer1.Enabled = true;
				txtScript.Focus();
			}
			else
			{
				timer1.Enabled = false;
				txtScript.ReadOnly = false;
				btnStartStop.Text = "Start";
			}
		}

		private void FormSSH_FormClosing(object sender, FormClosingEventArgs e)
		{
			
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			if (inputLineNumber < txtScript.Lines.Length)
			{
				if (readyForNextLine)
				{
					string command = txtScript.Lines[inputLineNumber];
					int selectStart = txtScript.GetFirstCharIndexFromLine(inputLineNumber);
					int selectEnd = txtScript.Text.IndexOf(Environment.NewLine, txtScript.GetFirstCharIndexFromLine(inputLineNumber));
					if (selectEnd == -1) { selectEnd = txtScript.Text.Length; }
					txtScript.Select(selectStart, selectEnd - selectStart);

					// Clean it up
					if (command.Contains(";")) { command = command.Remove(command.IndexOf(';')); }
					command = command.Trim();

					if (command != string.Empty)
					{
						readyForNextLine = false;
						RunCommand(command);
					}

					inputLineNumber++;
				}
			}
			else
			{
				btnStartStop_Click(sender, e);
			}
		}

		public class NewOutputEventArgs : EventArgs
		{
			public string Line { get; set; }
		}
		public void SshStream()
		{
			var x = new Dictionary<Renci.SshNet.Common.TerminalModes, uint>();
			//x.Add(Renci.SshNet.Common.TerminalModes.VERASE, 0);
			shellStream = sshClient.CreateShellStream("dumb", 100, 24, Convert.ToUInt32(txtOutput.Width), Convert.ToUInt32(txtOutput.Height), 17640, x);
			shellStream.DataReceived += stream_DataReceived;
			streamReader = new StreamReader(shellStream);
			streamWriter = new StreamWriter(shellStream);
			streamWriter.AutoFlush = true;
			outputWriter = new StreamWriter(memoryStream);
			shellOutput = new StreamReader(memoryStream);
		}

		void stream_DataReceived(object sender, Renci.SshNet.Common.ShellDataEventArgs e)
		{
			var line = streamReader.ReadToEnd();
			while (line != null && !line.Equals(""))
			{
				bool x = line.Contains('\n');
				ToOutput(line);
				line = streamReader.ReadToEnd();
			}
		}

		void ToOutput(string line)
		{
			if (line.Trim() == txtWaitForPrompt.Text)
			{
				readyForNextLine = true;
			}
			outputWriter.WriteLine(line);
			outputWriter.Flush();
			Output(line);
			if (NewOutput != null) NewOutput(this, new NewOutputEventArgs() { Line = line });
		}

		public bool RunCommand(string cmd)
		{
			shellStream.WriteLine(cmd);
			shellStream.Flush();

			return true;
		}
		delegate void SetTextCallback(string text);
		private void Output(string text)
		{
			// InvokeRequired required compares the thread ID of the
			// calling thread to the thread ID of the creating thread.
			// If these threads are different, it returns true.
			if (this.txtOutput.InvokeRequired)
			{
				SetTextCallback d = new SetTextCallback(Output);
				this.Invoke(d, new object[] { text });
			}
			else
			{
				this.txtOutput.AppendText(text);
			}
		}


		private void txtCommand_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)13)
			{
				RunCommand(txtCommand.Text);
				txtCommand.Text = "";
				e.Handled = true;
			}
		}
	}
}
