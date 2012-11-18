namespace IceCastRemoteControl
{
    partial class MainFrm
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
            this.tabCtrl = new System.Windows.Forms.TabControl();
            this.tabManage = new System.Windows.Forms.TabPage();
            this.tabSettings = new System.Windows.Forms.TabPage();
            this.btnStopIceCast = new System.Windows.Forms.Button();
            this.btnStartIceCast = new System.Windows.Forms.Button();
            this.btnStopEZStream = new System.Windows.Forms.Button();
            this.btnStartEZStream = new System.Windows.Forms.Button();
            this.btnSwitchPlayList = new System.Windows.Forms.Button();
            this.btnNextTrack = new System.Windows.Forms.Button();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.lblIceCastRemotePath = new System.Windows.Forms.Label();
            this.edIceCastRemotePath = new System.Windows.Forms.TextBox();
            this.edEZStreamRemotePath = new System.Windows.Forms.TextBox();
            this.lblEZStreamRemotePath = new System.Windows.Forms.Label();
            this.edMusicFolderPath = new System.Windows.Forms.TextBox();
            this.lblMusicFolderPath = new System.Windows.Forms.Label();
            this.edSSHHost = new System.Windows.Forms.TextBox();
            this.lblSSHHost = new System.Windows.Forms.Label();
            this.edSSHUsr = new System.Windows.Forms.TextBox();
            this.lblSSHUsr = new System.Windows.Forms.Label();
            this.edSSHPwd = new System.Windows.Forms.TextBox();
            this.lblSSHPwd = new System.Windows.Forms.Label();
            this.lblIceCast = new System.Windows.Forms.Label();
            this.lblEZStream = new System.Windows.Forms.Label();
            this.btnEZStreamRestart = new System.Windows.Forms.Button();
            this.btnIceCastRestart = new System.Windows.Forms.Button();
            this.btnFullRestart = new System.Windows.Forms.Button();
            this.tabCtrl.SuspendLayout();
            this.tabManage.SuspendLayout();
            this.tabSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabCtrl
            // 
            this.tabCtrl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabCtrl.Controls.Add(this.tabManage);
            this.tabCtrl.Controls.Add(this.tabSettings);
            this.tabCtrl.Location = new System.Drawing.Point(-1, 0);
            this.tabCtrl.Name = "tabCtrl";
            this.tabCtrl.SelectedIndex = 0;
            this.tabCtrl.Size = new System.Drawing.Size(430, 337);
            this.tabCtrl.TabIndex = 0;
            // 
            // tabManage
            // 
            this.tabManage.Controls.Add(this.btnFullRestart);
            this.tabManage.Controls.Add(this.btnEZStreamRestart);
            this.tabManage.Controls.Add(this.btnIceCastRestart);
            this.tabManage.Controls.Add(this.lblEZStream);
            this.tabManage.Controls.Add(this.lblIceCast);
            this.tabManage.Controls.Add(this.txtOutput);
            this.tabManage.Controls.Add(this.btnNextTrack);
            this.tabManage.Controls.Add(this.btnSwitchPlayList);
            this.tabManage.Controls.Add(this.btnStartEZStream);
            this.tabManage.Controls.Add(this.btnStopEZStream);
            this.tabManage.Controls.Add(this.btnStartIceCast);
            this.tabManage.Controls.Add(this.btnStopIceCast);
            this.tabManage.Location = new System.Drawing.Point(4, 22);
            this.tabManage.Name = "tabManage";
            this.tabManage.Padding = new System.Windows.Forms.Padding(3);
            this.tabManage.Size = new System.Drawing.Size(422, 311);
            this.tabManage.TabIndex = 0;
            this.tabManage.Text = "Control";
            this.tabManage.UseVisualStyleBackColor = true;
            // 
            // tabSettings
            // 
            this.tabSettings.Controls.Add(this.edSSHPwd);
            this.tabSettings.Controls.Add(this.lblSSHPwd);
            this.tabSettings.Controls.Add(this.edSSHUsr);
            this.tabSettings.Controls.Add(this.lblSSHUsr);
            this.tabSettings.Controls.Add(this.edSSHHost);
            this.tabSettings.Controls.Add(this.lblSSHHost);
            this.tabSettings.Controls.Add(this.edMusicFolderPath);
            this.tabSettings.Controls.Add(this.lblMusicFolderPath);
            this.tabSettings.Controls.Add(this.edEZStreamRemotePath);
            this.tabSettings.Controls.Add(this.lblEZStreamRemotePath);
            this.tabSettings.Controls.Add(this.edIceCastRemotePath);
            this.tabSettings.Controls.Add(this.lblIceCastRemotePath);
            this.tabSettings.Location = new System.Drawing.Point(4, 22);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabSettings.Size = new System.Drawing.Size(422, 311);
            this.tabSettings.TabIndex = 1;
            this.tabSettings.Text = "Settings";
            this.tabSettings.UseVisualStyleBackColor = true;
            // 
            // btnStopIceCast
            // 
            this.btnStopIceCast.Location = new System.Drawing.Point(63, 11);
            this.btnStopIceCast.Name = "btnStopIceCast";
            this.btnStopIceCast.Size = new System.Drawing.Size(90, 23);
            this.btnStopIceCast.TabIndex = 1;
            this.btnStopIceCast.Text = "Stop";
            this.btnStopIceCast.UseVisualStyleBackColor = true;
            this.btnStopIceCast.Click += new System.EventHandler(this.btnStopIceCast_Click);
            // 
            // btnStartIceCast
            // 
            this.btnStartIceCast.Location = new System.Drawing.Point(155, 11);
            this.btnStartIceCast.Name = "btnStartIceCast";
            this.btnStartIceCast.Size = new System.Drawing.Size(90, 23);
            this.btnStartIceCast.TabIndex = 2;
            this.btnStartIceCast.Text = "Start";
            this.btnStartIceCast.UseVisualStyleBackColor = true;
            this.btnStartIceCast.Click += new System.EventHandler(this.btnStartIceCast_Click);
            // 
            // btnStopEZStream
            // 
            this.btnStopEZStream.Location = new System.Drawing.Point(63, 41);
            this.btnStopEZStream.Name = "btnStopEZStream";
            this.btnStopEZStream.Size = new System.Drawing.Size(90, 23);
            this.btnStopEZStream.TabIndex = 5;
            this.btnStopEZStream.Text = "Stop";
            this.btnStopEZStream.UseVisualStyleBackColor = true;
            this.btnStopEZStream.Click += new System.EventHandler(this.btnStopEZStream_Click);
            // 
            // btnStartEZStream
            // 
            this.btnStartEZStream.Location = new System.Drawing.Point(155, 40);
            this.btnStartEZStream.Name = "btnStartEZStream";
            this.btnStartEZStream.Size = new System.Drawing.Size(90, 23);
            this.btnStartEZStream.TabIndex = 6;
            this.btnStartEZStream.Text = "Start";
            this.btnStartEZStream.UseVisualStyleBackColor = true;
            this.btnStartEZStream.Click += new System.EventHandler(this.btnStartEZStream_Click);
            // 
            // btnSwitchPlayList
            // 
            this.btnSwitchPlayList.Location = new System.Drawing.Point(63, 69);
            this.btnSwitchPlayList.Name = "btnSwitchPlayList";
            this.btnSwitchPlayList.Size = new System.Drawing.Size(137, 23);
            this.btnSwitchPlayList.TabIndex = 9;
            this.btnSwitchPlayList.Text = "Switch play-list";
            this.btnSwitchPlayList.UseVisualStyleBackColor = true;
            this.btnSwitchPlayList.Click += new System.EventHandler(this.btnSwitchPlayList_Click);
            // 
            // btnNextTrack
            // 
            this.btnNextTrack.Location = new System.Drawing.Point(206, 69);
            this.btnNextTrack.Name = "btnNextTrack";
            this.btnNextTrack.Size = new System.Drawing.Size(131, 23);
            this.btnNextTrack.TabIndex = 10;
            this.btnNextTrack.Text = "Next track";
            this.btnNextTrack.UseVisualStyleBackColor = true;
            this.btnNextTrack.Click += new System.EventHandler(this.btnNextTrack_Click);
            // 
            // txtOutput
            // 
            this.txtOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOutput.Location = new System.Drawing.Point(5, 115);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.Size = new System.Drawing.Size(410, 190);
            this.txtOutput.TabIndex = 11;
            // 
            // lblIceCastRemotePath
            // 
            this.lblIceCastRemotePath.AutoSize = true;
            this.lblIceCastRemotePath.Location = new System.Drawing.Point(10, 7);
            this.lblIceCastRemotePath.Name = "lblIceCastRemotePath";
            this.lblIceCastRemotePath.Size = new System.Drawing.Size(101, 13);
            this.lblIceCastRemotePath.TabIndex = 0;
            this.lblIceCastRemotePath.Text = "iceCastRemotePath";
            // 
            // edIceCastRemotePath
            // 
            this.edIceCastRemotePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edIceCastRemotePath.Location = new System.Drawing.Point(10, 24);
            this.edIceCastRemotePath.Name = "edIceCastRemotePath";
            this.edIceCastRemotePath.Size = new System.Drawing.Size(403, 20);
            this.edIceCastRemotePath.TabIndex = 1;
            // 
            // edEZStreamRemotePath
            // 
            this.edEZStreamRemotePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edEZStreamRemotePath.Location = new System.Drawing.Point(10, 73);
            this.edEZStreamRemotePath.Name = "edEZStreamRemotePath";
            this.edEZStreamRemotePath.Size = new System.Drawing.Size(403, 20);
            this.edEZStreamRemotePath.TabIndex = 3;
            // 
            // lblEZStreamRemotePath
            // 
            this.lblEZStreamRemotePath.AutoSize = true;
            this.lblEZStreamRemotePath.Location = new System.Drawing.Point(10, 56);
            this.lblEZStreamRemotePath.Name = "lblEZStreamRemotePath";
            this.lblEZStreamRemotePath.Size = new System.Drawing.Size(113, 13);
            this.lblEZStreamRemotePath.TabIndex = 2;
            this.lblEZStreamRemotePath.Text = "EZStreamRemotePath";
            // 
            // edMusicFolderPath
            // 
            this.edMusicFolderPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edMusicFolderPath.Location = new System.Drawing.Point(10, 123);
            this.edMusicFolderPath.Name = "edMusicFolderPath";
            this.edMusicFolderPath.Size = new System.Drawing.Size(403, 20);
            this.edMusicFolderPath.TabIndex = 5;
            // 
            // lblMusicFolderPath
            // 
            this.lblMusicFolderPath.AutoSize = true;
            this.lblMusicFolderPath.Location = new System.Drawing.Point(10, 106);
            this.lblMusicFolderPath.Name = "lblMusicFolderPath";
            this.lblMusicFolderPath.Size = new System.Drawing.Size(86, 13);
            this.lblMusicFolderPath.TabIndex = 4;
            this.lblMusicFolderPath.Text = "MusicFolderPath";
            // 
            // edSSHHost
            // 
            this.edSSHHost.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edSSHHost.Location = new System.Drawing.Point(10, 176);
            this.edSSHHost.Name = "edSSHHost";
            this.edSSHHost.Size = new System.Drawing.Size(403, 20);
            this.edSSHHost.TabIndex = 7;
            // 
            // lblSSHHost
            // 
            this.lblSSHHost.AutoSize = true;
            this.lblSSHHost.Location = new System.Drawing.Point(10, 159);
            this.lblSSHHost.Name = "lblSSHHost";
            this.lblSSHHost.Size = new System.Drawing.Size(51, 13);
            this.lblSSHHost.TabIndex = 6;
            this.lblSSHHost.Text = "SSHHost";
            // 
            // edSSHUsr
            // 
            this.edSSHUsr.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edSSHUsr.Location = new System.Drawing.Point(10, 228);
            this.edSSHUsr.Name = "edSSHUsr";
            this.edSSHUsr.Size = new System.Drawing.Size(403, 20);
            this.edSSHUsr.TabIndex = 9;
            // 
            // lblSSHUsr
            // 
            this.lblSSHUsr.AutoSize = true;
            this.lblSSHUsr.Location = new System.Drawing.Point(10, 211);
            this.lblSSHUsr.Name = "lblSSHUsr";
            this.lblSSHUsr.Size = new System.Drawing.Size(45, 13);
            this.lblSSHUsr.TabIndex = 8;
            this.lblSSHUsr.Text = "SSHUsr";
            // 
            // edSSHPwd
            // 
            this.edSSHPwd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edSSHPwd.Location = new System.Drawing.Point(10, 274);
            this.edSSHPwd.Name = "edSSHPwd";
            this.edSSHPwd.Size = new System.Drawing.Size(403, 20);
            this.edSSHPwd.TabIndex = 11;
            // 
            // lblSSHPwd
            // 
            this.lblSSHPwd.AutoSize = true;
            this.lblSSHPwd.Location = new System.Drawing.Point(10, 257);
            this.lblSSHPwd.Name = "lblSSHPwd";
            this.lblSSHPwd.Size = new System.Drawing.Size(50, 13);
            this.lblSSHPwd.TabIndex = 10;
            this.lblSSHPwd.Text = "SSHPwd";
            // 
            // lblIceCast
            // 
            this.lblIceCast.AutoSize = true;
            this.lblIceCast.Location = new System.Drawing.Point(4, 11);
            this.lblIceCast.Name = "lblIceCast";
            this.lblIceCast.Size = new System.Drawing.Size(46, 13);
            this.lblIceCast.TabIndex = 0;
            this.lblIceCast.Text = "IceCast:";
            // 
            // lblEZStream
            // 
            this.lblEZStream.AutoSize = true;
            this.lblEZStream.Location = new System.Drawing.Point(3, 45);
            this.lblEZStream.Name = "lblEZStream";
            this.lblEZStream.Size = new System.Drawing.Size(57, 13);
            this.lblEZStream.TabIndex = 4;
            this.lblEZStream.Text = "EZStream:";
            // 
            // btnEZStreamRestart
            // 
            this.btnEZStreamRestart.Location = new System.Drawing.Point(247, 40);
            this.btnEZStreamRestart.Name = "btnEZStreamRestart";
            this.btnEZStreamRestart.Size = new System.Drawing.Size(90, 23);
            this.btnEZStreamRestart.TabIndex = 7;
            this.btnEZStreamRestart.Text = "Restart";
            this.btnEZStreamRestart.UseVisualStyleBackColor = true;
            this.btnEZStreamRestart.Click += new System.EventHandler(this.btnEZStreamRestart_Click);
            // 
            // btnIceCastRestart
            // 
            this.btnIceCastRestart.Location = new System.Drawing.Point(247, 11);
            this.btnIceCastRestart.Name = "btnIceCastRestart";
            this.btnIceCastRestart.Size = new System.Drawing.Size(90, 23);
            this.btnIceCastRestart.TabIndex = 3;
            this.btnIceCastRestart.Text = "Restart";
            this.btnIceCastRestart.UseVisualStyleBackColor = true;
            this.btnIceCastRestart.Click += new System.EventHandler(this.btnIceCastRestart_Click);
            // 
            // btnFullRestart
            // 
            this.btnFullRestart.Enabled = false;
            this.btnFullRestart.Location = new System.Drawing.Point(341, 23);
            this.btnFullRestart.Name = "btnFullRestart";
            this.btnFullRestart.Size = new System.Drawing.Size(61, 35);
            this.btnFullRestart.TabIndex = 8;
            this.btnFullRestart.Text = "Full Restart";
            this.btnFullRestart.UseVisualStyleBackColor = true;
            this.btnFullRestart.Click += new System.EventHandler(this.btnFullRestart_Click);
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 337);
            this.Controls.Add(this.tabCtrl);
            this.Name = "MainFrm";
            this.Text = "IceCast / EZ Stream manager";
            this.Load += new System.EventHandler(this.MainFrm_Load);
            this.tabCtrl.ResumeLayout(false);
            this.tabManage.ResumeLayout(false);
            this.tabManage.PerformLayout();
            this.tabSettings.ResumeLayout(false);
            this.tabSettings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabCtrl;
        private System.Windows.Forms.TabPage tabManage;
        private System.Windows.Forms.TabPage tabSettings;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.Button btnNextTrack;
        private System.Windows.Forms.Button btnSwitchPlayList;
        private System.Windows.Forms.Button btnStartEZStream;
        private System.Windows.Forms.Button btnStopEZStream;
        private System.Windows.Forms.Button btnStartIceCast;
        private System.Windows.Forms.Button btnStopIceCast;
        private System.Windows.Forms.TextBox edSSHUsr;
        private System.Windows.Forms.Label lblSSHUsr;
        private System.Windows.Forms.TextBox edSSHHost;
        private System.Windows.Forms.Label lblSSHHost;
        private System.Windows.Forms.TextBox edMusicFolderPath;
        private System.Windows.Forms.Label lblMusicFolderPath;
        private System.Windows.Forms.TextBox edEZStreamRemotePath;
        private System.Windows.Forms.Label lblEZStreamRemotePath;
        private System.Windows.Forms.TextBox edIceCastRemotePath;
        private System.Windows.Forms.Label lblIceCastRemotePath;
        private System.Windows.Forms.TextBox edSSHPwd;
        private System.Windows.Forms.Label lblSSHPwd;
        private System.Windows.Forms.Label lblEZStream;
        private System.Windows.Forms.Label lblIceCast;
        private System.Windows.Forms.Button btnEZStreamRestart;
        private System.Windows.Forms.Button btnIceCastRestart;
        private System.Windows.Forms.Button btnFullRestart;
    }
}

