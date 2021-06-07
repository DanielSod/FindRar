using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FindRarCon
{
    public class BibiFiles
    {
        private string path { get; set; }
        private string curDir { get; set; }
        
        public List<string> CurFileCollection { get; set; }

        public string FileTypes(List<string> CurFileCollection)
        {
            string fileTypes = string.Empty;
            int mp3 = 0; 
            int rar = 0;
            int zip = 0;
            int mp4 = 0;

            string[] fileExtensions = { ".mp3", ".rar", ".zip", ".mp4" };

            foreach (var fileItem in CurFileCollection)
            {
                if (fileItem.Contains(fileExtensions[0]))
                    mp3++;
                if (fileItem.Contains(fileExtensions[1]))
                    rar++;
                if (fileItem.Contains(fileExtensions[2]))
                    zip++;
                if (fileItem.Contains(fileExtensions[3]))
                    mp4++;
            }

            fileTypes = 
                  "\n Mp3 filer: " + mp3.ToString() 
                + "\n Rar filer: " + rar.ToString()  
                + "\n Zip filer: " + zip.ToString() 
                + "\n Mp4 filer: " + mp4.ToString();
            Console.WriteLine(fileTypes);
            return fileTypes;
        }






        #region Finished functions

        public List<string> FileList(string path)
        {
            CurFileCollection = null;
            string[] fileList = Directory.GetFiles(path);

            List<string> getFileList = new List<string>();

            foreach (var fileItem in fileList)
            {
                getFileList.Add(fileItem);
                Console.WriteLine("    " + fileItem);
            }
            CurFileCollection = getFileList;
            return getFileList;
        }

        public int CountItems(string path)
        {
            int countItem = 0;
            string[] fileCollection = Directory.GetFiles(path);

            if (String.IsNullOrEmpty(fileCollection.ToString())) 
                File.Create(path + "newFile.txt");
            else
            {
                foreach (var fileItem in fileCollection)
                {
                    countItem++;
                }
            }
            Console.WriteLine("Number of files in dir: " + countItem);
            return countItem;
        }

        public string SetDir(string path)
        {
            path = @"H:\_TestZips\";
            Directory.SetCurrentDirectory(path);
            return curDir = path;
        }
        
    }
}
#endregion


//  List<string> FileList(string path)  - list of file names
//  int CountItems(string path)         - counts the number of files in dir
//  string SetDir(string path)          - sets directory to hardcoded dir
