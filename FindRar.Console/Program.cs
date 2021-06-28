using System;
using System.IO;
using FindRarCon.Functions;

namespace FindRarCon
{
    class Program
    {
        public string Path { get; set; }
        private static string path { get; set; }

        static void Main(string[] args)
        {
            path = @"H:\_TestZips\";

            CollectFiles(path);
            PrintFiles2Txt(path);
        }
        
        static void CollectFiles(string path)
        {
            BibiFiles bibiFiles = new BibiFiles();
            bibiFiles.CollectFiles(path);
        }

        static void PrintFiles2Txt(string path)
        {
            FilesToTxt files = new FilesToTxt();
            files.ExportToTxt(path);
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
