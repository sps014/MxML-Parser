using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MxML.Parser
{
    public static class SharpifyJava
    {
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
    }
}
