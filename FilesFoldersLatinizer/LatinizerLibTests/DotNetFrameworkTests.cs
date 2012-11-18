using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.IO;
using LatinizerLib;

namespace LatinizerLibTests
{
    [TestFixture]
    public class DotNetFrameworkTests
    {
        [Test]
        public void ListDirs()
        {
            String[] dirs = Directory.GetDirectories(@"D:\mp3");
            PrintArray(dirs);
        }

        private void PrintArray(string[] dirs)
        {
            foreach (string dir in dirs)
            {
                Console.WriteLine(dir);
            }
        }

        [Test]
        public void ListDirsRecursively()
        {
            List<String> dirs = ListDirsRecursivelyWorker(@"D:\mp3");
            PrintArray(dirs);
        }

        private void PrintArray(List<string> dirs)
        {
            foreach (string dir in dirs)
            {
                Console.WriteLine(dir);
            }
        }

        public List<String> ListDirsRecursivelyWorker(String currRoot)
        {
            List<String> dirs = new List<string>(Directory.GetDirectories(currRoot));
            List<String> rslt = new List<string>(dirs);
            foreach (String dir in dirs)
            {
                rslt.AddRange(ListDirsRecursivelyWorker(dir));
            }
            return rslt;
        }

        [Test]
        public void ListDirsRecursively2()
        {
            List<String> dirs = ListDirsRecursivelyWorker(@"D:\tmp\dev\tests\Latinizer");
            PrintArray(dirs);
        }

        [Test]
        public void ListDirsRecursively2WithParents()
        {
            List<String> dirs = ListDirsRecursivelyWorker(@"D:\tmp\dev\tests\Latinizer");
            List<String> parentDirs = new List<string>();
            foreach (String dir in dirs)
                parentDirs.Add(FoldersQueuer.ExtractParentDirPath(dir));
            PrintArrayWithParents(dirs, parentDirs);
        }

        [Test]
        public void ListDirsRecursively2WithPureDirNames()
        {
            List<String> dirs = ListDirsRecursivelyWorker(@"D:\tmp\dev\tests\Latinizer");
            List<String> pureNames= new List<string>();
            foreach (String dir in dirs)
                pureNames.Add(FoldersQueuer.ExtractPureDirName(dir));
            PrintArrayWithParents(dirs, pureNames);
        }

        [Test]
        public void ListCharsDistinctTest()
        {
            FoldersQueuer fq = new FoldersQueuer();
            List<char> chars = fq.CreateDistinctCharsListing(@"D:\tmp\dev\tests\Latinizer");
            PrintArray(chars);
        }

        [Test]
        public void ListCharsDistinctTest2()
        {
            FoldersQueuer fq = new FoldersQueuer();
            List<char> chars = fq.CreateDistinctCharsListing(@"D:\mp3");
            PrintArray(chars);
        }
        

        private void PrintArray(List<char> chars)
        {
            foreach (char ch in chars)
                Console.WriteLine("'{0}'", ch);
        }

        private void PrintArrayWithParents(List<string> dirs, List<string> parentDirs)
        {
            for (int i = 0; i < dirs.Count; i++)
            {
                Console.WriteLine("{0} - {1}", dirs[i], parentDirs[i]);

            }
        }

        [Test]
        public void TranslitNamesTest()
        {
            List<String> dirs = FoldersQueuer.ListDirsRecursivelyWorker(@"D:\mp3");
            List<String> translitDirs = new List<string>();
            
            foreach(String dir in dirs)
            {
                translitDirs.Add(NamesConverter.TranslitName(dir));
            }
            PrintArray(translitDirs);
        }

        [Test]
        public void ExtractParentDirPathTest()
        { 
            Console.WriteLine(FoldersQueuer.ExtractParentDirPath(@"D:\mp3\prichudaOxa\"));
        }

        [Test]
        public void GenerateRenameScriptTest()
        {
            String script = FoldersQueuer.GenerateRenameScript(@"D:\mp3");
            Console.WriteLine(script);
        }

        [Test]
        public void GenerateRenameScriptTest2()
        {
            String script = FoldersQueuer.GenerateRenameScript(@"D:\tmp\dev\tests\Latinizer");
            Console.WriteLine(script);
        }

        [Test]
        public void PerformFoldersRenameTestEmul()
        {
            Console.WriteLine(FoldersQueuer.PerformFoldersRename(@"D:\tmp\dev\tests\Latinizer", true));
        }

        [Test]
        public void PerformFoldersRenameTest()
        {
            Console.WriteLine(FoldersQueuer.PerformFoldersRename(@"D:\tmp\dev\tests\Latinizer", false));
        }
        [Test]
        public void PerformFilesRenameTest()
        {
            FoldersQueuer.PerformFilesRename(@"D:\tmp\dev\tests\Latinizer");
        }
    }
}
