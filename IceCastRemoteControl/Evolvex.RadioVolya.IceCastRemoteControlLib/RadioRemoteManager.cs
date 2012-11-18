using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Reflection;
using System.IO;

namespace Evolvex.RadioVolya.IceCastRemoteControlLib
{
    public class RadioRemoteManager
    {
        #region config & const-related
        private const string SSH_HOST_CFG_KEY = "sshHost";
        private const string SSH_USR_NM_CFG_KEY = "sshUsr";
        private const string SSH_USR_PWD_CFG_KEY = "sshPwd";
        private const string PLINK_PATH_CFG_KEY = "plinkPath";
        private const string ICE_CAST_REMOTE_PATH_CFG_KEY = "iceCastRemotePath";
        private const string EZSTREAM_REMOTE_PATH_CFG_KEY = "ezstreamRemotePath";
        private const string MUSIC_FOLDER_PATH_CFG_KEY = "musicFolderPath";
        private const string CMD_STOP_ICE_CAST_CFG_KEY = "cmdStopIceCast";
        private const string CMD_START_ICE_CAST_CFG_KEY = "cmdStartIceCast";
        private const string CMD_STOP_EZSTREAM_CFG_KEY = "cmdStopEZStream";
        private const string CMD_START_EZSTREAM_CFG_KEY = "cmdStartEZStream";
        private const string CMD_SWITCH_PLAY_LIST_CFG_KEY = "cmdSwitchPlayList";
        private const string CMD_NEXT_TRACK_CFG_KEY = "cmdNextTrack";
        public static readonly RemoteControlParameters DEFAULT_PARAMS;
        #endregion

        #region field(s)
        private PuttyDriver _drv;
        #endregion

        #region cctor(s)
        static RadioRemoteManager()
        {
            DEFAULT_PARAMS = new RemoteControlParameters();
            Configuration cfg = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (cfg == null)
                return;
            if (cfg.AppSettings.Settings[SSH_HOST_CFG_KEY] != null)
                DEFAULT_PARAMS.SSHHost = cfg.AppSettings.Settings[SSH_HOST_CFG_KEY].Value.Trim();

            if (cfg.AppSettings.Settings[SSH_USR_NM_CFG_KEY] != null)
                DEFAULT_PARAMS.SSHUsr = cfg.AppSettings.Settings[SSH_USR_NM_CFG_KEY].Value.Trim();

            if (cfg.AppSettings.Settings[SSH_USR_PWD_CFG_KEY] != null)
                DEFAULT_PARAMS.SSHPwd = cfg.AppSettings.Settings[SSH_USR_PWD_CFG_KEY].Value.Trim();

            if (cfg.AppSettings.Settings[ICE_CAST_REMOTE_PATH_CFG_KEY] != null)
                DEFAULT_PARAMS.IceCastRemotePath = cfg.AppSettings.Settings[ICE_CAST_REMOTE_PATH_CFG_KEY].Value.Trim();

            if (cfg.AppSettings.Settings[EZSTREAM_REMOTE_PATH_CFG_KEY] != null)
                DEFAULT_PARAMS.EZStreamRemotePath = cfg.AppSettings.Settings[EZSTREAM_REMOTE_PATH_CFG_KEY].Value.Trim();

            if (cfg.AppSettings.Settings[MUSIC_FOLDER_PATH_CFG_KEY] != null)
                DEFAULT_PARAMS.MusicFolderPath = cfg.AppSettings.Settings[MUSIC_FOLDER_PATH_CFG_KEY].Value.Trim();

            if (cfg.AppSettings.Settings[CMD_STOP_ICE_CAST_CFG_KEY] != null)
                DEFAULT_PARAMS.StopIceCastCommandText = cfg.AppSettings.Settings[CMD_STOP_ICE_CAST_CFG_KEY].Value.Trim();

            if (cfg.AppSettings.Settings[CMD_START_ICE_CAST_CFG_KEY] != null)
                DEFAULT_PARAMS.StartIceCastCommandText = cfg.AppSettings.Settings[CMD_START_ICE_CAST_CFG_KEY].Value.Trim();

            if (cfg.AppSettings.Settings[CMD_STOP_EZSTREAM_CFG_KEY] != null)
                DEFAULT_PARAMS.StopEZStreamCommandText = cfg.AppSettings.Settings[CMD_STOP_EZSTREAM_CFG_KEY].Value.Trim();

            if (cfg.AppSettings.Settings[CMD_START_EZSTREAM_CFG_KEY] != null)
                DEFAULT_PARAMS.StartEZStreamCommandText = cfg.AppSettings.Settings[CMD_START_EZSTREAM_CFG_KEY].Value.Trim();

            if (cfg.AppSettings.Settings[CMD_SWITCH_PLAY_LIST_CFG_KEY] != null)
                DEFAULT_PARAMS.SwitchPlayListCommandText = cfg.AppSettings.Settings[CMD_SWITCH_PLAY_LIST_CFG_KEY].Value.Trim();

            if (cfg.AppSettings.Settings[CMD_NEXT_TRACK_CFG_KEY] != null)
                DEFAULT_PARAMS.NextTrackCommandText = cfg.AppSettings.Settings[CMD_NEXT_TRACK_CFG_KEY].Value.Trim();

            if (cfg.AppSettings.Settings[PLINK_PATH_CFG_KEY] != null)
                DEFAULT_PARAMS.PlinkPath = cfg.AppSettings.Settings[PLINK_PATH_CFG_KEY].Value.Trim();
            else
            { 
                DEFAULT_PARAMS.PlinkPath = Path.Combine( Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "plink.exe");
            }
        }

