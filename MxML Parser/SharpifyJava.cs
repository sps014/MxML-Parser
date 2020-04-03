using Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace MxML.Parser
{
    public static class SharpifyJava
    {
        private static Dictionary<string, string> InPlaceReplacements = new Dictionary<string, string>()
        {
            { "String","string" },
            {"import","using" },
            {"boolean","bool" },
            {"final",string.Empty },
        };
        public static string GetSharpified(string path)
        {
            HelperUtility.LogStatus($"started parsing {path}");
            string java = ReadJavaFile(path);
            string fjava=FilterCheckedException(java);
            fjava = JavaPackageToNamespace(fjava);
            fjava = AttributeParser(fjava);
           //fjava = FilterExtraWhiteSpace(fjava);
            WriteFile(path,fjava);
            return fjava;
        }
        private static string ReadJavaFile(string path)
        {
            StreamReader reader = new StreamReader(path);
            var s=reader.ReadToEnd();
            reader.Close();
            return s;
        }
        private static void WriteFile(string path,string data)
        {
            StreamWriter sw = new StreamWriter(HelperUtility.NameWithoutExtension(path,".cs"));
            sw.Write(data);
            var c = HelperUtility.NameWithoutExtension(path, ".cs");
            sw.Close();
        }
        private static string FilterCheckedException( string str)
        {
            //[^@](throws\s(\s*\w+,?)*\s*)\{ at group 1
            var matches = Regex.Matches(str, @"[^@](throws\s(\s*\w+,?)*\s*)");

            foreach(Match m in matches)
            {
                str = str.Replace(m.Groups[0].Value, string.Empty);
            }
            return str;
        }
        private static string JavaPackageToNamespace(string str)
        {
            //"package\s+([\w.]*);" with name on group 1
            var matches = Regex.Matches(str, @"import\s+([\w.]*);");
            string v = "\r\n";
            foreach(Match m in matches)
            {
                v += "using "+m.Groups[1].Value+";\r\n";
                str=str.Replace(m.Groups[0].Value,string.Empty);
            }

            var match = Regex.Match(str, @"package\s+([\w.]*);");
            if(match.Groups.Count>=2)
            {
                if(match.Groups[1].Length>0)
                {
                    var package = match.Groups[1].Value;
                    str = str.Replace(match.Groups[0].Value, $"namespace {package}\r\n" + "{\r\n"+v);
                    str += "\r\n}";
                }
            }

            return str;
        }
        private static string FilterExtraWhiteSpace(string str)
        {
            var match = Regex.Match(str, @"^(?:[\t ]*(?:\r?\n|\r))+",
                RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (match.Groups.Count >= 1)
                if (match.Groups[0].Value.Length > 0)
                    return str.Replace(match.Groups[0].Value, "");

            return str;
        }
        private static string AttributeParser(string str)
        {
            var matches = Regex.Matches(str, @"@(\w+)((.*)?)?");
            foreach(Match m in matches)
            {
                if(m.Groups.Count>3)
                {
                    string atr = "[" + m.Groups[1].Value + m.Groups[2].Value + "]";
                    atr=atr.Replace("\r", "");
                    str=str.Replace(m.Groups[0].Value, atr);
                }
                else
                {

                    string atr = "[" + m.Groups[1].Value +  "]";
                    atr = atr.Replace("\r", "");
                    str = str.Replace(m.Groups[0].Value, atr);
                }
            }

            return str;
        }
        private static string javaFor2ForEach(string str)
        {
            //for\s*\((\w*)\s+(\w*)\s*:\s*(\w*) gp 1 type gp 2 name gp3 list
            return null;
        }
    }
}
