using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Helpers
{
    public class HelperUtility
    {
        public static string[] GetAllFilesOfExtension(string path,string extension=".mxml")
        {
            List<string> files = new List<string>();

            RecursiveFolders(path, extension, ref files);


            return files.ToArray();
        }

        static void RecursiveFolders(string path,string extn,ref List<string> res)
        {
            DirectoryInfo folders = new DirectoryInfo(path);
            var filesInfo = folders.GetFiles();
            foreach (FileInfo info in filesInfo)
            {
                if (info.Extension == extn)
                {
                    res.Add(info.FullName);
                }

            }

            foreach (var folder in folders.GetDirectories())
            {
                RecursiveFolders(folder.FullName, extn, ref res);
            }
        }
        public static void LogError(object error)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(error);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void LogSuccess(object success)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(success);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void Log(object text)
        {
            Console.WriteLine(text);
        }
        public static void LogStatus(object success)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(success);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void LogInitiation(object success)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(success);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
