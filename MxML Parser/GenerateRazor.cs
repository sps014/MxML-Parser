using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MxML.Parser
{
    public static class GenerateRazor
    {
        public static string GetRazorString(string path)
        {
            StreamReader reader = new StreamReader(path);
            _=reader.ReadLine();
            string xmlBody = reader.ReadToEnd();
            xmlBody=xmlBody.Replace(':', '.');
            reader.Close();
            return xmlBody;
        }
    }
}
