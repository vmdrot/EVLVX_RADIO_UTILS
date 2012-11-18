using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using SitesDownloaderLib;

namespace SitesDownloaderLibTester
{
    [TestFixture]
    public class SiteLinksCrawlerTests
    {
        [Test]
        public void testS()
        {
            TestWorker("http://files.ukraine.ck.ua/%d0%a3%d0%ba%d1%80%d0%b0%d1%97%d0%bd%d1%81%d1%8c%d0%ba%d0%b0%20%d0%bc%d1%83%d0%b7%d0%b8%d0%ba%d0%b0/%d0%a1/");
        }

        [Test]
        public void testSky()
        {
            TestWorker("http://files.ukraine.ck.ua/%d0%a3%d0%ba%d1%80%d0%b0%d1%97%d0%bd%d1%81%d1%8c%d0%ba%d0%b0%20%d0%bc%d1%83%d0%b7%d0%b8%d0%ba%d0%b0/%d0%a1/%d0%a1%d0%ba%d0%b0%d0%b9/");
        }
        [Test]
        public void testAll()
        {
            TestWorker("http://files.ukraine.ck.ua/%d0%a3%d0%ba%d1%80%d0%b0%d1%97%d0%bd%d1%81%d1%8c%d0%ba%d0%b0%20%d0%bc%d1%83%d0%b7%d0%b8%d0%ba%d0%b0/");
        }
        
        private void TestWorker(String rootUrl)
        {
            DateTime dtStarted = DateTime.Now;
            SiteLinksCrawler slc = new SiteLinksCrawler();
            slc.ContinueOnErrors = true;
            slc.BuildDownloadList(rootUrl);
            DateTime dtFinished = DateTime.Now;
            Console.WriteLine("Time taken - {0}", (TimeSpan)(dtFinished - dtStarted));
            Console.WriteLine("Count = {0}", slc.DownloadList.Count);
            Console.WriteLine("Errors.Count = {0}", slc.Errors.Count);
            PrintArray(slc.DownloadList);
            PrintDict(slc.Errors);
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

        private void PrintArray(List<string> dirs)
        {
            foreach (string dir in dirs)
            {
                Console.WriteLine(dir);
            }
        }

    }
}
