using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


namespace FindRarCon.Functions
{
    public class FilesToTxt
    {
        private string toTxtFile { get; set; }
        private string fileDir { get; set; }

        private const string fileName = "FileList.txt";
        
       

        public void ExportToTxt(string path)
        {
            FilesCollection(path);
            FileDir(path, fileName);
            TheFileList(path);
        }

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
            toTxtFile = string.Empty;
            filesCollection.ToString();
            toTxtFile = filesCollection.ToString();
            return filesCollection;
        }

        private string FileDir(string path, string fileName)
        {
            fileDir = path + fileName;
            return fileDir;
        }

        public string TheFileList(string path)
        {
            if (File.Exists(fileName))
            {
                Console.WriteLine($"{fileName} exists!");
                Console.WriteLine("Writes FileCollection to: ");
                Console.WriteLine($"   File: {fileName} ");
                Console.WriteLine($"    Dir: {path}");

                using (StreamWriter sw = new StreamWriter(fileDir))
                {
                    sw.Write(toTxtFile);
                }
            }

            else
            {
                File.Create(fileDir);
                using (FileStream fs = new FileStream(fileName, FileMode.Open))
                {
                    using (BinaryWriter writer = new BinaryWriter(fs))
                    {
                        for (int i = 0; i < 11; i++)
                        {
                            writer.Write(i);
                        }
                    }
                }

                using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.ReadWrite))
                {
                    using (BinaryReader r = new BinaryReader(fs))
                    {
                        for (int i = 0; i < 11; i++)
                        {
                            Console.WriteLine(r.ReadInt32());
                        }
                    }
                }
            }
            Console.WriteLine("FileList exported");
            return "   ////\\\\      ";
        }


        //public void SyncAppend(string path)
        //{

        //    // Set a variable to the Documents path.
        //    string txtDir = path + fileName;

        //    // Append text to an existing file named "WriteLines.txt".
        //    using (StreamWriter outputFile = new StreamWriter(Path.Combine(txtDir, fileName), true))
        //    {
        //        outputFile.WriteLine(toTxtFile);
        //    }
        //}




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
            if (VerifyDir(desiredPath) == true)
            {
                ChangePath(desiredPath);
                return desiredPath;
            }
            else
                return "Invalid directory... Try again! ";
        }

        public bool VerifyDir(string desiredPath)
        {
            if (Directory.Exists(desiredPath))
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

    }
}