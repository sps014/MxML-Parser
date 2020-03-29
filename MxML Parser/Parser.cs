using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;

using Helpers;

namespace MxML.Parser
{
    public class Parser
    {
        public static void Main(string[] args)
        {
            ParseData(@"C:\Users\shive\Desktop\loginscreen\flex");

        }
        public static MxMLParsedData[] ParseData(string path)
        {
            HelperUtility.LogInitiation($"Started Parsing files of Path:{path}");
            var parseSuccessStatus = true;

            List<MxMLParsedData> parseResult = new List<MxMLParsedData>();
            var files=HelperUtility.GetAllFilesOfExtension(path, ".mxml");
            foreach (string file in files)
            {
                HelperUtility.LogStatus($"started parsing {file}");
                var pResult = ParseSingleMxML(file);
                if (pResult != null)
                    parseResult.Add(pResult);
                else
                    parseSuccessStatus = false;
            }

            if (parseSuccessStatus)
                HelperUtility.LogSuccess("Successfully parsed files");
            else
                HelperUtility.LogError("Failed parsing files");


            return parseResult.ToArray();
        }
        private static MxMLParsedData ParseSingleMxML(string path)
        {
            MxMLParsedData result = new MxMLParsedData();
            StreamReader reader = new StreamReader(path);

            //get version info
            var isHeaderMatch = GetXMLInfo(reader.ReadLine());
            if (!isHeaderMatch)
            {
                HelperUtility.LogError("Can't parse version and encoding ");
                return null;
            }

            //1st one is version,encoding
            result.Version = "1.0";
            result.Encoding = "utf-8";

            string lines = reader.ReadToEnd();
            result.Child = ParseChildern(lines);

            reader.Close();
            //For the first line get the Version
            return result;
        }

        /// <summary>
        /// Parsing XML Here
        /// </summary>
        /// <param name="line"></param>
        /// <returns>1st one is version,encoding respectively</returns>
        private static bool GetXMLInfo(string line)
        {
            //<?xml version="1.0" encoding="utf-8"?>
            
            if(line.IndexOf("version")==-1||line.IndexOf("encoding")==-1)
            {
                return false;
            }

            string pattern= @"<\?xml\s\w*=\W[\w.]*\W\s*[\w]*=\W[\w-]*\W\?>";
            return Regex.IsMatch(line, pattern);
        }
        private static ChildNode ParseChildern(string lines)
        {
            return null;
        }

    }
}
