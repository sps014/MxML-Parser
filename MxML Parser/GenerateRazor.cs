﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace MxML.Parser
{
    public static class GenerateRazor
    {
        public static MxMLParsedData GetRazorString(string path)
        {
            MxMLParsedData mxMLParsed = new MxMLParsedData();

            var xml = ReadFile(path);
            xml = RemovedNamespace(xml);

            mxMLParsed.ActionCode = ParseCDATA(xml);
            mxMLParsed.RazorCode = ParseTags(xml, mxMLParsed.ActionCode);
            mxMLParsed.Path = path;

            WriteFile(mxMLParsed.RazorCode);

            return mxMLParsed;
        }

        private static string ParseCDATA(string str)
        {
            var matches=Regex.Match(str, @"(<mx:Script>(.|\n)*?<\/mx:Script>)",
                                RegexOptions.Multiline|RegexOptions.IgnoreCase);

            if (matches.Groups.Count >= 1)
                if (matches.Groups[0].Value.Length >= 1)
                    return matches.Groups[0].Value;

            return null;
        }
        private static string ParseTags(string str,string cdata)
        {
            if (cdata != null)
                if (cdata.Length > 0)
                    return str.Replace(cdata, "\n");

            return str;
        }
        private static string RemovedNamespace(string str)
        {
            var match=Regex.Match(str, @"xmlns:mx=\W(.*)\W");
            if (match.Groups.Count >= 1)
                if (match.Groups[0].Value.Length > 0)
                    return str.Replace(match.Groups[0].Value, "");

            return str;
        }
        private static void InlineFunctions(string str)
        {
            //\W\w*\([\w|.|,|\s*|=']*\)
        }
        private static string ReadFile(string path)
        {
            StreamReader reader = new StreamReader(path);
            _ = reader.ReadLine();
            string xmlBody = reader.ReadToEnd();
            reader.Close();
            return xmlBody;
        }
        private static void WriteFile(string str)
        {
            StreamWriter sw = new StreamWriter("text.txt");
            sw.Write(str);
            sw.Close();
        }

    }
}
