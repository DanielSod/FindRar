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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //public string CurDir { get; set; }
        public string Path { get; set; }
        //public object ListOfFiles { get; set; }
        public List<string> ListOfFiles { get; set; }

        public MainWindow()
        {
            Path = @"H:\_TestZips\";
            InitializeComponent();
            CurDir = Path;
            txtDir.Text = CurDir;
        }


                //CurDir
        #region CurDir
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
        #endregion
        
        
        private void btnmClear_Click(object sender, RoutedEventArgs e)
        {
            
            btnCreateFileList.Content = "Create file list";
            btnDirectory.Content = "Directory";
            btnUnpack.Content = "Unpack";
            btnErase.Content = "Erase";

        }

        private void btnCreateFileList_Click(object sender, RoutedEventArgs e)
        {
            if (btnCreateFileList.Content == "Create file list")
            {

            }
            else if(btnCreateFileList.Content == "Save to file")
            {

            }
            else
            {

            }

            
            CreateFileList createFileList = new CreateFileList();
            ListOfFiles = new List<string>();
            ListOfFiles = createFileList.FileCollection();
            //ListOfFiles = createFileList.ExportFileList(CurDir);

            string btnClickTwiceText = "Save to file";



            btnCreateFileList.Content = btnClickTwiceText;
            

            
        }
        public void SecondClick()
        {
            //if ( == true)
            //{
            string PathFile = string.Empty;
            PathFile = Path + "ListOfFiles.txt";
            string timeStamp = DateTime.Now.ToString();
            if (!File.Exists(PathFile))
            {
                File.Create(PathFile);
                File.OpenWrite(PathFile);
                File.WriteAllText(PathFile, timeStamp + "\n\n");

                foreach (var fileItem in ListOfFiles)
                {
                    File.AppendText(fileItem);
                }

                File.SetLastAccessTime(PathFile, DateTime.Now);
            }
            else
            {
                File.WriteAllText(PathFile, "");
            }


            //}
        }

        private void btnDirectory_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnUnpack_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnErase_Click(object sender, RoutedEventArgs e)
        {

        }

   
    }



    /*
     YourListBox.ItemsSource = new List<String> { "One", "Two", "Three" };

Your XAML should look like:

<ListBox Margin="20" Name="YourListBox">
    <ListBox.ItemTemplate> 
        <DataTemplate> 
            <StackPanel Orientation="Horizontal"> 
                <TextBlock Text="{Binding}" /> 
            </StackPanel> 
        </DataTemplate> 
    </ListBox.ItemTemplate> 
</ListBox> 

     */
}
