using System;
using System.IO;
using System.Text;
using FindRarCon.Functions;
using FindRarCon.Models;

namespace FindRarCon
{
    class Program
    {
        public string Path { get; set; }
        private static string path { get; set; }

        public static string CurDir { get; set; }

        static void Main(string[] args)
        {
            //Choice simple or advanced
            SimpleUnrar();
            
            //MainMenu();
        }

        static void SimpleUnrar()
        {
            const string source = "D:\\UnzipFolder";
            
            Console.Write("Insert name of .rar file ");
            string userInput = Console.ReadLine();
            
            StringBuilder rarSource = new StringBuilder();
            rarSource.Append(source + "\\" + userInput);
            string dirRar = rarSource.ToString();
            string destinationFolder = dirRar.Remove(dirRar.LastIndexOf('.'));

            System.Diagnostics.Process p = new System.Diagnostics.Process();
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.FileName = "\"C:\\Program Files\\WinRAR\\WinRAR.exe\"";
                p.StartInfo.Arguments = string.Format(@"x -s ""{0}"" *.* ""{1}\""", dirRar, destinationFolder);
                p.Start();
                p.WaitForExit();

            Console.WriteLine("Unzip done");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        static void MainMenu()
        {
            MainMenu menu = new MainMenu();
            menu.PrintMainMenu();

        }


        static void Exit()
        {

        }

        

    }
}
