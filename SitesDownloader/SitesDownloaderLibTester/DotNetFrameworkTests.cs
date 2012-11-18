using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Net;
using HtmlAgilityPack;

namespace SitesDownloaderLibTester
{
    [TestFixture]
    public class DotNetFrameworkTests
    {
        [Test]
        public void DownloadDirTest()
        {
            DownloadDirTestWorker(@"http://files.ukraine.ck.ua/%D0%A3%D0%BA%D1%80%D0%B0%D1%97%D0%BD%D1%81%D1%8C%D0%BA%D0%B0%20%D0%BC%D1%83%D0%B7%D0%B8%D0%BA%D0%B0/");
        }

        [Test]
        public void DownloadDirBTest()
        {
            DownloadDirTestWorker(@"http://files.ukraine.ck.ua/%d0%a3%d0%ba%d1%80%d0%b0%d1%97%d0%bd%d1%81%d1%8c%d0%ba%d0%b0%20%d0%bc%d1%83%d0%b7%d0%b8%d0%ba%d0%b0/%d0%91/");
        }

        [Test]
        public void DownloadParseDirTest()
        {
            DownloadParseDirTestWorker(@"http://files.ukraine.ck.ua/%D0%A3%D0%BA%D1%80%D0%B0%D1%97%D0%BD%D1%81%D1%8C%D0%BA%D0%B0%20%D0%BC%D1%83%D0%B7%D0%B8%D0%BA%D0%B0/");
        }

        [Test]
        public void DownloadParseDirBTest()
        {
            DownloadParseDirTestWorker(@"http://files.ukraine.ck.ua/%d0%a3%d0%ba%d1%80%d0%b0%d1%97%d0%bd%d1%81%d1%8c%d0%ba%d0%b0%20%d0%bc%d1%83%d0%b7%d0%b8%d0%ba%d0%b0/%d0%91/");
        }

        private void DownloadDirTestWorker(String url)
        {
            using (WebClient wc = new WebClient())
            {
                Console.WriteLine(wc.DownloadString(url));
            }
        }

        private void DownloadParseDirTestWorker(String url)
        { 
            using (WebClient wc = new WebClient())
            {
                String html = wc.DownloadString(url);
                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(html);
                HtmlNode tbl = doc.DocumentNode.ChildNodes.FindFirst("table");
                if(tbl == null)
                    return;
                List<HtmlNode> tds = new List<HtmlNode>(tbl.ChildNodes.Elements("td"));
                List<String> dirs = new List<string>();
                List<String> mp3s = new List<String>();
                const String alt_dir = "[DIR]";
                const string alt_mp3 = "[SND]";
                const string back_src = "back.gif";
                string lastAlt = string.Empty;
                string lstSrc = string.Empty;
                foreach (HtmlNode td in tds)
                {
                    List<HtmlNode> imgs = new List<HtmlNode>(td.Elements("img"));
                    if (imgs.Count > 0)
                    {

                        HtmlAttribute altAttr = imgs[0].Attributes["alt"];
                        if (altAttr != null && !String.IsNullOrEmpty(altAttr.Value))
                            lastAlt = altAttr.Value;

                        HtmlAttribute srcAttr = imgs[0].Attributes["src"];
                        if (srcAttr != null && !String.IsNullOrEmpty(srcAttr.Value))
                            lstSrc = srcAttr.Value;

                    }
                    List<HtmlNode> anchors = new List<HtmlNode>(td.Elements("a"));
                    if (anchors.Count == 0)
                        continue;
                    if (lstSrc.ToLower().IndexOf(back_src.ToLower()) != -1)
                        continue;
                    string href = anchors[0].Attributes["href"].Value;
                    if (lastAlt == alt_dir)
                        dirs.Add(href);
                    else if (lastAlt == alt_mp3)
                        mp3s.Add(href);
                }
                Console.WriteLine("dirs = {0}", dirs.Count);
                PrintArray(dirs);
                Console.WriteLine("mp3s = {0}", mp3s.Count);
                PrintArray(mp3s);
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
