﻿using System;
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
