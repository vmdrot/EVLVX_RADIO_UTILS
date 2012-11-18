using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SitesDownloaderLib;
using System.IO;

namespace SitesDownloader
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 2)
                return;//todo
            String lstFile = args[0];
            String saveToDir = args[1];
            int lnFrom = -1;
            int numLns = -1;

            if (args.Length >= 4)
            {
                String slnFrom = args[2];
                String snumLns = args[3];
                if(!int.TryParse(slnFrom, out lnFrom))
                    return; //todo
                if(!int.TryParse(snumLns, out numLns))
                    return;//todo
            }

            List<String> urls;

            if (lnFrom != -1 && numLns != -1)
                urls = TextFileLinesSlicer.Slice(lstFile, lnFrom, numLns);
            else
                urls = new List<String>(File.ReadAllLines(lstFile));
            if (urls == null || urls.Count == 0)
                return;//todo
            LinksListDownloader lld = new LinksListDownloader();
            lld.SaveToRoot = saveToDir;
            lld.ContinueOnErrors = true;
            lld.CutOffLevels = 1;
            lld.DecodeUrls = true;
            lld.OverwriteExistingFiles = false;
            
            DateTime dtStart = DateTime.Now;
            Console.WriteLine("Started off at {0}", dtStart);
            Console.WriteLine("urls.Count = {0}", urls.Count);
            String rslt = lld.DownloadList(urls, false);
            DateTime dtEnd = DateTime.Now;
            Console.WriteLine("Finished at {0}", dtEnd);
            Console.WriteLine("Completed in {0}", (TimeSpan)(dtEnd - dtStart));
            Console.WriteLine("Errors count = {0}", lld.Errors.Count);
            PrintDict(lld.Errors);
            Console.WriteLine(rslt);
        }

        private static void PrintDict(Dictionary<string, string> dict)
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
    }
}
