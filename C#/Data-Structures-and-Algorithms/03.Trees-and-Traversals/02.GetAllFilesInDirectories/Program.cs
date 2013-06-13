using System;
using System.IO;
using System.Linq;

namespace _02.GetAllFilesInDirectories
{
    class Program
    {
        static void FullDirList(DirectoryInfo dir, string searchPattern)
        {
            //Console.WriteLine("Directory {0}", dir.FullName);
            // list the files
            foreach (FileInfo f in dir.GetFiles(searchPattern))
            {

                Console.WriteLine("File {0}", f.FullName);
            }
            // process each directory
            foreach (DirectoryInfo d in dir.GetDirectories())
            {
                FullDirList(d, searchPattern);
            }
        }

        static void Main(string[] args)
        {
            DirectoryInfo dir = new DirectoryInfo("C:\\Users\\Bocko\\Desktop\\Old_desktop");
            FullDirList(dir, "*.exe");
        }
    }
}
