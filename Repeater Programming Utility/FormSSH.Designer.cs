namespace Repeater_Programming_Utility
{
	partial class FormSSH
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.txtServer = new System.Windows.Forms.TextBox();
			this.txtUsername = new System.Windows.Forms.TextBox();
			this.txtPassword = new System.Windows.Forms.TextBox();
			this.txtScript = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.txtOutput = new System.Windows.Forms.TextBox();
			this.button2 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(40, 30);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(35, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "label1";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(210, 29);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(35, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "label2";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(379, 30);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(35, 13);
			this.label3.TabIndex = 2;
			this.label3.Text = "label3";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(43, 103);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(0, 13);
			this.label4.TabIndex = 3;
			// 
			// txtServer
			// 
			this.txtServer.Location = new System.Drawing.Point(82, 30);
			this.txtServer.Name = "txtServer";
			this.txtServer.Size = new System.Drawing.Size(100, 20);
			this.txtServer.TabIndex = 4;
			// 
			// txtUsername
			// 
			this.txtUsername.Location = new System.Drawing.Point(251, 29);
			this.txtUsername.Name = "txtUsername";
			this.txtUsername.Size = new System.Drawing.Size(100, 20);
			this.txtUsername.TabIndex = 5;
			// 
			// txtPassword
			// 
			this.txtPassword.Location = new System.Drawing.Point(434, 22);
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.Size = new System.Drawing.Size(100, 20);
			this.txtPassword.TabIndex = 6;
			// 
			// txtScript
			// 
			this.txtScript.Location = new System.Drawing.Point(24, 83);
			this.txtScript.Multiline = true;
			this.txtScript.Name = "txtScript";
			this.txtScript.Size = new System.Drawing.Size(349, 283);
			this.txtScript.TabIndex = 7;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(606, 18);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 8;
			this.button1.Text = "Connect";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// txtOutput
			// 
			this.txtOutput.BackColor = System.Drawing.Color.Black;
			this.txtOutput.ForeColor = System.Drawing.Color.LightGreen;
			this.txtOutput.Location = new System.Drawing.Point(392, 83);
			this.txtOutput.Multiline = true;
			this.txtOutput.Name = "txtOutput";
			this.txtOutput.ReadOnly = true;
			this.txtOutput.Size = new System.Drawing.Size(349, 283);
			this.txtOutput.TabIndex = 9;
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(298, 372);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 10;
			this.button2.Text = "Start";
			this.button2.UseVisualStyleBackColor = true;
			// 
			// FormSSH
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(865, 447);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.txtOutput);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.txtScript);
			this.Controls.Add(this.txtPassword);
			this.Controls.Add(this.txtUsername);
			this.Controls.Add(this.txtServer);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "FormSSH";
			this.Text = "FormSSH";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtServer;
		private System.Windows.Forms.TextBox txtUsername;
		private System.Windows.Forms.TextBox txtPassword;
		private System.Windows.Forms.TextBox txtScript;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox txtOutput;
		private System.Windows.Forms.Button button2;
	}
}