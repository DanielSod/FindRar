using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using FindRarWpf.Functions;
using FindRarWpf.Models;

namespace FindRarWpf
{
    public partial class MainWindow : Window
    {
        public string Path { get; set; }
        public List<string> ListOfFiles { get; set; }
        private string EmptyString = string.Empty;

        public MainWindow()
        {
            InitializeComponent();
            Path = @"H:\_TestZips\";
            
            


            //var tryFile = new MyFile();
            //tryFile.Name = "rumpa";

            //var trFile = new MyFile();
            //trFile.Name = "fitta";

            //var tFile = new MyFile();
            //tFile.Name = "tutte";
        }

        //CurDir
        #region CurDir
        /*
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _curDir;

        public string CurDir
        {
            get { return _curDir; }
            set
            {
                if (value != _curDir)
                {
                if (value != _curDir)
                    _curDir = value;
                    OnPropertyChanged("CurDir");
                }
            }
        }
        //CurDir
        */
        #endregion
        
        
        private void btnCreateFileList_Click(object sender, RoutedEventArgs e)
        {
            // Display the List of files in Listview
            CreateFileList createFileList = new CreateFileList();
            createFileList.FileListMain(Path);
            createFileList.ListToTxt(Path);
            ListMyFiles.ItemsSource = MyFiles.GetFileList();
            txtDir.Text = Path;
        }
        
        
        private void btnmClear_Click(object sender, RoutedEventArgs e)
        {
            ListMyFiles.ItemsSource = EmptyString;
            btnCreateFileList.Content = "Create file list";
            btnDirectory.Content = "Directory";
            btnUnpack.Content = "Unpack";
            btnErase.Content = "Erase";
        }

        private void btnDirectory_Click(object sender, RoutedEventArgs e)
        {
            Directs directs = new Directs();
            Path = directs.NewDir(Path);
        }

        private void btnUnpack_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnErase_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ListMyFiles_Scroll(object sender, System.Windows.Controls.Primitives.ScrollEventArgs e)
        {

        }
    }

    public class MyFiles
    {
        public static List<MyFile> FileList { get; set; } = GetFileList();
        public static List<MyFile> GetFileList()
        {
            var file = @"H:\_TestZips\files.csv";
            var lines = File.ReadAllLines(file);
            var list = new List<MyFile>();
            for (int i = 0; i < lines.Length; i++)
            {
                var line = lines[i].Split(',');
                var myFile = new MyFile()
                {
                    //Id = int.Parse(line[0]),
                    Name = line[0],
                    //Size = int.Parse(line[2])
                    
                };
                list.Add(myFile);
            }
            return list;
        }

        public string Name { get; set; }

    }

    public class MyFile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Size { get; set; }
        //public string Extension { get; set; }
        //public Type Type { get; set; }

    }

    //public enum Type
    //{
    //    rar,zip,iso,other
    //}
}
