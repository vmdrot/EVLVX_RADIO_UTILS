using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.IO;
using System.Reflection;

namespace LatinizerLib
{
    public class NamesConverter
    {
        private static readonly string CHAR_MAP_FILE_CFG_KEY = "charMap";
        private static readonly string CHAR_MAP_FILE;
        private static readonly string IGNORE_CHARS_FILE_CFG_KEY = "ignoreCharsFile";
        private static readonly string IGNORE_CHARS_FILE;
        private static Dictionary<char, String> _charmap;
        private static List<char> _ignoreChars;
        private static List<char> _knownChars;

        public static List<char> IgnoreChars
        {
            get
            {
                return _ignoreChars;
            }
        }

        public static List<char> KnownChars
        {
            get
            {
                if (_knownChars == null)
                {
                    _knownChars = new List<char>();
                    _knownChars.AddRange(_charmap.Keys);
                }
                return _knownChars;
            }
        }
        static NamesConverter()
        {
            Configuration cfg = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (cfg.AppSettings.Settings[IGNORE_CHARS_FILE_CFG_KEY] != null)
            {
                IGNORE_CHARS_FILE = cfg.AppSettings.Settings[IGNORE_CHARS_FILE_CFG_KEY].Value;
            }
            if (cfg.AppSettings.Settings[CHAR_MAP_FILE_CFG_KEY] != null)
            {
                CHAR_MAP_FILE = cfg.AppSettings.Settings[CHAR_MAP_FILE_CFG_KEY].Value;
            }
            LoadIgnoreChars();
            LoadCharmap();
        }

        private static void LoadIgnoreChars()
        {
            _ignoreChars = new List<char>();
            String path;
            if (Path.IsPathRooted(IGNORE_CHARS_FILE))
                path = IGNORE_CHARS_FILE;
            else
                path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), IGNORE_CHARS_FILE);
            string[] lns = File.ReadAllLines(path);
            foreach (string ln in lns)
            { 
                if (ln.Length == 0)
                    continue;
                char ch = ln[0];
                if (_ignoreChars.Contains(ch))
                    continue;
                _ignoreChars.Add(ch);
            }
        }

        private static void LoadCharmap()
        {
            _charmap = new Dictionary<char, string>();
            String path;
            if (Path.IsPathRooted(CHAR_MAP_FILE))
                path = CHAR_MAP_FILE;
            else
                path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), CHAR_MAP_FILE);
            string[] lns = File.ReadAllLines(path);
            foreach (String ln in lns)
            {
                String[] flds = ln.Split('\t');
                if (flds == null || flds.Length < 2)
                    continue;
                char ch = flds[0][0];
                if (_ignoreChars != null && _ignoreChars.Contains(ch))
                    continue;
                string s = flds[1].Trim();
                if (_charmap.ContainsKey(ch))
                    continue;
                _charmap.Add(ch, s);
            }
        }

        public NamesConverter()
        { }

        public static String TranslitName(String src)
        {
            StringBuilder rslt = new StringBuilder();
            foreach(char ch in src)
            {
                if (_charmap.ContainsKey(ch))
                    rslt.Append(_charmap[ch]);
                else
                    rslt.Append(ch);
            }
            return rslt.ToString();
        }
    }
}
