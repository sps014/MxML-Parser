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
        private static string FilterCheckedException( string str)
        {
            //[^@](throws\s(\s*\w+,?)*\s*)\{ at group 1
            return null;
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
