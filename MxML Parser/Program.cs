using System;
using Helpers;

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
        //public static MxMLParsedData[] ParseData(string[] files)
        //{
        //    foreach(string file in files)
        //    {

        //    }
        //}

    }
}
