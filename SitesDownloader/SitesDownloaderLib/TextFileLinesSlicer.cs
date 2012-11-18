using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SitesDownloaderLib
{
    public class TextFileLinesSlicer
    {
        public static List<String> Slice(String path, int from, int length)
        {
            List<String> rslt = new List<string>();
            int endLineNo = from + length;
            using (StreamReader sr = new StreamReader(path))
            {
                int lineNo = -1;
                while (sr.Peek() >= 0)
                {
                    lineNo++;
                    string line = sr.ReadLine();
                    if (lineNo < from)
                        continue;
                    if (lineNo > endLineNo - 1)
                        break;
                    rslt.Add(line);
                    
                }
            }
            return rslt;
        }
    }
}
