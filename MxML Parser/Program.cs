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
            string path;
            if(args.Length>=1)
                path = args[0];
            else
                path= @"C:\Users\ragha\Downloads\Programs\loginscreen\";

            Parser.ParseData(path);
            ParseJava(path);
        }
        private static void ParseJava(string path)
        {
            HelperUtility.LogInitiation($"\nStarted Parsing java files of Path:{path}");

            var files =HelperUtility.GetAllFilesOfExtension(path, ".java");
            foreach(var m in files)
            {
                SharpifyJava.GetSharpified(m);
            }

            HelperUtility.LogSuccess($"Finished Parsing java files of  {path}");
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
