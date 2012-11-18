using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evolvex.RadioVolya.IceCastRemoteControlLib
{
    public class CommandSendArgs : EventArgs
    {
        public String Cmd { get; private set; }

        public CommandSendArgs(String cmdTxt) : base()
        {
            this.Cmd = cmdTxt;
        }
    }
}
