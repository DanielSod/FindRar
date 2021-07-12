using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindRarCon.Models
{
    public class SingleFile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Size { get; set; }
        public string Url { get; set; }
        
        public SingleFile(int id, string name, int size, string url)
        {
            Id = id;
            Name = name;
            Size = size;
            Url = url;
        }

        

    }
}
