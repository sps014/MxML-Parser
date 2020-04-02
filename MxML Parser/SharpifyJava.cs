using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

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
            return null;
        }
        private static string ReadJavaFile(string path)
        {
            StreamReader reader = new StreamReader(path);
            var s=reader.ReadToEnd();
            reader.Close();
            return s;
        }
        private static string FilterCheckedException()
        {
            //[^@](throws\s(\s*\w+,?)*\s*)\{ at group 1
            return null;
        }
    }
}