        public RadioRemoteManager()
        {
            this.Settings = DEFAULT_PARAMS;
        }
        #endregion

        #region prop(s)
        public RemoteControlParameters Settings { get; set; }
        private PuttyDriver Drv
        {
            get
            {
                if (_drv == null)
                { 
                    ConnectionParams cnnPrms = new ConnectionParams();
                    cnnPrms.Host = Settings.SSHHost;
                    cnnPrms.User = Settings.SSHUsr;
                    cnnPrms.Password = Settings.SSHPwd;
                    _drv = new PuttyDriver(Settings.PlinkPath, cnnPrms);
                    _drv.CommandStart += new EventHandler<CommandSendArgs>(PuttyDriver_CommandStart);
                    _drv.CommandCompleted += new EventHandler<CommandCompletedArgs>(PuttyDriver_CommandCompleted);
                }
                return _drv;
            }
        }
        #endregion

        #region method(s)
        public void StopIceCast()
        {
            Drv.Cmd2(Settings.StopIceCastCommandText);
        }

        public void StartIceCast()
        {
            Drv.Cmd2(String.Format(Settings.StartIceCastCommandText, Settings.IceCastRemotePath));
        }

        public void StopEZStream()
        {
            Drv.Cmd2(Settings.StopEZStreamCommandText);
        }

        public void StartEZStream()
        {
            Drv.Cmd2(String.Format(Settings.StartEZStreamCommandText, Settings.EZStreamRemotePath));
        }

        public void SwitchPlayList()
        {
            Drv.Cmd2(Settings.SwitchPlayListCommandText);
        }

        public void NextTrack()
        {
            Drv.Cmd2(Settings.NextTrackCommandText);
        }
        #endregion

        #region event(s)-related
        public event EventHandler<CommandSendArgs> CommandStart;
        public event EventHandler<CommandCompletedArgs> CommandCompleted;

        private void PuttyDriver_CommandCompleted(object sender, CommandCompletedArgs e)
        {
            if (this.CommandCompleted != null)
                this.CommandCompleted(sender, e);
        }

        private void PuttyDriver_CommandStart(object sender, CommandSendArgs e)
        {
            if (this.CommandStart != null)
                this.CommandStart(sender, e);
        }
        #endregion

    }
}
