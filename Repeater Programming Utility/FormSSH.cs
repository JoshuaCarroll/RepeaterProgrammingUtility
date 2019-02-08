using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Repeater_Programming_Utility
{
	public partial class FormSSH : Form
	{
		private SshClient sshClient;

		public FormSSH()
		{
			InitializeComponent();
		}

		private void FormSSH_Load(object sender, EventArgs e)
		{
			
		}

		private void btnConnect_Click(object sender, EventArgs e)
		{
			sshClient = new SshClient(txtServer.Text, txtUsername.Text, txtPassword.Text);
			if (sshClient.IsConnected)
			{
				sshClient.Disconnect();
				btnConnectDisconnect.Text = "Connect";
				btnStartStop.Text = "Start";
				btnStartStop.Enabled = false;
			}
			else
			{
				sshClient.Connect();
				btnConnectDisconnect.Text = "Disconnect";
				btnStartStop.Enabled = true;
			}
		}

		private void btnStartStop_Click(object sender, EventArgs e)
		{
			// Lock input
			// Read input into array
			// Start timer
			timer1.Interval = int.Parse(txtDelay.Text);
		}

		private void FormSSH_FormClosing(object sender, FormClosingEventArgs e)
		{
			
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			txtOutput.Text += txtScript.Text + Environment.NewLine;
			txtOutput.Text += sshClient.RunCommand(txtScript.Text).Result + Environment.NewLine;
		}
	}
}
