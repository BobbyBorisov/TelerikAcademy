using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _03.DirectoryTree
{
    public class File
    {
        private string name;
        public BigInteger size;

        public File(string name, BigInteger size) 
        {
            this.name = name;
            this.size = size;
        }
    }
}
