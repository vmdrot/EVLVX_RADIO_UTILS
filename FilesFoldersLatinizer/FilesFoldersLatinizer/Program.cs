using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LatinizerLib;

namespace FilesFoldersLainizer
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.Read();

            if (args.Length == 0)
                return;
            String rootDir = args[0];
            bool emulate = false;
            if (args.Length > 1)
            {
                bool tmp;
                if(bool.TryParse(args[1], out tmp))
                    emulate = tmp;
            }
            try
            {
                Console.WriteLine( FoldersQueuer.PerformFoldersRename(args[0], emulate, true));
                FoldersQueuer.PerformFilesRename(args[0]);
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
            }
        }

    }
}
