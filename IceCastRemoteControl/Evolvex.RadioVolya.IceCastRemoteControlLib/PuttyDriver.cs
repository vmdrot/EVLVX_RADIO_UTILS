using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;

namespace Evolvex.RadioVolya.IceCastRemoteControlLib
{
    public class PuttyDriver
    {
        private readonly string _plinkPath;
        private readonly ConnectionParams _connectionParams;
        private volatile StringBuilder lastShellOutput;
        public event EventHandler<CommandSendArgs> CommandStart;
        public event EventHandler<CommandCompletedArgs> CommandCompleted;
        private DateTime _lastCommandStart;
        private DateTime _lastCommandFinish;

        public PuttyDriver(String plinkPath, ConnectionParams cnnPrms)
        {
            _plinkPath = plinkPath;
            _connectionParams = cnnPrms;
        }

        private String FormCommandLine(String cmdPure)
        {
            return String.Format("{0} -l \"{1}\" -pw \"{2}\" \"{3}\"", _connectionParams.Host, _connectionParams.User, _connectionParams.Password, cmdPure);
        }


        private String FormCommandLine(String cmdPure, out String redirPath)
        {
            redirPath = Path.Combine(Path.GetTempPath(), GenerateRandomFileName());
            return String.Format("{0} -l \"{1}\" -pw \"{2}\" \"{3}\" > \"{4}\"", _connectionParams.Host, _connectionParams.User, _connectionParams.Password, cmdPure, redirPath);
        }

        private string GenerateRandomFileName()
        {
            return "ptdrvtmp.tmp";//todo
        }

        public ProcessOutput Cmd(String cmd)
        {
            
            ProcessStartInfo psi = new ProcessStartInfo(_plinkPath);
            psi.Arguments = FormCommandLine(cmd);
            psi.CreateNoWindow = true;
            psi.UseShellExecute = false;
            //pinfo.WorkingDirectory = ?
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;

            _lastCommandStart = DateTime.Now;
            System.Diagnostics.Process ps = System.Diagnostics.Process.Start(psi);
            RaiseCommandStart(cmd);
            ps.WaitForExit();
            ProcessOutput rslt = new ProcessOutput();
            using (System.IO.StreamReader myOutput = ps.StandardOutput)
            {
                rslt.StdOut = myOutput.ReadToEnd();
            }
            using (System.IO.StreamReader myError = ps.StandardError)
            {
                rslt.StdErr = myError.ReadToEnd();

            }
            _lastCommandFinish = DateTime.Now;
            RaiseCommandCompleted(cmd);
            return rslt;
        }

        private void RaiseCommandCompleted(string cmd)
        {
            if(CommandCompleted != null)
                CommandCompleted(this, new CommandCompletedArgs(cmd, _lastCommandStart, _lastCommandFinish));
        }

        private void RaiseCommandStart(string cmd)
        {
            if (CommandStart != null)
                CommandStart(this, new CommandSendArgs(cmd));
        }

        public String Cmd2(String cmd)
        {

            ProcessStartInfo psi = new ProcessStartInfo(_plinkPath);
            String redirPath = string.Empty;
            psi.Arguments = FormCommandLine(cmd);
            psi.WindowStyle = ProcessWindowStyle.Normal;
            psi.UseShellExecute = true;
            _lastCommandStart = DateTime.Now;
            RaiseCommandStart(cmd);
            System.Diagnostics.Process ps = System.Diagnostics.Process.Start(psi);
            ps.WaitForExit();
            _lastCommandFinish = DateTime.Now;
            RaiseCommandCompleted(cmd);
            if (String.IsNullOrEmpty(redirPath) || !File.Exists(redirPath))
                return string.Empty;
            String rslt = File.ReadAllText(redirPath);
            File.Delete(redirPath);
            return rslt;
        }

        public String Cmd3(String cmdLn)
        {

            lastShellOutput = new StringBuilder();
            LaunchCommandAsProcess cmd = new LaunchCommandAsProcess();
            cmd.OutputReceived +=new LaunchCommandAsProcess.OutputEventHandler(cmd_OutputReceived);
            cmd.SendCommand(cmdLn);
            cmd.SyncClose();

            return lastShellOutput.ToString();
        }

        private void cmd_OutputReceived(object sendingProcess, EventArgsForCommand e)
        {
            lastShellOutput.AppendLine(e.OutputData);
        }

    }
}
