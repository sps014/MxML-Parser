﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;

namespace MxML.Parser
{
    public static class ActionScriptSharpify
    {
        public static ActionScript Parse2Csharp(ActionScript actionScript)
        {
            actionScript.ActionCode = CleanCDATA(actionScript.ActionCode);
            actionScript.CSImports = GetNamespaces(ref actionScript);
            actionScript = FilterExtraWhiteSpace(actionScript);
            ParseFields(ref actionScript);
            return actionScript;
        }
        private static string CleanCDATA(string str)
        {
            var match = Regex.Match(str,@"\<\!\[CDATA\[\s*((.|\n)*?)\]\s*\]\>");
            if(match.Groups.Count>=2)
            {
                if(match.Groups[1].Value.Length>0)
                {
                    return match.Groups[1].Value;
                }
            }
            return str;
        }
        private static string GetNamespaces(ref ActionScript str)
        {
            StringBuilder sb = new StringBuilder(string.Empty);
            var matches=Regex.Matches(str.ActionCode, @"import\s+((.)*);");
            foreach(Match m in matches)
            {
                sb.Append("@using "+m.Groups[1].Value+";\n");
                str.ActionCode=str.ActionCode.Replace(m.Groups[0].Value, string.Empty);
            }

            sb=sb.Replace(".*", string.Empty);
            return sb.ToString();
        }
        private static ActionScript FilterExtraWhiteSpace(ActionScript str)
        {
            var match = Regex.Match(str.ActionCode, @"^\s*$", RegexOptions.Multiline);
            if (match.Groups.Count >= 1)
                if (match.Groups[0].Value.Length > 0)
                    str.ActionCode= str.ActionCode.Replace(match.Groups[0].Value, "\r\n");

            return str;
        }
        private static void ParseFields(ref ActionScript code)
        {
            var matches = Regex.Matches(code.ActionCode, @"var\s+(\w+)\:(\w+)\s*[;=]");
            foreach(Match m in matches)
            {
                var name = m.Groups[1].Value;
                var type = m.Groups[2].Value;
                if(m.Groups[0].Value.IndexOf('=')<0)
                    code.ActionCode = code.ActionCode.Replace(m.Groups[0].Value, $"{type} {name};");
                else
                    code.ActionCode = code.ActionCode.Replace(m.Groups[0].Value, $"{type} {name}=");
            }
        }
    }
}
