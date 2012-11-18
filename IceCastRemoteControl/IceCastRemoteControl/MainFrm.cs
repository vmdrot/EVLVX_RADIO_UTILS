using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Evolvex.RadioVolya.IceCastRemoteControlLib;

namespace IceCastRemoteControl
{
    public partial class MainFrm : Form
    {
        #region cctor(s)
        public MainFrm()
        {
            InitializeComponent();
        }
        #endregion

        #region business field(s)
        private RadioRemoteManager _mgr;
        #endregion
        #region prop(s)
        private RadioRemoteManager Mgr
        {
            get
            {
                if (_mgr == null)
                {
                    _mgr = new RadioRemoteManager();
                    _mgr.CommandStart += new EventHandler<CommandSendArgs>(RCM_CommandStart);
                    _mgr.CommandCompleted += new EventHandler<CommandCompletedArgs>(RCM_CommandCompleted);
                }
                return _mgr;
            }
        }
        #endregion

        #region control evt handler(s)
        private void btnStopIceCast_Click(object sender, EventArgs e)
        {
            DoStopIceCast();
        }

        private void btnStartIceCast_Click(object sender, EventArgs e)
        {
            DoStartIceCast();
        }

        private void btnStopEZStream_Click(object sender, EventArgs e)
        {
            DoStopEZStream();
        }

        private void btnStartEZStream_Click(object sender, EventArgs e)
        {
            DoStartEZStream();
        }

        private void btnSwitchPlayList_Click(object sender, EventArgs e)
        {
            DoSwitchPlayList();
        }

        private void btnNextTrack_Click(object sender, EventArgs e)
        {
            DoNextTrack();
        }

        private void btnIceCastRestart_Click(object sender, EventArgs e)
        {
            DoStopIceCast();
            DoStartIceCast();
        }

        private void btnEZStreamRestart_Click(object sender, EventArgs e)
        {
            DoStopEZStream();
            DoStartEZStream();
        }

        private void btnFullRestart_Click(object sender, EventArgs e)
        {
            DoStopEZStream();
            DoStopIceCast();
            DoStartIceCast();
            DoStopEZStream();
        }

        private void MainFrm_Load(object sender, EventArgs e)
        {
            InitControls();
        }

        private void RCM_CommandCompleted(object sender, CommandCompletedArgs e)
        {
            StringBuilder msg = new StringBuilder();
            msg.AppendLine(String.Format("Command: {0}", e.Cmd));
            msg.AppendLine(String.Format("Started: {0}", e.Started));
            msg.AppendLine(String.Format("Finished: {0}", e.Finished));
            msg.AppendLine(String.Format("Duration: {0}", e.Duration));
            txtOutput.Text = msg.ToString();
        }

        private void RCM_CommandStart(object sender, CommandSendArgs e)
        {
            txtOutput.Text = String.Format("Command started: {0}", e.Cmd);
        }
        #endregion


        #region misc method(s)
        private void InitControls()
        {
            BindSettingsTab(Mgr.Settings);
        }

        private void BindSettingsTab(RemoteControlParameters settings)
        {
            edIceCastRemotePath.Text = settings.IceCastRemotePath;
            edEZStreamRemotePath.Text = settings.EZStreamRemotePath;
            edMusicFolderPath.Text = settings.MusicFolderPath;
            edSSHHost.Text = settings.SSHHost;
            edSSHPwd.Text = settings.SSHPwd;
            edSSHUsr.Text = settings.SSHUsr;
        }

        private void SerializeSettingsTabUI(RemoteControlParameters settings)
        {
            settings.IceCastRemotePath = edIceCastRemotePath.Text;
            settings.EZStreamRemotePath = edEZStreamRemotePath.Text;
            settings.MusicFolderPath = edMusicFolderPath.Text;
            settings.SSHHost = edSSHHost.Text;
            settings.SSHPwd = edSSHPwd.Text;
            settings.SSHUsr = edSSHUsr.Text;
        }

        private void DoSendCommandCommon()
        {
            SerializeSettingsTabUI(Mgr.Settings);
        }


        private void DoStopIceCast()
        {
            DoSendCommandCommon();
            Mgr.StopIceCast();
        }

        private void DoStartIceCast()
        {
            DoSendCommandCommon();
            Mgr.StartIceCast();
        }

        private void DoStopEZStream()
        {
            DoSendCommandCommon();
            Mgr.StopEZStream();
        }

        private void DoStartEZStream()
        {
            DoSendCommandCommon();
            Mgr.StartEZStream();
        }

        private void DoSwitchPlayList()
        {
            DoSendCommandCommon();
            Mgr.SwitchPlayList();
        }

        private void DoNextTrack()
        {
            DoSendCommandCommon();
            Mgr.NextTrack();
        }
        #endregion

    }
}
