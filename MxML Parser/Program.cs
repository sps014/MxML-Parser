using System;
using System.IO;
using System.Collections.Generic;
using Helpers;
using System.Xml.Schema;

namespace MxML.Parser
{
    public class Parser
    {
        public static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Blue;

            HelperUtility.GetAllFilesOfExtension(@"C:\Users\shive\Desktop\loginscreen\flex");
            Console.ForegroundColor = ConsoleColor.White;

        }
        public static MxMLParsedData[] ParseData(string[] files)
        {
            List<MxMLParsedData> parseResult = new List<MxMLParsedData>();   
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

        }

        private static ChildNode ParseChildern(string lines)
        {

        }

    }
}
