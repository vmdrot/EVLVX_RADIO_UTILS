using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using SitesDownloaderLib;

namespace SitesDownloaderLibTester
{
    [TestFixture]
    public class TextFileLinesSlicerTests
    {
        [Test]
        public void test0_10()
        {
            List<String> lns = TextFileLinesSlicer.Slice(@"D:\tmp\dev\tests\SiteDownloader\filesua.lst.S.txt", 0, 10);
            PrintArray(lns);
        }

        [Test]
        public void test90_10()
        {
            List<String> lns = TextFileLinesSlicer.Slice(@"D:\tmp\dev\tests\SiteDownloader\filesua.lst.S.txt", 90, 10);
            PrintArray(lns);
        }
        private void PrintArray(List<string> dirs)
        {
            foreach (string dir in dirs)
            {
                Console.WriteLine(dir);
            }
        }

        [Test]
        public void test3330_1000()
        {
            List<String> lns = TextFileLinesSlicer.Slice(@"D:\tmp\dev\tests\SiteDownloader\filesua.lst.txt", 3329, 1000);
            PrintArray(lns);
        }

        [Test]
        public void test17000_1000()
        {
            List<String> lns = TextFileLinesSlicer.Slice(@"D:\tmp\dev\tests\SiteDownloader\filesua.lst.txt", 17000, 1000);
            PrintArray(lns);
        }
    }
}
