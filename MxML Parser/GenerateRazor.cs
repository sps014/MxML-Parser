﻿using Helpers;
using System;
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
            mxMLParsed.RazorCode = FilterTransition(mxMLParsed.RazorCode);
            mxMLParsed.RazorCode = FilterStates(mxMLParsed.RazorCode);
            mxMLParsed.RazorCode = ReplaceColons(mxMLParsed.RazorCode);
            mxMLParsed.Path = path;

            WriteFile(mxMLParsed);

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
        private static string FilterTransition(string str)
        {
            var match = Regex.Match(str, @"(<mx:Transitions>(.|\n)*?<\/mx:Transitions>)", RegexOptions.IgnoreCase|RegexOptions.Multiline);
            if (match.Groups.Count >= 1)
                if (match.Groups[0].Value.Length > 0)
                    return str.Replace(match.Groups[0].Value, "");

            return str;
        }
        private static string FilterStates(string str)
        {
            var match = Regex.Match(str, @"(<mx:States>(.|\n)*?<\/mx:States>)",
                RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (match.Groups.Count >= 1)
                if (match.Groups[0].Value.Length > 0)
                    return str.Replace(match.Groups[0].Value, "");

            return str;
        }
        private static string ReplaceColons(string razor,string text=".")
        {
            return razor.Replace(":",text);
        }
        private static void InlineFunctions(string str)
        {
            //\W\w*\([\w|.|,|\s*|=']*\)
        }

        private static Dictionary<string,string> GetResourcesDictionary()
        {
            //@Resource\((.?)*\)
            return null;
        }
        private static void WriteFile(MxMLParsedData data)
        {
            StreamWriter sw = new StreamWriter(NameWithoutExtension(data.Path));
            sw.Write(data.RazorCode);
            sw.Close();
        }
        private static string NameWithoutExtension(string str)
        {
            return str.Replace(".mxml", ".razor");
        }

        private static string ReadFile(string path)
        {
            StreamReader reader = new StreamReader(path);
            _ = reader.ReadLine();
            string xmlBody = reader.ReadToEnd();
            reader.Close();
            return xmlBody;
        }

    }
}
