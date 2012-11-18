using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using HtmlAgilityPack;
using System.Security.Policy;

namespace SitesDownloaderLib
{
    public class SiteLinksCrawler
    {
        #region prop(s)
        public List<String> DownloadList { get; private set; }
        public bool ContinueOnErrors { get; set; }
        public Dictionary<String, String> Errors { get; private set; }
        #endregion

        #region cctor(s)
        public SiteLinksCrawler()
        {
            this.DownloadList = new List<string>();
            this.Errors = new Dictionary<string, string>();
            this.ContinueOnErrors = false;
        }
        #endregion

        #region method(s)
        public void BuildDownloadList(String rootUrl)
        {
            DownloadParseDirWorker(rootUrl);
        }


        private void DownloadParseDirWorker(String url)
        {
            try
            {
                using (WebClient wc = new WebClient())
                {
                    String html = wc.DownloadString(url);
                    HtmlDocument doc = new HtmlDocument();
                    doc.LoadHtml(html);
                    HtmlNode tbl = doc.DocumentNode.ChildNodes.FindFirst("table");
                    if (tbl == null)
                        return;
                    List<HtmlNode> tds = new List<HtmlNode>(tbl.ChildNodes.Elements("td"));
                    const String alt_dir = "[DIR]";
                    const string alt_mp3 = "[SND]";
                    const string back_src = "back.gif";
                    string lastAlt = string.Empty;
                    string lstSrc = string.Empty;
                    List<String> dirs = new List<String>();
                    List<String> mp3s = new List<String>();
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
                    foreach (String mp3 in mp3s)
                    {
                        Uri mp3Uri = new Uri(mp3, UriKind.RelativeOrAbsolute);
                        String mp3AbsUrl = mp3Uri.IsAbsoluteUri ? mp3 : (url + mp3);

                        DownloadList.Add(mp3AbsUrl);
                    }
                    foreach (String dir in dirs)
                    {
                        Uri uri = new Uri(dir, UriKind.RelativeOrAbsolute);
                        String absUrl = uri.IsAbsoluteUri ? dir : (url + dir);
                        DownloadParseDirWorker(absUrl);
                    }
                }
            }
            catch (Exception exc)
            {
                if (!ContinueOnErrors)
                    throw;
                Errors.Add(url, exc.ToString());
            }
        }
        #endregion
    }
}
