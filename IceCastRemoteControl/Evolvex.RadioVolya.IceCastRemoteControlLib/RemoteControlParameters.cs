using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evolvex.RadioVolya.IceCastRemoteControlLib
{
    public class RemoteControlParameters
    {
        public String IceCastRemotePath { get; set; }
        public String EZStreamRemotePath { get; set; }
        public String MusicFolderPath { get; set; }
        public String SSHHost { get; set; }
        public String SSHUsr { get; set; }
        public String SSHPwd { get; set; }
        public String StopIceCastCommandText { get; set; }
        public String StartIceCastCommandText { get; set; }
        public String StopEZStreamCommandText { get; set; }
        public String StartEZStreamCommandText { get; set; }
        public String SwitchPlayListCommandText { get; set; }
        public String NextTrackCommandText { get; set; }
        public String PlinkPath { get; set; }
    }
}
