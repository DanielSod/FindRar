using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

using FindRarCon.Models;

namespace FindRarCon.Functions
{
    public class ChangeDir
    {
        public string CurrentDir { get; set; }
        private string currentDir { get; set; }

        public string Path { get; set; }
        private string inputDir { get; set; }
        private int userChoice { get; set; }

        public void DirAction()
        {
            Console.Clear();
            DirSubMenu();
            userChoice = UserChoice();
            MenuChoice(userChoice);
        }
        
        public StringBuilder DirSubMenu()
        {
            StringBuilder dirSubMenu = new StringBuilder();
            dirSubMenu.AppendLine("1. Change dir");
            dirSubMenu.AppendLine("2. Display all content");
            dirSubMenu.AppendLine("3. Display.rar");
            dirSubMenu.AppendLine("4. Display.iso");
            dirSubMenu.AppendLine("5. Create file list to.txt");
            dirSubMenu.AppendLine("9. Back to main menu");

            return dirSubMenu;
        }

        private int UserChoice()
        {
            Console.WriteLine($"Your choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            if (choice == 1 ||
                choice == 2 ||
                choice == 3 ||
                choice == 4 ||
                choice == 5 ||
                choice == 9)
            {
                userChoice = choice;
                return userChoice;
            }

            else
            {
                Console.WriteLine("Dumme jävel, försök igen!");
                Thread.Sleep(500);
                return choice;
            }
        }


        public void MenuChoice(int userChoice)
        {
            Path = @"H:\_TestZips";
            
            if (userChoice == 1)
            {
                //Change Dir
                SetNewDir();
            }

            else if (userChoice == 2)
            {
                //Display all content
                FilesCollection(Path);
            }

            else if(userChoice == 3)
            {
                // Display .rar

            }
            
            else if (userChoice == 4)
            {
                // Display .iso

            }
            
            else if (userChoice == 5)
            {
                // Create file list

            }

            else if (userChoice == 9)
            {
                // Back to main menu
                MainMenu menu = new MainMenu();
                menu.PrintMainMenu();
            }
        }

        public StringBuilder FilesCollection(string path)
        {
            StringBuilder filesCollection = new StringBuilder();
            //List<string> filesCollection = new List<string>();
            string curDir = Directory.GetCurrentDirectory();
            filesCollection.AppendLine("This is list is from: ");
            filesCollection.AppendLine("  " + curDir + "\n");

            filesCollection.AppendLine("The directories are: ");
            IEnumerable<string> dirArr = Directory.EnumerateDirectories(path);
            foreach (string dir in dirArr)
            {
                filesCollection.AppendLine("  " + dir);
                //Console.WriteLine(dir);
            }

            filesCollection.AppendLine("\nThe files are:  ");

            IEnumerable<string> fileArr = Directory.EnumerateFiles(path);
            foreach (string file in fileArr)
            {
                filesCollection.AppendLine("  " + file);
                //Console.WriteLine(file);
            }
            Console.WriteLine(filesCollection);
           
            return filesCollection;
        }

        public string ThisDir()
        {
            currentDir = Directory.GetCurrentDirectory();
            return currentDir;
        }

        public void SetNewDir()
        {
            MainMenu menu = new MainMenu();
            inputDir = string.Empty;
            Console.WriteLine("Current dir is: \n     " + currentDir);
            Console.WriteLine("New dir: ");
            inputDir = Console.ReadLine();
            if (Directory.Exists(inputDir))
            {
                Console.WriteLine("Dir accepted! ");
                Thread.Sleep(500);
                menu.PrintMainMenu();
            }
            else
            {
                Console.WriteLine("Dir does not exist!");
                Thread.Sleep(500);
                Console.WriteLine("\nWould you like to create dir: ");
                Console.WriteLine("     " + inputDir + "? Y/N");
                YesOrNo yesNo = new YesOrNo();
                bool confirm = yesNo.AnswerYesOrNo();

                if (confirm == true)
                {
                    Directory.CreateDirectory(inputDir);
                    Console.WriteLine("New directory at: " + inputDir);
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                    menu.PrintMainMenu();
                }
                else
                {
                    Console.WriteLine("Returns to main menu...");
                    Thread.Sleep(750);
                    menu.PrintMainMenu();
                }
                
            }
        }

    }
}
