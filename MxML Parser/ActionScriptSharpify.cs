using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace MxML.Parser
{
    public static class ActionScriptSharpify
    {
        public static ActionScript Parse2Csharp(ActionScript actionScript)
        {
            var Data = CleanCDATA(actionScript.ActionCode);
            actionScript.CSImports = GetNamespaces(ref actionScript);

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
                str.ActionCode.Replace(m.Groups[0].Value, string.Empty);
            }

            sb=sb.Replace(".*", string.Empty);
            return sb.ToString();
        }
    }
}
