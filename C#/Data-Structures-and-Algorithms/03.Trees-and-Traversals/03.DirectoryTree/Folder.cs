using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.DirectoryTree
{
    public class Folder
    {
        public string name;
        public List<Folder> childFolders { get; set; }
        public List<File> files { get; set; }

        public Folder(string name) 
        {
            this.name = name;
            this.childFolders = new List<Folder>();
            this.files = new List<File>();
        }
    }
}
