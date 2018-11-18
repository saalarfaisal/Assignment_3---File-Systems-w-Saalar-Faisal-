using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_3
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    class Node
    {
        private string directory;
        private List<string> file;
        private Node leftMostChild;
        private Node rightSibling;

    }

    public class FileSystem
    {
        private Node root;
        
        //Creates a file system with a root directory
        public FileSystem()
        {

        }

        //Adds a file at the given address
        //Returns false if the file already exists or the path is undefined; true otherwise
        public bool AddFile(string address)
        {
            return true;
            //return false 

        }

        //Removes the file at the given address 
        // Returns false if the file is not found or the path is undefined; true otherwise 
        public bool RemoveFile(string address)
        {
            return true; 
            //return false; 
        }

        //Adds a directory at the given address
        //Returns false if the directory already exists or the path is undefined; true otherwise
        public bool AddDirectory(string address)
        {
            return true; 
            //return false;
        }

        //Removes the directory at the given address
        //Returns false if the directory is not found or the path is undefined; true otherwise
        public bool RemoveDirectory(string address)
        {
            return true; 
            //return false; 
        }

        //Returns the number of files in the file system
        public int NumberFiles()
        {
            return 1; //placeholder
        }

        //Prints the directories in a pre-order fashion along with their files 
        public void PrintFileSystem()
        {

        }
    }
}
