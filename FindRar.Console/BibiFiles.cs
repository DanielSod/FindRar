using System;
using System.Collections.Generic;
using System.IO;

namespace FindRarCon
{
    public class BibiFiles
    {
        private string curDir { get; set; }
        public List<string> CurFileCollection { get; set; }

        public void CollectFiles(string path)
        {
            SetDir(path);
            CountItems(path);
            FileList(path);
            FileTypes(CurFileCollection);
        }


        #region Finished functions
        //          Displays the different types and the qty of each
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


        //          Displays a list with all the files in dir
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


        //          Checks how many objects there is in dir
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


        //          Sets dir correctly
        public string SetDir(string path)
        {
            path = @"H:\_TestZips";
            Directory.SetCurrentDirectory(path);
            return curDir = path;
        }

    }
}
#endregion

//  string FileTypes(List<string> CurFileCollection)
//                                      - list and specify qty of different extensions
//  List<string> FileList(string path)  - list of file names
//  int CountItems(string path)         - counts the number of files in dir
//  string SetDir(string path)          - sets directory to hardcoded dir