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
            string java = ReadJavaFile(path);
            string fjava=FilterCheckedException(java);

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
            StreamWriter sw = new StreamWriter(HelperUtility.na(data.Path));
            sw.Write(data.RazorCode);
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
            // "package\s+([\w.]*);" with name on group 1
            return null;
        }
        private static string javaFor2ForEach(string str)
        {
            //for\s*\((\w*)\s+(\w*)\s*:\s*(\w*) gp 1 type gp 2 name gp3 list
            return null;
        }
    }
}
