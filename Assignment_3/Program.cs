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
        private string directory {get; set;} // creating a sting directory 
        private List<string> file {get; set;} //creating a list of strings called file 
        private Node leftMostChild {get; set;} //creating a Node called leftMostChild 
        private Node rightSibling {get; set;} //creating a Node called rightSibling

        public Node(string directory, List<string>file, Node leftMostChild, Node rightSibling ) 
            {
            Directory = directory; //referencing it to the above created Node 
            File = file; //referencing it to the above created node 
            LeftMostChild = leftMostChild; //referencing it to the above created node 
            RightSibling = rightSibling; //referencing it to the above created node
            }

        public Node(string directory) // method to define the directory and its references 
            {
            Directory = directory; //referencing it again in the new method
            File = new List<string>(); // Defining the refernce as a list of strings
            LeftMostChild = null; //defining the LeftMostChild to null
            RightSibling = null; //defining the LeftMostChild to null
            }          

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
