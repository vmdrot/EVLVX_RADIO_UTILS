using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evolvex.RadioVolya.IceCastRemoteControlLib
{
    public class CommandCompletedArgs : CommandSendArgs
    {
        public DateTime Started { get; private set; }
        public DateTime Finished { get; private set; }
        public TimeSpan Duration { get; private set; }

        public CommandCompletedArgs(String cmdTxt, DateTime started, DateTime finished) :base(cmdTxt)
        {
            this.Started = started;
            this.Finished = finished;
            this.Duration = (TimeSpan)(this.Finished - this.Started);
        }
    }
}
