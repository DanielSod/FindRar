using System;
using System.IO;
using System.Threading;

namespace FindRarCon
{
    class Program
    {
        public string Path { get; set; }
        private static string path { get; set; }

        static void Main(string[] args)
        {
            path = @"H:\_TestZips\";
            
            BibiFiles bibiFiles = new BibiFiles();
            bibiFiles.SetDir(path);
            bibiFiles.CountItems(path);
            bibiFiles.FileList(path);
            bibiFiles.FileTypes(bibiFiles.CurFileCollection);
            /*
            bibiFiles.GetBibiFiles();
            */


            /* Console.WriteLine("Load development");
               Thread.Sleep(400);

               //DevPart();  

               Console.WriteLine("Done");
               Console.WriteLine("Press any key to continue...");

               Console.ReadKey(); */
        }


        // Display correct directory
        static void DevPart()
        {
            string curDir = Directory.GetCurrentDirectory();
            string pathCreate = @"C:\Users\danie\Videos\newDir\";
            Console.WriteLine(curDir);
            Directory.CreateDirectory(pathCreate);

            bool validDir = Directory.Exists(pathCreate);
            if(validDir == true)
                Console.WriteLine("Dir exist");
            else
                Console.WriteLine("Dit doesnt exist");
            Directory.SetCurrentDirectory(pathCreate);
            Console.WriteLine(Directory.GetCurrentDirectory());
        }
    }
}

/*
    Jag vill med den här applikationen kunna skapa en txt-fil
    som lägger till alla filer & mappar till en lista
 */


/*
    Jag vill kunna hitta alla rar filer i en directory
        - Den ska sedan kunna leta igenom alla sub dirs
        - Den ska kunna zippa upp filen i en ny mapp
        - Namnet på mappen ska ta ut det relevanta namnet
            och skapa ett nytt snyggare formaterat
        - Ha möjlighet att flytta till rätt dir i samband 
            med unzip
        - Kunna radera orginalet så endast den ozippade 
            versionen är kvar
 */
