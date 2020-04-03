using Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxML.Parser
{
    class Program
    {
        public static void Main(string[] args)
        {
            PrintLogo();

            Parser.ParseData(@"C:\Users\shive\Desktop\loginscreen\flex");
            ParseJava();
        }
        private static void ParseJava()
        {
            string path = @"C:\Users\shive\Desktop\loginscreen\";
            HelperUtility.LogInitiation($"Started Parsing java files of Path:{path}");

            var files =HelperUtility.GetAllFilesOfExtension(path, ".java");
            foreach(var m in files)
            {
                SharpifyJava.GetSharpified(m);
            }
        }
        private static void PrintLogo()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;

            string text = @"
$$$$$$$$\ $$\                            $$$$$$\        $$\      $$\  $$$$$$\   $$$$$$\  $$\      $$\ 
$$  _____|$$ |                          $$  __$$\       $$ | $\  $$ |$$  __$$\ $$  __$$\ $$$\    $$$ |
$$ |      $$ | $$$$$$\  $$\   $$\       \__/  $$ |      $$ |$$$\ $$ |$$ /  $$ |$$ /  \__|$$$$\  $$$$ |
$$$$$\    $$ |$$  __$$\ \$$\ $$  |       $$$$$$  |      $$ $$ $$\$$ |$$$$$$$$ |\$$$$$$\  $$\$$\$$ $$ |
$$  __|   $$ |$$$$$$$$ | \$$$$  /       $$  ____/       $$$$  _$$$$ |$$  __$$ | \____$$\ $$ \$$$  $$ |
$$ |      $$ |$$   ____| $$  $$<        $$ |            $$$  / \$$$ |$$ |  $$ |$$\   $$ |$$ |\$  /$$ |
$$ |      $$ |\$$$$$$$\ $$  /\$$\       $$$$$$$$\       $$  /   \$$ |$$ |  $$ |\$$$$$$  |$$ | \_/ $$ |
\__|      \__| \_______|\__/  \__|      \________|      \__/     \__|\__|  \__| \______/ \__|     \__|
                                                  


                                                Team Sonic
                                Developers:Shivendra,Raghav [Codechef Hackathon]                                                                                                   



";
            Console.Write(text);
        }
    }
}
