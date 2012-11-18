using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Evolvex.RadioVolya.IceCastRemoteControlLib;

namespace Evolvex.RadioVolya.IceCastRemoteControlLibTests
{
    [TestFixture]
    public class PuttyDriverTest
    {

        [Test]
        public void Ls()
        { 
            ConnectionParams cnnPrms = new ConnectionParams();
            cnnPrms.Host = "88.208.220.69";
            cnnPrms.User = "root";
            cnnPrms.Password = "Y5x7z7V5c";
            PuttyDriver drv = new PuttyDriver(@"c:\Install\Putty\plink.exe", cnnPrms);
            ProcessOutput rslt = drv.Cmd("ls");
            Console.WriteLine(rslt.ToString());
        }

        [Test]
        public void Ls2File()
        {
            ConnectionParams cnnPrms = new ConnectionParams();
            cnnPrms.Host = "88.208.220.69";
            cnnPrms.User = "root";
            cnnPrms.Password = "Y5x7z7V5c";
            PuttyDriver drv = new PuttyDriver(@"c:\Install\Putty\plink.exe", cnnPrms);
            ProcessOutput rslt = drv.Cmd("ls > ls_dir2.txt");
            Console.WriteLine(rslt.ToString());
        }

        [Test]
        public void Ls22File()
        {
            ConnectionParams cnnPrms = new ConnectionParams();
            cnnPrms.Host = "88.208.220.69";
            cnnPrms.User = "root";
            cnnPrms.Password = "Y5x7z7V5c";
            PuttyDriver drv = new PuttyDriver(@"c:\Install\Putty\plink.exe", cnnPrms);
            Console.WriteLine(drv.Cmd2("ls > /tmp/ls_dir2.txt"));
        }

        [Test]
        public void Ls2()
        {
            ConnectionParams cnnPrms = new ConnectionParams();
            cnnPrms.Host = "88.208.220.69";
            cnnPrms.User = "root";
            cnnPrms.Password = "Y5x7z7V5c";
            PuttyDriver drv = new PuttyDriver(@"c:\Install\Putty\plink.exe", cnnPrms);
            Console.WriteLine(drv.Cmd2("ls"));
        }

        [Test]
        public void CmdIpCfg()
        {
            PuttyDriver drv = new PuttyDriver("", null);
            Console.WriteLine(drv.Cmd3("ipconfig -all"));
        }

        [Test]
        public void CmdHelp()
        {
            PuttyDriver drv = new PuttyDriver("", null);
            Console.WriteLine(drv.Cmd3("help"));
        }

        [Test]
        public void CmdLs()
        {
            PuttyDriver drv = new PuttyDriver("", null);
            Console.WriteLine(drv.Cmd3(@"c:\Install\Putty\plink.exe 88.208.220.69 -l root -pw Y5x7z7V5c ls"));
        }

        [Test]
        public void CmdPingGoogle()
        {
            PuttyDriver drv = new PuttyDriver("", null);
            Console.WriteLine(drv.Cmd3("ping google.com"));
        }
    }
}
