using System;
using System.IO;
using System.Threading;

using FindRarCon.Functions;

namespace FindRarCon
{
   class Program
    {
      public string Path { get; set; }
      private static string path { get; set; }

      static void Main(string[] args)
      {
         path = @"C:\_TestZips\";

         BibiFiles bibiFiles = new BibiFiles();
         bibiFiles.SetDir(path);
         bibiFiles.CountItems(path);
         bibiFiles.FileList(path);
         bibiFiles.FileTypes(bibiFiles.CurFileCollection);

         PrintFiles();

         //FilesToTxt filesToTxt = new FilesToTxt();
         //filesToTxt.InsertDir(path);
         //filesToTxt.FilesCollection(path);
         //filesToTxt.ExportToTxt();

      }

      static void PrintFiles()
      {
         FilesToTxt files = new FilesToTxt();
         files.FilesCollection(path);
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
