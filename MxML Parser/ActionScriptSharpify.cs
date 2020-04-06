using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace MxML.Parser
{
    public static class ActionScriptSharpify
    {
        public static string ParseCsharp(string actionCode)
        {
            var Data = CleanCDATA(actionCode);


            return Data;
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
    }
}
