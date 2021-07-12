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
        MainWindow mainWindow = new MainWindow();

        public List<string> DirsFiles { get; set; }
        public List<string> FilesFiles { get; set; }
        public List<string> RarFiles { get; set; }
        public List<string> IsoFiles { get; set; }


        private string path { get; set; }
        private List<string> fileCollection { get; set; }


        public object ExportFileList(string path)
        {
            dirsFiles(path);
            filesFiles(path);
            object exportFileList = FileCollection();
            return exportFileList;
        }

        public List<string> FileCollection() 
        {
            path = mainWindow.CurDir;
            fileCollection = new List<string>();
            fileCollection.AddRange(dirsFiles(path));
            fileCollection.AddRange(filesFiles(path));
            return fileCollection;
        }





        private List<string> rarFiles()
        {



            return RarFiles;
        }

        private List<string> isoFiles()
        {



            return IsoFiles;
        }



        private List<string> dirsFiles(string path)
        {
            DirsFiles = new List<string>();
            
            IEnumerable<string> dirArr = Directory.EnumerateDirectories(path);
            foreach (var dir in dirArr)
            {
                DirsFiles.Add(dir);
            }

            return DirsFiles;
        }

        private List<string> filesFiles(string path)
        {
            FilesFiles = new List<string>();

            IEnumerable<string> fileArr = Directory.EnumerateFiles(path);
            foreach (var file in fileArr)
            {
                FilesFiles.Add(file);
            }


            return FilesFiles;
        }




    }
}
