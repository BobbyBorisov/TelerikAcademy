using System;
using System.IO;
using System.Linq;
using System.Numerics;

namespace _03.DirectoryTree
{
    class DirectoryTreeExample
    {

        static void FullDirList(DirectoryInfo dir, string searchPattern, Folder currentFolder)
        {
            try
            {

                foreach (FileInfo f in dir.GetFiles(searchPattern))
                {
                    currentFolder.files.Add(new File(f.Name, (ulong)f.Length));
                }


                foreach (DirectoryInfo d in dir.GetDirectories())
                {

                    var newfolder = new Folder(d.Name);
                    currentFolder.childFolders.Add(newfolder);
                    FullDirList(d, searchPattern, newfolder);

                }
            }
            catch (UnauthorizedAccessException) { }

            return;
        }

        static void FindSubTree(Folder folder,string searchedName) 
        {
            if (folder.name == searchedName) 
            {
                var size = GetSize(folder,0);
                Console.WriteLine("Size :"+size);

                //throwing Exception to stop recursion :D
                throw new Exception("Size found");
            }

            foreach (var childfolder in folder.childFolders) 
            {
                FindSubTree(childfolder, searchedName);
            }
        }

        static BigInteger GetSize(Folder folder, BigInteger size) 
        {
            foreach (var file in folder.files)
            {
                size += file.size;
            }

            foreach (var subFolder in folder.childFolders)
            {
                size=GetSize(subFolder, size);
            }

            return size;
        }

        static void Main(string[] args)
        {

            //Enter path to your folder.
            var currentFolder = new Folder("C:\\Windows");
            DirectoryInfo dir = new DirectoryInfo("C:\\Windows");

            //DirectoryInfo dir = new DirectoryInfo("C:\\Users\\Bocko\\Desktop\\Old_desktop");
           
            FullDirList(dir, "*",currentFolder);

            Console.WriteLine("Enter subtree name");
            var searchedName = Console.ReadLine();
            
            //Iterates recursivly over the chosen folder
            try
            {
                FindSubTree(currentFolder, searchedName);
            }
            catch (Exception) 
            {
            
            }
        }
    }
}
