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
                    Console.WriteLine(info.FullName);
                    res.Add(info.FullName);

                }

            }

            foreach (var folder in folders.GetDirectories())
            {
                RecursiveFolders(folder.FullName, extn, ref res);
            }
        }
    }
}
