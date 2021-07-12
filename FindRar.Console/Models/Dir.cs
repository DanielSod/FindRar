using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FindRarCon.Functions;

namespace FindRarCon.Models
{
    public class Dir
    {
        public string CurrentDir { get; set; }
        public string AllFilesList { get; set; }
        public string Path { get; set; }

        public void PrintDir()
        {

        }

        //public List<string> DisplayAllFiles()
        public StringBuilder DisplayAllFiles()
        {
            //List<string> displayRar = new List<string>();
            StringBuilder displayAllFiles = new StringBuilder();
            displayAllFiles.AppendLine("This is list is from: ");
            displayAllFiles.AppendLine("  " + CurrentDir + "\n");

            displayAllFiles.AppendLine("The directories are: ");
            IEnumerable<string> dirArr = Directory.EnumerateDirectories(CurrentDir);
            foreach (string dir in dirArr)
            {
                displayAllFiles.AppendLine("  " + dir);
            }

            displayAllFiles.AppendLine("\nThe files are:  ");

            IEnumerable<string> fileArr = Directory.EnumerateFiles(CurrentDir);
            foreach (string file in fileArr)
            {
                displayAllFiles.AppendLine("  " + file);
            }
            return displayAllFiles;
        }


        public StringBuilder DisplayRar()
        {
            //List<string> displayRar = new List<string>();
            StringBuilder displayRar = new StringBuilder();
            // Filtrera ut .rar filer
            return displayRar;
        }


        public StringBuilder DisplayIso()
        {
            //List<string> displayIso = new List<string>();
            StringBuilder displayIso = new StringBuilder();
            // Filtrera ut .iso filer

            return displayIso;
        }


        public string CreateFileList()
        {

            return "File list created!";
        }




        public void DirSecondMenu()
        {

            Console.WriteLine(AllFilesList);
            Console.WriteLine($"Current dir: {CurrentDir}");
            int switchChoice = Convert.ToInt16(Console.ReadLine());
            switch (switchChoice)
            {
                case 1:
                    Console.WriteLine("1. Create file list");
                    
                    break;
                case 2:
                    Console.WriteLine("2. Unpack");

                    break;
                case 3:
                    Console.WriteLine("3. Erase ");

                    break;
                case 4:
                    Console.WriteLine("5. Main menu");

                    break;
                case 5:
                    Console.WriteLine("9. Exit");

                    break;
                default:
                    Console.WriteLine("Default case");
                    break;
            }

        }


    }
}
