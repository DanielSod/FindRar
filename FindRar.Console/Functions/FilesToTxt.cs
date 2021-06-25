using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FindRarCon.Functions
{

    public class FilesToTxt
    {

        public string PrintTxtFile { get; set; }
        private string toTxtFile { get; set; }

        public void ExportToTxt()
        {
            
            
        }

        public string dd()
        {
            string hej = "";
            return hej;
        }


      //           Asks about path, verifies it and if
      //           correct changes path. 
      //           InsertDir -> VerifyDir -> ChangePath
#region  Ask, verify and change dir
      public string InsertDir(string path)
        {
            string desiredPath = string.Empty;
            Console.Write("Insert path to export here: ");
            desiredPath = Console.ReadLine();
            VerifyDir(desiredPath);
            if(VerifyDir(desiredPath) == true)
            {
                ChangePath(desiredPath);
                return desiredPath;
            }
            else
                return "Invalid directory... Try again! ";
        }

        public bool VerifyDir(string desiredPath)
        {
            if(Directory.Exists(desiredPath))
                return true;
            else
                return false;
        }

        public string ChangePath(string desiredPath)
        {
            string path = string.Empty;
            path = desiredPath;
            return path;
        }
#endregion 


      //public List<string> FilesCollection(string path)
      public StringBuilder FilesCollection(string path)
      {
         StringBuilder filesCollection = new StringBuilder();
         //List<string> filesCollection = new List<string>();
         string curDir = Directory.GetCurrentDirectory();
         filesCollection.AppendLine("\n\nThis is list is from: ");
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


    }
}