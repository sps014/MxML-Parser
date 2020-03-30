using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace MxML.Parser
{
    public static class GenerateRazor
    {
        public static string GetRazorString(string path)
        {
            StreamReader reader = new StreamReader(path);
            _=reader.ReadLine();
            string xmlBody = reader.ReadToEnd();
            xmlBody = RemoveCDATA(xmlBody);
            xmlBody=xmlBody.Replace(':', '.');
            reader.Close();
            RemoveCDATA(xmlBody);
            return xmlBody;
        }
        private static string RemoveCDATA(string str)
        {
            var matches=Regex.Match(str, @"(<mx:Script>(.|\n)*?<\/mx:Script>)",
                                RegexOptions.Multiline|RegexOptions.IgnoreCase);

            if (matches.Groups.Count >= 1)
                if(matches.Groups[0].Value.Length>=1)
                str=str.Replace(matches.Groups[0].Value, " ");

            return str;
        }
    }
}
