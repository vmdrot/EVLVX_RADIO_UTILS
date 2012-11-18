using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evolvex.RadioVolya.IceCastRemoteControlLib
{
    public class ProcessOutput
    {
        public String StdOut { get; set; }
        public String StdErr { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(String.Format("StdOut:'{0}',", StdOut));
            sb.AppendLine(String.Format("StdErr:'{0}'", StdErr));
            return sb.ToString();
        }
    }
}
