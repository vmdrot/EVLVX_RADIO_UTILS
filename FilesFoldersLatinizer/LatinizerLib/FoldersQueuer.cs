using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace LatinizerLib
{
    public class FoldersQueuer
    {
        [Obsolete]
        public static String GenerateRenameScript(String rootDir)
        {
            StringBuilder rslt = new StringBuilder();
            List<String> dirs = ListDirsRecursivelyWorker(rootDir);
            Dictionary<String, String> renamedDirs = new Dictionary<string, string>();
            String currParent = rootDir;
            String prevParent = string.Empty;
            rslt.AppendFormat("cd \"{0}\"\n", currParent);
            foreach (string dir in dirs)
            {
                currParent = ExtractParentDirPath(dir);
                String currParentTrslted = renamedDirs.ContainsKey(currParent) ? renamedDirs[currParent] : currParent;
                if (currParent != prevParent)
                {
                    rslt.AppendFormat("cd \"{0}\"\n", currParentTrslted);
                }
                String currPureDir = ExtractPureDirName(dir);
                String trslted = NamesConverter.TranslitName(currPureDir);
                String currTrsltedFullPath = Path.Combine(currParentTrslted, trslted);
                rslt.AppendFormat("ren \"{0}\" \"{1}\"\n", currPureDir, trslted);
                if (!renamedDirs.ContainsKey(dir))
                    renamedDirs.Add(dir, currTrsltedFullPath);
                prevParent = currParent;
            }
            return rslt.ToString();
        }
        public static String PerformFoldersRename(String rootDir, bool emulate)
        {
            return PerformFoldersRename(rootDir, emulate, false);
        }

        public static String PerformFoldersRename(String rootDir, bool emulate, bool continueOnErrors)
        {
            StringBuilder rslt = new StringBuilder();
            List<String> dirs = ListDirsRecursivelyWorker(rootDir);
            #region tmp
            Dictionary<String, String> renamedDirs = new Dictionary<string, string>();
            String currParent = rootDir;
            String prevParent = string.Empty;
            //rslt.AppendFormat("cd \"{0}\"\n", currParent);
            //foreach (string dir in dirs)
            //{
            //    currParent = ExtractParentDirPath(dir);
            //    String currParentTrslted = renamedDirs.ContainsKey(currParent) ? renamedDirs[currParent] : currParent;
            //    if (currParent != prevParent)
            //    {
            //        rslt.AppendFormat("cd \"{0}\"\n", currParentTrslted);
            //    }
            //    String currPureDir = ExtractPureDirName(dir);
            //    String trslted = NamesConverter.TranslitName(currPureDir);
            //    String currTrsltedFullPath = Path.Combine(currParentTrslted, trslted);
            //    rslt.AppendFormat("ren \"{0}\" \"{1}\"\n", currPureDir, trslted);
            //    if (!renamedDirs.ContainsKey(dir))
            //        renamedDirs.Add(dir, currTrsltedFullPath);
            //    prevParent = currParent;
            //}
            #endregion
            Directory.SetCurrentDirectory(rootDir);
            rslt.AppendLine(string.Format("cd \"{0}\"", rootDir));
            foreach (string dir in dirs)
            {
                currParent = ExtractParentDirPath(dir);
                String currParentTrslted = renamedDirs.ContainsKey(currParent) ? renamedDirs[currParent] : currParent;
                String currPureDir = ExtractPureDirName(dir);
                String trslted = NamesConverter.TranslitName(currPureDir);
                if (currParent != prevParent)
                {
                    String setCurrDir = emulate ? currParent : currParentTrslted;
                    try
                    {
                        Directory.SetCurrentDirectory(setCurrDir);
                        rslt.AppendLine(string.Format("cd \"{0}\"", setCurrDir));
                    }
                    catch (Exception exc)
                    {
                        if (continueOnErrors)
                            rslt.AppendLine(String.Format("REM failed to cd to '{0}' - {1}", dir, exc));
                        else
                            throw;
                        prevParent = currParent;
                        continue;
                    }
                }
                if (trslted != currPureDir)
                {
                    if (trslted[0] == '\\')
                        trslted = trslted.Substring(1);
                    String currTrsltedFullPath = Path.Combine(currParentTrslted, trslted);
                    rslt.AppendLine(String.Format("ren \"{0}\" \"{1}\"", currPureDir, trslted));
                    if (!renamedDirs.ContainsKey(dir))
                        renamedDirs.Add(dir, currTrsltedFullPath);

                    //rslt.AppendLine(String.Format("ren \"{0}\" \"{1}\"", dir, currTrsltedFullPath));

                    if (!emulate)
                    {
                        try
                        {
                            Directory.Move(currPureDir, trslted);
                        }
                        catch (Exception exc)
                        {
                            if (continueOnErrors)
                                rslt.AppendLine(String.Format("REM failed to rename '{0}' - {1}", dir, exc));
                            else
                                throw;
                        }
                    }
                }
                prevParent = currParent;
            }
            return rslt.ToString();
        }

        public static String PerformFilesRename(string rootDir, bool emulate, bool continueOnErrors)
        {
            StringBuilder rslt = new StringBuilder();
            string[] files = Directory.GetFiles(rootDir, "*.*", SearchOption.AllDirectories);
            foreach (String file in files)
            {
                try
                {
                    String currFn = Path.GetFileName(file);
                    String currDir = Path.GetDirectoryName(file);
                    String trslted = NamesConverter.TranslitName(currFn);
                    if (trslted == currFn)
                        continue;
                    String targetPath = Path.Combine(currDir, trslted);
                    if (File.Exists(targetPath))
                    {
                        FileInfo fiCyr = new FileInfo(file);
                        FileInfo fiLat = new FileInfo(targetPath);
                        rslt.AppendLine(string.Format("'{0}' already exists, size = {1}, '{2}' size = {3}", targetPath, fiLat.Length, file, fiCyr.Length));
                        continue;
                    }
                    if (!emulate)
                        File.Move(file, targetPath);
                    else
                        rslt.AppendLine(string.Format("ren \"{0}\" \"{1}\"", file, trslted));
                }
                catch (Exception exc)
                {
                    rslt.AppendLine(String.Format("Exception while processing the file '{0}', details: {1}", file, exc.ToString()));
                    if (continueOnErrors)
                        continue;
                    else
                        throw;
                }
            }
           return rslt.ToString();
       }

        public static String PerformFilesRename(string rootDir)
        {
            return PerformFilesRename(rootDir, false, false);
        }

        public static string ExtractPureDirName(string dir)
        {
            String parentDir = ExtractParentDirPath(dir);
            String tmp = dir.Replace(parentDir, string.Empty);
            return tmp.Replace("\\", string.Empty);
        }

        public static string ExtractParentDirPath(String path)
        {
            if(String.IsNullOrEmpty(path))
                throw new ApplicationException("unable to extract parent for null or empty path");

            String dir = path.Trim();
            if(dir.Length == 0)
                throw new ApplicationException("unable to extract parent for null or empty path");
            if(dir[dir.Length -1] == '\\')
                dir = dir.Substring(0,dir.Length -1);
            return Path.GetDirectoryName(dir);
        }
        public List<char> CreateDistinctMissingCharsListing(string rootDir)
        {
            List<char> distChars = CreateDistinctCharsListing(rootDir);
            List<char> rslt = new List<char>();
            foreach (char ch in distChars)
            {
                if (NamesConverter.KnownChars != null && NamesConverter.KnownChars.Contains(ch))
                    continue;
                rslt.Add(ch);
            }
            return rslt;
        }


        public List<char> CreateDistinctCharsListing(string rootDir)
        {
            List<char> rslt = new List<char>();
            List<String> dirs = ListDirsRecursivelyWorker(rootDir);
            foreach (string dir in dirs)
            {
                foreach (char ch in dir)
                {
                    if (NamesConverter.IgnoreChars != null && NamesConverter.IgnoreChars.Contains(ch))
                        continue;
                    if (rslt.Contains(ch))
                        continue;
                    rslt.Add(ch);
                }
            }
            return rslt;
        }

        public String[] ListSubDirs(string rootDir)
        {
            return Directory.GetDirectories(rootDir);
        }

        public static List<String> ListDirsRecursivelyWorker(String currRoot)
        {
            List<String> dirs = new List<string>(Directory.GetDirectories(currRoot));
            List<String> rslt = new List<string>(dirs);
            foreach (String dir in dirs)
            {
                rslt.AddRange(ListDirsRecursivelyWorker(dir));
            }
            return rslt;
        }

    
    }
}
