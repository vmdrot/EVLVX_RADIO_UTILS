using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Policy;
using System.Web;
using System.IO;
using System.Net;

namespace SitesDownloaderLib
{
    public class LinksListDownloader
    {
        #region prop(s)
        public String SaveToRoot { get; set; }
        public int CutOffLevels { get; set; }
        public bool DecodeUrls { get; set; }
        public bool ContinueOnErrors { get; set; }
        public bool OverwriteExistingFiles { get; set; }
        public Dictionary<String, String> Errors { get; private set; }
        #endregion

        #region cctor(s)
        public LinksListDownloader()
        {
            CutOffLevels = 0;
            DecodeUrls = false;
            ContinueOnErrors = false;
            Errors = new Dictionary<string, string>();
        }
        #endregion

        #region method(s)
        public String DownloadList(List<String> urls, bool emulate)
        {
            StringBuilder rslt = new StringBuilder();
            foreach (String url in urls)
            {
                rslt.AppendLine(DownloadItemWorker(url, emulate));
            }
            return rslt.ToString();
        }

        private String DownloadItemWorker(String url, bool emulate)
        {
            String rslt = string.Empty;
            try
            {
                Uri uri = new Uri(DecodeUrls ? HttpUtility.UrlDecode(url): url);
                String path = DecodeUrls ? HttpUtility.UrlDecode(uri.PathAndQuery) : uri.PathAndQuery;
                String[] aDirs = path.Split('/');
                String saveToDir = SaveToRoot;
                for (int i = CutOffLevels+1; i < aDirs.Length - 1; i++)
                {
                    saveToDir = Path.Combine(saveToDir, aDirs[i]);
                }
                if (!Directory.Exists(saveToDir))
                {
                    if(!emulate)
                        Directory.CreateDirectory(saveToDir);
                    rslt = string.Format("mkdir \"{0}\"", saveToDir);
                }
                String filePath = Path.Combine(saveToDir, aDirs[aDirs.Length - 1]);
                if (!emulate)
                {
                    if (File.Exists(filePath) && !OverwriteExistingFiles)
                        return rslt;
                    using (WebClient wc = new WebClient())
                    {
                        //wc.DownloadFile(url, 
                        wc.DownloadFile(uri, filePath);
                    }
                }
            }
            catch (Exception exc)
            {
                if (!ContinueOnErrors)
                    throw;
                Errors.Add(url, exc.ToString());
            }
            return rslt;
        }
        #endregion
    }
}
