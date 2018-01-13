namespace Repeater_Programming_Utility
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.txtDtmfTones = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cbComPort = new System.Windows.Forms.ComboBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.label9 = new System.Windows.Forms.Label();
            this.txtCallsign = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.securityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.reportAProblemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.provideASuggestionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtCommentCharacter = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtPauseBetweenDigits = new System.Windows.Forms.MaskedTextBox();
            this.cbIdBefore = new System.Windows.Forms.CheckBox();
            this.cbIdAfter = new System.Windows.Forms.CheckBox();
            this.txtLogonCode = new System.Windows.Forms.TextBox();
            this.btnLogon = new System.Windows.Forms.Button();
            this.btnLogoff = new System.Windows.Forms.Button();
            this.txtLogoffCode = new System.Windows.Forms.TextBox();
            this.groupBoxUser = new System.Windows.Forms.GroupBox();
            this.groupBoxDtmf = new System.Windows.Forms.GroupBox();
            this.groupBoxSecurity = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPauseBetweenLines = new System.Windows.Forms.MaskedTextBox();
            this.linkLabelCancel = new System.Windows.Forms.LinkLabel();
            this.groupBoxTone = new System.Windows.Forms.GroupBox();
            this.txtLengthOfEachTone = new System.Windows.Forms.MaskedTextBox();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBoxUser.SuspendLayout();
            this.groupBoxDtmf.SuspendLayout();
            this.groupBoxSecurity.SuspendLayout();
            this.groupBoxTone.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtDtmfTones
            // 
            this.txtDtmfTones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDtmfTones.Location = new System.Drawing.Point(11, 22);
            this.txtDtmfTones.Multiline = true;
            this.txtDtmfTones.Name = "txtDtmfTones";
            this.txtDtmfTones.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDtmfTones.Size = new System.Drawing.Size(854, 146);
            this.txtDtmfTones.TabIndex = 11;
            // 
            // btnSend
            // 
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSend.Location = new System.Drawing.Point(736, 410);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 25);
            this.btnSend.TabIndex = 2;
            this.btnSend.Text = "Transmit";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Pause between digits:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(253, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Pause between lines:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(172, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "ms";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(413, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "ms";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(643, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(20, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "ms";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(485, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Length of each tone:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(229, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(92, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "COM port of TNC:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cbComPort
            // 
            this.cbComPort.FormattingEnabled = true;
            this.cbComPort.Location = new System.Drawing.Point(327, 20);
            this.cbComPort.Name = "cbComPort";
            this.cbComPort.Size = new System.Drawing.Size(100, 21);
            this.cbComPort.TabIndex = 2;
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 443);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(904, 22);
            this.statusStrip1.TabIndex = 15;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 23);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "Call sign:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtCallsign
            // 
            this.txtCallsign.Location = new System.Drawing.Point(66, 20);
            this.txtCallsign.Name = "txtCallsign";
            this.txtCallsign.Size = new System.Drawing.Size(100, 20);
            this.txtCallsign.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(904, 24);
            this.menuStrip1.TabIndex = 18;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.openToolStripMenuItem.Text = "Open...";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.saveAsToolStripMenuItem.Text = "Save As...";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.userToolStripMenuItem,
            this.toneToolStripMenuItem,
            this.securityToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // userToolStripMenuItem
            // 
            this.userToolStripMenuItem.Checked = true;
            this.userToolStripMenuItem.CheckOnClick = true;
            this.userToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.userToolStripMenuItem.Name = "userToolStripMenuItem";
            this.userToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.userToolStripMenuItem.Tag = "groupBoxUser";
            this.userToolStripMenuItem.Text = "User";
            this.userToolStripMenuItem.Click += new System.EventHandler(this.userToolStripMenuItem_Click);
            // 
            // toneToolStripMenuItem
            // 
            this.toneToolStripMenuItem.Checked = true;
            this.toneToolStripMenuItem.CheckOnClick = true;
            this.toneToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toneToolStripMenuItem.Name = "toneToolStripMenuItem";
            this.toneToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.toneToolStripMenuItem.Tag = "groupBoxTone";
            this.toneToolStripMenuItem.Text = "Tone";
            this.toneToolStripMenuItem.Click += new System.EventHandler(this.toneToolStripMenuItem_Click);
            // 
            // securityToolStripMenuItem
            // 
            this.securityToolStripMenuItem.Checked = true;
            this.securityToolStripMenuItem.CheckOnClick = true;
            this.securityToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.securityToolStripMenuItem.Name = "securityToolStripMenuItem";
            this.securityToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.securityToolStripMenuItem.Tag = "groupBoxSecurity";
            this.securityToolStripMenuItem.Text = "Security";
            this.securityToolStripMenuItem.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reportAProblemToolStripMenuItem,
            this.provideASuggestionToolStripMenuItem,
            this.toolStripSeparator1,
            this.aboutToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(44, 20);
            this.toolStripMenuItem1.Text = "Help";
            // 
            // reportAProblemToolStripMenuItem
            // 
            this.reportAProblemToolStripMenuItem.Name = "reportAProblemToolStripMenuItem";
            this.reportAProblemToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.reportAProblemToolStripMenuItem.Text = "Report a problem";
            this.reportAProblemToolStripMenuItem.Click += new System.EventHandler(this.reportAProblemToolStripMenuItem_Click);
            // 
            // provideASuggestionToolStripMenuItem
            // 
            this.provideASuggestionToolStripMenuItem.Name = "provideASuggestionToolStripMenuItem";
            this.provideASuggestionToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.provideASuggestionToolStripMenuItem.Text = "Provide a suggestion";
            this.provideASuggestionToolStripMenuItem.Click += new System.EventHandler(this.provideASuggestionToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(181, 6);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // txtCommentCharacter
            // 
            this.txtCommentCharacter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCommentCharacter.Location = new System.Drawing.Point(817, 20);
            this.txtCommentCharacter.Name = "txtCommentCharacter";
            this.txtCommentCharacter.Size = new System.Drawing.Size(40, 20);
            this.txtCommentCharacter.TabIndex = 3;
            this.txtCommentCharacter.Text = ";";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(709, 23);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(102, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "Comment character:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPauseBetweenDigits
            // 
            this.txtPauseBetweenDigits.Location = new System.Drawing.Point(126, 20);
            this.txtPauseBetweenDigits.Mask = "000";
            this.txtPauseBetweenDigits.Name = "txtPauseBetweenDigits";
            this.txtPauseBetweenDigits.PromptChar = ' ';
            this.txtPauseBetweenDigits.Size = new System.Drawing.Size(40, 20);
            this.txtPauseBetweenDigits.TabIndex = 4;
            this.txtPauseBetweenDigits.Text = "225";
            // 
            // cbIdBefore
            // 
            this.cbIdBefore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbIdBefore.AutoSize = true;
            this.cbIdBefore.Checked = true;
            this.cbIdBefore.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbIdBefore.Location = new System.Drawing.Point(489, 415);
            this.cbIdBefore.Name = "cbIdBefore";
            this.cbIdBefore.Size = new System.Drawing.Size(99, 17);
            this.cbIdBefore.TabIndex = 12;
            this.cbIdBefore.Text = "ID before tones";
            this.cbIdBefore.UseVisualStyleBackColor = true;
            // 
            // cbIdAfter
            // 
            this.cbIdAfter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbIdAfter.AutoSize = true;
            this.cbIdAfter.Checked = true;
            this.cbIdAfter.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbIdAfter.Location = new System.Drawing.Point(611, 415);
            this.cbIdAfter.Name = "cbIdAfter";
            this.cbIdAfter.Size = new System.Drawing.Size(90, 17);
            this.cbIdAfter.TabIndex = 13;
            this.cbIdAfter.Text = "ID after tones";
            this.cbIdAfter.UseVisualStyleBackColor = true;
            // 
            // txtLogonCode
            // 
            this.txtLogonCode.Location = new System.Drawing.Point(85, 18);
            this.txtLogonCode.Name = "txtLogonCode";
            this.txtLogonCode.Size = new System.Drawing.Size(100, 20);
            this.txtLogonCode.TabIndex = 7;
            this.txtLogonCode.Text = "187 001 1234";
            // 
            // btnLogon
            // 
            this.btnLogon.Location = new System.Drawing.Point(191, 16);
            this.btnLogon.Name = "btnLogon";
            this.btnLogon.Size = new System.Drawing.Size(75, 23);
            this.btnLogon.TabIndex = 8;
            this.btnLogon.Text = "Log on";
            this.btnLogon.UseVisualStyleBackColor = true;
            this.btnLogon.Click += new System.EventHandler(this.btnLogon_Click);
            // 
            // btnLogoff
            // 
            this.btnLogoff.Location = new System.Drawing.Point(530, 18);
            this.btnLogoff.Name = "btnLogoff";
            this.btnLogoff.Size = new System.Drawing.Size(75, 23);
            this.btnLogoff.TabIndex = 10;
            this.btnLogoff.Text = "Log off";
            this.btnLogoff.UseVisualStyleBackColor = true;
            this.btnLogoff.Click += new System.EventHandler(this.btnLogoff_Click);
            // 
            // txtLogoffCode
            // 
            this.txtLogoffCode.Location = new System.Drawing.Point(424, 20);
            this.txtLogoffCode.Name = "txtLogoffCode";
            this.txtLogoffCode.Size = new System.Drawing.Size(100, 20);
            this.txtLogoffCode.TabIndex = 9;
            this.txtLogoffCode.Text = "189";
            // 
            // groupBoxUser
            // 
            this.groupBoxUser.Controls.Add(this.label8);
            this.groupBoxUser.Controls.Add(this.cbComPort);
            this.groupBoxUser.Controls.Add(this.txtCallsign);
            this.groupBoxUser.Controls.Add(this.label9);
            this.groupBoxUser.Location = new System.Drawing.Point(14, 29);
            this.groupBoxUser.Margin = new System.Windows.Forms.Padding(5);
            this.groupBoxUser.Name = "groupBoxUser";
            this.groupBoxUser.Padding = new System.Windows.Forms.Padding(6, 10, 6, 6);
            this.groupBoxUser.Size = new System.Drawing.Size(875, 56);
            this.groupBoxUser.TabIndex = 1;
            this.groupBoxUser.TabStop = false;
            this.groupBoxUser.Text = "User";
            // 
            // groupBoxDtmf
            // 
            this.groupBoxDtmf.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxDtmf.Controls.Add(this.txtDtmfTones);
            this.groupBoxDtmf.Location = new System.Drawing.Point(15, 227);
            this.groupBoxDtmf.Margin = new System.Windows.Forms.Padding(5);
            this.groupBoxDtmf.Name = "groupBoxDtmf";
            this.groupBoxDtmf.Padding = new System.Windows.Forms.Padding(6);
            this.groupBoxDtmf.Size = new System.Drawing.Size(874, 177);
            this.groupBoxDtmf.TabIndex = 29;
            this.groupBoxDtmf.TabStop = false;
            this.groupBoxDtmf.Text = "DTMF to send";
            // 
            // groupBoxSecurity
            // 
            this.groupBoxSecurity.Controls.Add(this.label11);
            this.groupBoxSecurity.Controls.Add(this.label5);
            this.groupBoxSecurity.Controls.Add(this.txtLogoffCode);
            this.groupBoxSecurity.Controls.Add(this.txtLogonCode);
            this.groupBoxSecurity.Controls.Add(this.btnLogon);
            this.groupBoxSecurity.Controls.Add(this.btnLogoff);
            this.groupBoxSecurity.Location = new System.Drawing.Point(14, 161);
            this.groupBoxSecurity.Margin = new System.Windows.Forms.Padding(5);
            this.groupBoxSecurity.Name = "groupBoxSecurity";
            this.groupBoxSecurity.Padding = new System.Windows.Forms.Padding(6, 10, 6, 6);
            this.groupBoxSecurity.Size = new System.Drawing.Size(875, 56);
            this.groupBoxSecurity.TabIndex = 30;
            this.groupBoxSecurity.TabStop = false;
            this.groupBoxSecurity.Text = "Security";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(348, 23);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(70, 13);
            this.label11.TabIndex = 29;
            this.label11.Text = "Log off code:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 28;
            this.label5.Text = "Log on code:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtPauseBetweenLines
            // 
            this.txtPauseBetweenLines.Location = new System.Drawing.Point(367, 20);
            this.txtPauseBetweenLines.Mask = "0000";
            this.txtPauseBetweenLines.Name = "txtPauseBetweenLines";
            this.txtPauseBetweenLines.Size = new System.Drawing.Size(40, 20);
            this.txtPauseBetweenLines.TabIndex = 5;
            this.txtPauseBetweenLines.Text = "6000";
            // 
            // linkLabelCancel
            // 
            this.linkLabelCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabelCancel.AutoSize = true;
            this.linkLabelCancel.Location = new System.Drawing.Point(817, 416);
            this.linkLabelCancel.Name = "linkLabelCancel";
            this.linkLabelCancel.Size = new System.Drawing.Size(40, 13);
            this.linkLabelCancel.TabIndex = 31;
            this.linkLabelCancel.TabStop = true;
            this.linkLabelCancel.Text = "Cancel";
            this.linkLabelCancel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelCancel_LinkClicked);
            // 
            // groupBoxTone
            // 
            this.groupBoxTone.Controls.Add(this.txtLengthOfEachTone);
            this.groupBoxTone.Controls.Add(this.txtPauseBetweenLines);
            this.groupBoxTone.Controls.Add(this.label1);
            this.groupBoxTone.Controls.Add(this.label10);
            this.groupBoxTone.Controls.Add(this.label2);
            this.groupBoxTone.Controls.Add(this.txtCommentCharacter);
            this.groupBoxTone.Controls.Add(this.label3);
            this.groupBoxTone.Controls.Add(this.label6);
            this.groupBoxTone.Controls.Add(this.label4);
            this.groupBoxTone.Controls.Add(this.txtPauseBetweenDigits);
            this.groupBoxTone.Controls.Add(this.label7);
            this.groupBoxTone.Location = new System.Drawing.Point(14, 95);
            this.groupBoxTone.Margin = new System.Windows.Forms.Padding(5);
            this.groupBoxTone.Name = "groupBoxTone";
            this.groupBoxTone.Padding = new System.Windows.Forms.Padding(6, 10, 6, 6);
            this.groupBoxTone.Size = new System.Drawing.Size(875, 56);
            this.groupBoxTone.TabIndex = 32;
            this.groupBoxTone.TabStop = false;
            this.groupBoxTone.Text = "Tone";
            // 
            // txtLengthOfEachTone
            // 
            this.txtLengthOfEachTone.Location = new System.Drawing.Point(597, 20);
            this.txtLengthOfEachTone.Mask = "000";
            this.txtLengthOfEachTone.Name = "txtLengthOfEachTone";
            this.txtLengthOfEachTone.Size = new System.Drawing.Size(40, 20);
            this.txtLengthOfEachTone.TabIndex = 20;
            this.txtLengthOfEachTone.Text = "225";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 465);
            this.Controls.Add(this.groupBoxTone);
            this.Controls.Add(this.linkLabelCancel);
            this.Controls.Add(this.groupBoxSecurity);
            this.Controls.Add(this.groupBoxDtmf);
            this.Controls.Add(this.groupBoxUser);
            this.Controls.Add(this.cbIdAfter);
            this.Controls.Add(this.cbIdBefore);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.btnSend);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(920, 503);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "N5JLC Repeater Programming Utility";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBoxUser.ResumeLayout(false);
            this.groupBoxUser.PerformLayout();
            this.groupBoxDtmf.ResumeLayout(false);
            this.groupBoxDtmf.PerformLayout();
            this.groupBoxSecurity.ResumeLayout(false);
            this.groupBoxSecurity.PerformLayout();
            this.groupBoxTone.ResumeLayout(false);
            this.groupBoxTone.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDtmfTones;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbComPort;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtCallsign;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.TextBox txtCommentCharacter;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.MaskedTextBox txtPauseBetweenDigits;
        private System.Windows.Forms.CheckBox cbIdBefore;
        private System.Windows.Forms.CheckBox cbIdAfter;
        private System.Windows.Forms.TextBox txtLogonCode;
        private System.Windows.Forms.Button btnLogon;
        private System.Windows.Forms.Button btnLogoff;
        private System.Windows.Forms.TextBox txtLogoffCode;
        private System.Windows.Forms.GroupBox groupBoxUser;
        private System.Windows.Forms.GroupBox groupBoxDtmf;
        private System.Windows.Forms.GroupBox groupBoxSecurity;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MaskedTextBox txtPauseBetweenLines;
        private System.Windows.Forms.LinkLabel linkLabelCancel;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem securityToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBoxTone;
        private System.Windows.Forms.ToolStripMenuItem userToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportAProblemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem provideASuggestionToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.MaskedTextBox txtLengthOfEachTone;
    }
}

