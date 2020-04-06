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
        private static string GetNamespaces(ref string str)
        {
            StringBuilder sb = new StringBuilder(string.Empty);
            var matches=Regex.Matches(str, @"import\s+((.)*);");
            foreach(Match m in matches)
            {
                str=
            }
            return sb.ToString();
        }
    }
}
