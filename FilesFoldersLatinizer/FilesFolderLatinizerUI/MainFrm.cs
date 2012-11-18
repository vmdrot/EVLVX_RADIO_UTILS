using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using LatinizerLib;

namespace FilesFolderLatinizerUI
{
    public partial class MainFrm : Form
    {
        public MainFrm()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(edRootDir.Text) && Directory.Exists(edRootDir.Text))
                folderBrowserDlg.SelectedPath = edRootDir.Text;
            if (folderBrowserDlg.ShowDialog() != DialogResult.OK)
                return;
            edRootDir.Text = folderBrowserDlg.SelectedPath;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DoTheJob();
        }

        private void DoTheJob()
        {
            Cursor prev = Cursor.Current;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                txtCMDs.Clear();
                Append2Log(FoldersQueuer.PerformFoldersRename(edRootDir.Text, chkEmulate.Checked, chkContinueOnErrors.Checked));
                Append2Log(FoldersQueuer.PerformFilesRename(edRootDir.Text, chkEmulate.Checked, chkContinueOnErrors.Checked));
            }
            catch (Exception exc)
            {
                Append2Log(exc.ToString());
            }
            finally 
            {
                Cursor.Current = prev;
            }
        }


        private void Append2Log(String msg)
        {
            txtCMDs.Text += String.Format("{0}\n", msg);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DoCancel();
        }

        private void DoCancel()
        {
            if (MessageBox.Show("Are you sure you want to cancel?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;
            this.Close();
        }
    }
}
