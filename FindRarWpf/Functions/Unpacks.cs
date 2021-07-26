using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindRarWpf.Functions
{
    public class Unpacks
    {
        public string Path { get; set; }
        public int MyProperty { get; set; }

        private List<MyFile> theFileList { get; set; }
        private List<MyFile> rarFileList { get; set; }
        private List<MyFile> isoFileList { get; set; }
        private bool findRar = false;
        private bool findIso = false;

        public List<MyFile> TheFileList() 
        {

            theFileList = new List<MyFile>();
            theFileList = MyFiles.GetFileList();

            int findExtension = theFileList.Count();
            foreach (var fileItem in theFileList)
            {
                string extension = fileItem.Extension.Substring(findExtension-4,4);
                if (extension == ".rar")
                {
                    rarFileList = new List<MyFile>();
                    rarFileList.Add(fileItem);
                }
                else if (extension == ".iso")
                {
                    isoFileList = new List<MyFile>();
                    isoFileList.Add(fileItem);
                }
                else
                    continue;
            }

            if (findRar == true && findIso == false)
                return rarFileList;
            
            else if(findIso == true && findRar == false)
                return isoFileList;
            
            return theFileList;
        }


        #region Finding the files
        public List<MyFile> FindRar()
        {
            MainWindow main = new MainWindow();
            TheFileList();
            main.ListMyFiles.ItemsSource = rarFileList;
            return rarFileList;
        }


        public List<MyFile> FindIso()
        {
            MainWindow main = new MainWindow();
            TheFileList();
            main.ListMyFiles.ItemsSource = isoFileList;
            return isoFileList;
        }

        #endregion 


        #region Unzipping the files

        public void UnzipRar()
        {

        }


        public void UnzipIso()
        {

        }

        #endregion 


        #region Finding the files

        public void SecondSearch()
        {
            // Does another sweep for new or more archives, 
        }


            
        public void FinalOptions()
        {
            // Open folder, Go to Erase, Back to Main menu
        }


        public void ReturnToStart()
        {
            // Back to Main menu
        }
        #endregion 


    }
}
