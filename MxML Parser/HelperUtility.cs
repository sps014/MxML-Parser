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
            DirectoryInfo folders = new DirectoryInfo(path);
            var filesInfo = folders.GetFiles();
            foreach(FileInfo info in filesInfo)
            {
                if(info.Extension==extension)
                {
                    files.Add(info.FullName);
                }
            }


            return files.ToArray();
        }
    }
}
