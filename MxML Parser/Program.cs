using System;
using System.IO;
using System.Collections.Generic;
using Helpers;

namespace MxML.Parser
{
    public class Parser
    {
        public static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            ParseData(@"C:\Users\shive\Desktop\loginscreen\flex");
            Console.ForegroundColor = ConsoleColor.White;

        }
        public static MxMLParsedData[] ParseData(string path)
        {
            List<MxMLParsedData> parseResult = new List<MxMLParsedData>();
            var files=HelperUtility.GetAllFilesOfExtension(path, ".mxml");
            foreach (string file in files)
            {
                parseResult.Add(ParseSingleMxML(file));
            }
            return parseResult.ToArray();
        }
        private static MxMLParsedData ParseSingleMxML(string path)
        {
            MxMLParsedData result = new MxMLParsedData();
            StreamReader reader = new StreamReader(path);

            //get version info
            var versionInfo = GetXMLInfo(reader.ReadLine());

            //1st one is version,encoding
            result.Version = versionInfo.Item1;
            result.Encoding = versionInfo.Item2;

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
        private static (string,string) GetXMLInfo(string line)
        {
            //<?xml version="1.0" encoding="utf-8"?>
            int index = line.IndexOf("version") + 9;
            int lastIndexVersion = line.IndexOf("\"", index + 2);
            if (index > lastIndexVersion || index == 8 || lastIndexVersion == 2)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("not a valid version number");
                Console.ForegroundColor = ConsoleColor.White;
            }
            string version = line.Substring(index, lastIndexVersion - index);
            return (version, null);
        }

        private static ChildNode ParseChildern(string lines)
        {
            return null;
        }

    }
}
