using System;
using System.Collections.Generic;
using System.IO;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindRarWpf.Functions
{
    public class Directs
    {

        public string NewPath { get; set; }
        private string newPath { get; set; }
        public string FileName { get; set; }
        private string fileDir { get; set; }
        public string NewDir(string newPath)
        {

            AskForDir(newPath);

            return NewPath;
        }

        private string AskForDir(string newPath)
        {
            Console.WriteLine("Insert new dir: ");
            MainWindow main = new MainWindow();
            main.txtDir.Text = "Insert new dir here";
            string userInput = Console.ReadLine();
            main.txtDir.Text = userInput;
            newPath = userInput;
            return newPath;
        }

        private bool IsValid(string NewPath, string FileName)
        {
            bool isValid = false;
            string FileDir = NewPath + FileName;
            
            if (Directory.Exists(newPath))
            {
                NewPath = newPath;
                if (File.Exists(newPath))
                {
                    return isValid = true;
                }
                else
                {
                    File.Create(FileName);
                }
            }
            else
            {
                Directory.CreateDirectory(newPath);
                return isValid = false;
            }

            return isValid;
        }

        // Ask for new dir
        // Validate dir
        // Return dir

    }
}
