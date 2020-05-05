using Renci.SshNet;
using Renci.SshNet.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Deployment.Application;
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
			Properties.Settings.Default.sshServer = txtServer.Text;
			Properties.Settings.Default.sshUsername = txtUsername.Text;
			Properties.Settings.Default.sshPassword = txtPassword.Text;

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
				try
				{
					sshClient.Connect();
				}
				catch (Exception ex)
				{
					txtOutput.AppendText("** Unable to connect to " + sshClient.ConnectionInfo.Host + " (" + ex.Message + ")\r\n\r\n");
				}
				
				if (sshClient.IsConnected)
				{
					txtOutput.AppendText("Connected.\r\n\r\n");
					btnConnectDisconnect.Text = "Disconnect";
					btnStartStop.Enabled = true;
					SshStream();
					RunCommand("");
				}
			}
		}

		private void btnStartStop_Click(object sender, EventArgs e)
		{
			Properties.Settings.Default.sshWaitForPrompt = txtWaitForPrompt.Text;

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
					readyForNextLine = false;
					string command = "";
					do
					{
						inputLineNumber++;
						if (inputLineNumber >= txtScript.Lines.Length)
						{
							break;
						}
						command = txtScript.Lines[inputLineNumber];
						if (command.Contains(";")) { command = command.Remove(command.IndexOf(';')); }
						command = command.Trim();
					} while ((command == string.Empty) && (inputLineNumber + 1 < txtScript.Lines.Length));

					if (command != string.Empty)
					{
						RunCommand(command);
					}

					if (inputLineNumber + 1 < txtScript.Lines.Length)
					{
						int selectStart = txtScript.GetFirstCharIndexFromLine(inputLineNumber);
						if (selectStart != -1)
						{
							int selectEnd = txtScript.Text.IndexOf(Environment.NewLine, txtScript.GetFirstCharIndexFromLine(inputLineNumber));
							if (selectEnd == -1) { selectEnd = txtScript.Text.Length; }
							txtScript.Select(selectStart, selectEnd - selectStart);
							txtScript.ScrollToCaret();
						}
					}
					else
					{
						btnStartStop_Click(sender, e);
					}
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
			if (line.Trim().Contains(txtWaitForPrompt.Text))
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
			if (sshClient.IsConnected)
			{
				shellStream.WriteLine(cmd);
				shellStream.Flush();

				return true;
			}
			else
			{
				MessageBox.Show("Client not connected", "Not connected", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
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

		private void reportAProToolStripMenuItem_Click(object sender, EventArgs e)
		{
			string version = ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString(4);
			System.Diagnostics.Process.Start("https://github.com/JoshuaCarroll/RepeaterProgrammingUtility/issues/new?body=-%20What%20were%20you%20trying%20to%20do%3F%20%0D%0A%0D%0A%0D%0A-%20What%20happened%20instead%3F%0D%0A%0D%0A%0D%0A_____%0D%0AOS%3A%20Windows%0D%0ASoftware%20version%3A%20" + version + "&labels=bug");
		}

		private void provideASuggestionToolStripMenuItem_Click(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start("https://github.com/JoshuaCarroll/RepeaterProgrammingUtility/issues/new?labels=enhancement");
		}

		private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start("https://github.com/JoshuaCarroll/RepeaterProgrammingUtility#user-content-n5jlc-repeater-programming-utility");
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
			txtScript.Text = text;
		}

		private void saveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if ((saveFileDialog1.FileName != "") && (saveFileDialog1.FileName != "saveFileDialog1"))
			{
				System.IO.File.WriteAllText(openFileDialog1.FileName, txtScript.Text);
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

		private void switchToDTMFToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Properties.Settings.Default.defaultForm = "";
			this.Hide();
			var form1 = new Form1();
			form1.Closed += (s, args) => this.Close();
			form1.Show();
		}
	}
}
