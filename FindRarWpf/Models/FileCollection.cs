using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindRarWpf.Models
{
    public class FileCollection
    {

        private string name { get; set; }
        private string size { get; set; }
        private string dir { get; set; }

        public List<FileItem> fileCollection
        {
            get
            {
                return new List<FileItem>
                {
                    new FileItem { 
                        Name =name, 
                        Size=size, 
                        Dir=dir }
                };
            }
        }
    }

    public class FileItem
    {
        public string Name { get; set; }
        public string Size { get; set; }
        public string Dir { get; set; }
    }
}
