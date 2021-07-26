using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindRarWpf.Functions
{
    public class CreateFileList
    {
        public List<string> FileCollection { get; set; }
        private string Path { get; set; }



        public void FileListMain(string path)
        {
            Path = path;

            // Import files
            List<string> fileFiles = new List<string>();
            fileFiles = FileFiles(Path);
            Console.WriteLine(fileFiles);

            // Import dirs
            List<string> dirFiles = new List<string>();
            dirFiles = DirFiles(Path);
            Console.WriteLine(dirFiles);

        

        }
        
        public StringBuilder ExportDirAndFile(string path)
        {
            var txtFile = @"C:\Users\danie\3D Objects\files.csv";
            StringBuilder exportToTxt = new StringBuilder();

            foreach (var dir in DirFiles(Path))
            {
                //string output = dir.Remove(0,13);
                string output = dir.Remove(0, 19);
                exportToTxt.Append(output + " \n");
            }

            foreach (var file in FileFiles(Path))
            {
                //string output = file.Remove(0, 13);
                string output = file.Remove(0, 19);
                exportToTxt.Append(output + " \n");
            } 

            using (StreamWriter sw = new StreamWriter(txtFile))
            {
                sw.Write(exportToTxt);
            }

            return exportToTxt;
        }

        public string ListToTxt(string path)
        {
            string fileName = "files.csv";
            string fileDir = path + fileName;
            Directory.SetCurrentDirectory(path);

            if (File.Exists(fileName))
            {
                Console.WriteLine($"{fileName} exists!");
                Console.WriteLine("Writes FileCollection to: ");
                Console.WriteLine($"   File: {fileName} ");
                Console.WriteLine($"    Dir: {path}");

                StringBuilder outputFromDir = new StringBuilder();
                outputFromDir.Append(ExportDirAndFile(path));

                using (StreamWriter sw = new StreamWriter(fileDir))
                {
                    sw.Write(outputFromDir);
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



        #region Dir and files

        private List<string> FileFiles(string path)
        {
            string[] fileList = Directory.GetFiles(path);

            List<string> getFileList = new List<string>();

            foreach (var fileItem in fileList)
            {
                getFileList.Add(fileItem);
            }
            return getFileList;
        }

        private List<string> DirFiles(string path)
        {
            string[] dirList = Directory.GetDirectories(path);

            List<string> getDirList = new List<string>();

            foreach (var fileItem in dirList)
            {
                getDirList.Add(fileItem);
            }
            return getDirList;
        }

        #endregion


        #region Rar and Iso
        //private List<FileItem> RarFiles()
        //{

        //    rarFiles = new List<FileItem>();

        //    return rarFiles;
        //}

        //private List<FileItem> IsoFiles()
        //{
        //    isoFiles = new List<FileItem>();



        //    return isoFiles;
        //}
        #endregion



    }
}




    /*
     *  string create = "Create file list";
            string save = "Save to file";
            CreateFileList createFileList = new CreateFileList();
            createFileList.FileListMain(Path);

            //if (btnCreateFileList.Content.Equals(save))
            //{

            //    CreateFileList createFile = new CreateFileList();
            //    string displayFiles = createFile.SaveFileList();
                
            //    DisplayFileList.DataContext = ListOfFiles;
                
            //    btnCreateFileList.Content = create;
            //}
            //else
            //{
            //    CreateFileList createFileList = new CreateFileList();
            //    ListOfFiles = new List<string>();
                
            //    DisplayFileList.DataContext = ListOfFiles;
                
            //    btnCreateFileList.Content = save;

            //}
            
            ////ListOfFiles = createFileList.ExportFileList(CurDir);
            //DataContext = this;
     */

/*
  
       #region Save or create file list 
        public void CreateNewFileList()
        {
            FileItem item = new FileItem();
            StringBuilder newFileList = new StringBuilder();
            newFileList.Append();


            string newFileList = string.Empty;
            newFileList = DirFiles(path).ToString() + FileFiles(path).ToString();

        }


        public string SaveFileList()
        {
            CreateNewFileList newFileList = new CreateNewFileList();

            string saveFileList = string.Empty;
            string pathFile = string.Empty;

            DateTime timeStamp = DateTime.Now;

            StringBuilder stringToTxt = new StringBuilder();

            stringToTxt.Append(timeStamp.ToString() + "\n\n");


            pathFile = path + "\\ListOfFiles.txt";

            if (File.Exists(pathFile))
                File.Delete(pathFile);


            foreach (var fileItem in fileCollection)
            {
                stringToTxt.Append(fileItem);
            }

            using (StreamWriter sw = new StreamWriter(pathFile))
            {
                File.Create(pathFile);
                sw.Write(saveFileList);
            }
            return saveFileList;
        }
        #endregion

 
        //private List<FileItem> dirFiles { get; set; }
        //private List<FileItem> fileFiles { get; set; }
        
        //private List<FileItem> rarFiles { get; set; }
        //private List<FileItem> isoFiles { get; set; }

        
    //public class FileItem
    //{
    //    public string Name { get; set; }
        
    //    //public List<string> DirsFiles { get; set; }
    //    //public List<string> FilesFiles { get; set; }
    //    //public List<string> RarFiles { get; set; }
    //    //public List<string> IsoFiles { get; set; }
       
        
    //    //public int Size { get; set; }
        
        
    //    //public FileItem(string name)
    //    //{
    //    //    name = Name;
    //    //}
    //}


    #region old version
        FileItem item = new FileItem();
        fileFiles = new List<FileItem>();
        IEnumerable<string> fileArr = Directory.EnumerateFiles(path);
        foreach (var file in fileArr)
        {
            item.FilesFiles.Add(file);
        }
        return ;


     private List<FileItem> DirFiles(string path)
        {
            string[] fileList = Directory.GetFiles(path);

            List<string> getDirList = new List<string>();

            foreach (var fileItem in fileList)
            {
                getFileList.Add(fileItem);
                Console.WriteLine("    " + fileItem);
            }
            CurFileCollection = getFileList;
            return getFileList;

            dirFiles = new List<FileItem>();
            
            IEnumerable<string> dirArr = Directory.EnumerateDirectories(path);
            foreach (var dir in dirArr)
            {
                dirFiles.Add(dir);
            }
            return dirFiles;
        }


        string[] fileArray;
        foreach (var item in fileFiles)
        {
            fileFiles.Add(item);
        }

        FileFiles(path);
        //List<string> exportFileList = new List<string>();
        FileCollection = new List<string>();
        FileCollection.Add(FileFiles(path));


        private List<FileItem> DirFiles(string path)
        {
            string[] fileList = Directory.GetFiles(path);

            List<string> getDirList = new List<string>();

            foreach (var fileItem in fileList)
            {
                getFileList.Add(fileItem);
                Console.WriteLine("    " + fileItem);
            }
            CurFileCollection = getFileList;
            return getFileList;

            dirFiles = new List<FileItem>();
            
            IEnumerable<string> dirArr = Directory.EnumerateDirectories(path);
            foreach (var dir in dirArr)
            {
                dirFiles.Add(dir);
            }
            return dirFiles;
        }

        //public object ExportFileList(string path)
        //{
        //    dirsFiles(path);
        //    filesFiles(path);
        //    object exportFileList = FileCollection();
        //    return exportFileList;
        //}

        //public List<string> FileCollection() 
        //{
        //    path = mainWindow.CurDir;
        //    fileCollection = new List<string>();
        //    fileCollection.AddRange(dirsFiles(path));
        //    fileCollection.AddRange(filesFiles(path));
        //    return fileCollection;
        //}

    #endregion



            #region temp-comment
            //FileCollection.Clear();

            //MainWindow mainWindow = new MainWindow();
            //StringBuilder response = new StringBuilder();


            //int choiceMenu = int.Parse(Console.ReadLine());



            //switch (choiceMenu)
            //{
            //    case 1:
            //        CreateNewFileList();
            //        break;

            //    case 2:
            //        SaveFileList();
            //        break;

            //    default:
            //        break;
            //}
            #endregion

    //ListToTxt(Path);
            // Save full list to file
 */

/*
public List<string> ExportDirAndFile(string path)
{
    FileCollection = new List<string>();

    foreach (var dir in DirFiles(Path))
        FileCollection.Add(dir);

    foreach (var file in FileFiles(Path))
        FileCollection.Add(file);

    return FileCollection;
}*/