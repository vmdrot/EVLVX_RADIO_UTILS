using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using SitesDownloaderLib;
using System.IO;

namespace SitesDownloaderLibTester
{
    [TestFixture]
    public class LinksListDownloaderTests
    {
        [Test]
        public void Explore()
        {
            LinksListDownloader lld = new LinksListDownloader();
            lld.SaveToRoot = @"D:\tmp\dev\tests\SiteDownloader\filesua";
            lld.ContinueOnErrors = true;
            lld.CutOffLevels = 1;
            lld.DecodeUrls = true;
            #region list formation
            List<String> lst=  new List<string>();
            lst.Add("http://ukraine.ukrweb.net/%d0%a3%d0%ba%d1%80%d0%b0%d1%97%d0%bd%d1%81%d1%8c%d0%ba%d0%b0%20%d0%bc%d1%83%d0%b7%d0%b8%d0%ba%d0%b0/%d0%86/%d0%86%d0%b3%d1%80%d0%b0%d1%88%d0%ba%d0%b8%20-%20%d0%a6%d0%b5%20%d0%bc%d0%be%d1%8f%20%d0%a3%d0%ba%d1%80%d0%b0i%d0%bd%d0%b0.mp3");
            lst.Add("http://ukraine.ukrweb.net/%d0%a3%d0%ba%d1%80%d0%b0%d1%97%d0%bd%d1%81%d1%8c%d0%ba%d0%b0%20%d0%bc%d1%83%d0%b7%d0%b8%d0%ba%d0%b0/%d0%86/%d0%86%d0%b4%d0%b5%d0%b0%d0%bb%d1%8c%d0%bd%d0%b8%d0%b9%20%d0%91%d0%b5%d0%b7%d0%bf%d0%be%d1%80%d1%8f%d0%b4%d0%be%d0%ba%20-%20%d0%9c%d0%be%d1%97%20%d1%81%d0%bb%d0%be%d0%b2%d0%b0.mp3");
            lst.Add("http://ukraine.ukrweb.net/%d0%a3%d0%ba%d1%80%d0%b0%d1%97%d0%bd%d1%81%d1%8c%d0%ba%d0%b0%20%d0%bc%d1%83%d0%b7%d0%b8%d0%ba%d0%b0/%d0%86/%d0%86%d0%bd%d0%bd%d0%b0%20-%20Trixter.mp3");
            #endregion
            DateTime dtStart = DateTime.Now;
            Console.WriteLine(lld.DownloadList(lst, false));
            DateTime dtEnd = DateTime.Now;
            Console.WriteLine("Completed in {0}", (TimeSpan)(dtEnd - dtStart));
            PrintDict(lld.Errors);
        }


        private void PrintDict(Dictionary<string, string> dict)
        {
            if (dict == null || dict.Count == 0)
                return;
            const string delim = "---------------------------------------------------------------------------------------------------------";
            Console.WriteLine(delim);
            foreach (string url in dict.Keys)
            {
                Console.WriteLine("[{0}] {1}", url, dict[url]);
                Console.WriteLine(delim);
            }
        }

        public void TestWorker(String lstPath)
        {
            LinksListDownloader lld = new LinksListDownloader();
            lld.SaveToRoot = @"D:\tmp\dev\tests\SiteDownloader\filesua";
            lld.ContinueOnErrors = true;
            lld.CutOffLevels = 1;
            lld.DecodeUrls = true;
            lld.OverwriteExistingFiles = false;
            List<String> lst = new List<string>(File.ReadAllLines(lstPath));
            DateTime dtStart = DateTime.Now;
            Console.WriteLine(lld.DownloadList(lst, false));
            DateTime dtEnd = DateTime.Now;
            Console.WriteLine("Completed in {0}", (TimeSpan)(dtEnd - dtStart));
            PrintDict(lld.Errors);
        }

        [Test]
        public void DownloadS()
        {
            TestWorker(@"D:\tmp\dev\tests\SiteDownloader\filesua.lst.S.txt");
        }

    }
}
