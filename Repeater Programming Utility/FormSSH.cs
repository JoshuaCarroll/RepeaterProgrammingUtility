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
		private string[] arrInput;

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
			txtDelay.Text = Properties.Settings.Default.sshDelay;
		}

		private void btnConnect_Click(object sender, EventArgs e)
		{
			if ((sshClient != null) && (sshClient.IsConnected))
			{
				sshClient.Disconnect();
				btnConnectDisconnect.Text = "Connect";
				btnStartStop.Text = "Start";
				btnStartStop.Enabled = false;
			}
			else
			{
				sshClient = new SshClient(txtServer.Text, txtUsername.Text, txtPassword.Text);
				sshClient.Connect();
				if (!sshClient.IsConnected)
					throw new Exception("Can't connect to host: " + sshClient.ConnectionInfo.Host);

				SshStream();
			}
		}

		private void btnStartStop_Click(object sender, EventArgs e)
		{
			if (!timer1.Enabled) {
				arrInput = txtScript.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
				timer1.Interval = int.Parse(txtDelay.Text);
				btnStartStop.Text = "Stop";
				txtScript.ReadOnly = true;
				inputLineNumber = 0;
				timer1.Enabled = true;
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
			if (inputLineNumber < arrInput.Length)
			{
				string command = arrInput[inputLineNumber];

				// Clean it up
				if (command.Contains(";"))
				{
					command = command.Remove(command.IndexOf(';'));
				}
				command = command.Trim();

				if (command != string.Empty)
				{
					txtOutput.Text += txtScript.Text + Environment.NewLine;
					txtOutput.Text += "> " + sshClient.RunCommand(txtScript.Text).Result + Environment.NewLine;
					txtOutput.Select(txtOutput.Text.Length, 0);
				}

				inputLineNumber++;
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
