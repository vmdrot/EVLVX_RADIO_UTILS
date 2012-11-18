namespace FilesFolderLatinizerUI
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
            this.lblRootFolder = new System.Windows.Forms.Label();
            this.edRootDir = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtCMDs = new System.Windows.Forms.TextBox();
            this.chkEmulate = new System.Windows.Forms.CheckBox();
            this.folderBrowserDlg = new System.Windows.Forms.FolderBrowserDialog();
            this.chkContinueOnErrors = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lblRootFolder
            // 
            this.lblRootFolder.AutoSize = true;
            this.lblRootFolder.Location = new System.Drawing.Point(3, 9);
            this.lblRootFolder.Name = "lblRootFolder";
            this.lblRootFolder.Size = new System.Drawing.Size(62, 13);
            this.lblRootFolder.TabIndex = 0;
            this.lblRootFolder.Text = "Root folder:";
            // 
            // edRootDir
            // 
            this.edRootDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edRootDir.Location = new System.Drawing.Point(72, 9);
            this.edRootDir.Name = "edRootDir";
            this.edRootDir.Size = new System.Drawing.Size(317, 20);
            this.edRootDir.TabIndex = 1;
            this.edRootDir.Text = "d:\\mp3";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowse.Location = new System.Drawing.Point(395, 6);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "Bro&wse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(314, 36);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(395, 36);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Can&cel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtCMDs
            // 
            this.txtCMDs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCMDs.Location = new System.Drawing.Point(13, 63);
            this.txtCMDs.Multiline = true;
            this.txtCMDs.Name = "txtCMDs";
            this.txtCMDs.ReadOnly = true;
            this.txtCMDs.Size = new System.Drawing.Size(468, 199);
            this.txtCMDs.TabIndex = 7;
            // 
            // chkEmulate
            // 
            this.chkEmulate.AutoSize = true;
            this.chkEmulate.Location = new System.Drawing.Point(72, 36);
            this.chkEmulate.Name = "chkEmulate";
            this.chkEmulate.Size = new System.Drawing.Size(85, 17);
            this.chkEmulate.TabIndex = 3;
            this.chkEmulate.Text = "e&mulate only";
            this.chkEmulate.UseVisualStyleBackColor = true;
            // 
            // folderBrowserDlg
            // 
            this.folderBrowserDlg.Description = "Browse for the root folder to start from";
            this.folderBrowserDlg.RootFolder = System.Environment.SpecialFolder.MyComputer;
            this.folderBrowserDlg.ShowNewFolderButton = false;
            // 
            // chkContinueOnErrors
            // 
            this.chkContinueOnErrors.AutoSize = true;
            this.chkContinueOnErrors.Checked = true;
            this.chkContinueOnErrors.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkContinueOnErrors.Location = new System.Drawing.Point(163, 36);
            this.chkContinueOnErrors.Name = "chkContinueOnErrors";
            this.chkContinueOnErrors.Size = new System.Drawing.Size(117, 17);
            this.chkContinueOnErrors.TabIndex = 4;
            this.chkContinueOnErrors.Text = "con&tinue on error(s)";
            this.chkContinueOnErrors.UseVisualStyleBackColor = true;
            // 
            // MainFrm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(482, 263);
            this.Controls.Add(this.chkContinueOnErrors);
            this.Controls.Add(this.chkEmulate);
            this.Controls.Add(this.txtCMDs);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.edRootDir);
            this.Controls.Add(this.lblRootFolder);
            this.Name = "MainFrm";
            this.Text = "Files and folders names latinizer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRootFolder;
        private System.Windows.Forms.TextBox edRootDir;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtCMDs;
        private System.Windows.Forms.CheckBox chkEmulate;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDlg;
        private System.Windows.Forms.CheckBox chkContinueOnErrors;
    }
}

