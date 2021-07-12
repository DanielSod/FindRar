using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using FindRarCon.Functions;

namespace FindRarCon.Models
{
    public class MainMenu
    {
        public string CurDir { get; set; }
        private int userChoice { get; set; }
        private char userInput { get; set; }

        public void PrintMainMenu()
        {
            Console.Clear();
            MenuStart();
            UserChoice();
            MenuChoice(userChoice);
        }

        private int UserChoice()
        {
            Console.WriteLine($"Your choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            if ( choice == 1 ||
                choice == 2 ||
                choice == 3 ||
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
                PrintMainMenu();
                return choice;
            }
        }


        public void MenuChoice(int userChoice)
        {
            if (userChoice == 1)
            {
                //Dir
                ChangeDir changeDir = new ChangeDir();
                changeDir.DirAction();
            }
            
            else if(userChoice == 2)
            {
                //Unpack
                Console.WriteLine("You chose Unpack!");
                Thread.Sleep(300);
            }

            else if (userChoice == 3)
            {
                //Erase
                Console.WriteLine("You chose Erase!");
                Thread.Sleep(300);
            }
            
            else if (userChoice == 5)
            {
                //Back
                Console.WriteLine("You chose back!");
                Thread.Sleep(300);
            }
            
            else if (userChoice == 9)
            {
                //Exit
                Console.WriteLine("You chose Exit!");
                Thread.Sleep(300);
            }

            else
            {
                Console.WriteLine("Invalid request");
                Thread.Sleep(300);
                PrintMainMenu();
            }
        }

        public StringBuilder MenuStart()
        {
            StringBuilder menu = new StringBuilder();
            menu.AppendLine("Select an option: ");
            menu.AppendLine("1. Dir    ...");
            menu.AppendLine("2. Unpack ...");
            menu.AppendLine("3. Erase  ...");
            menu.AppendLine(" ");
            menu.AppendLine("9. Exit");
            Console.WriteLine(menu);
            return menu;
        }

        private char blink()
        {
            char blink = '_';
            if (blink == '_')
            {
                Thread.Sleep(50); 
                blink = ' ';
            }
            else
            {
                Thread.Sleep(50);
                blink = '_';
            }
            return blink;
        }
    }
}
