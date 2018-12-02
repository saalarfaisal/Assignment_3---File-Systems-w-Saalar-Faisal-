/* 
 * COIS 2020 - Data Structures and Algorithms, Trent University Fall 2018 
 * Assignment 3
 * Submitted by: Nikhil Pai Ganesh - 0595517
 *               Salaar Faisal - Student #
 * Description: Using the concept of a binary tree to create a filing system where the root is connects to the left most child and the further directories are considered as a right Sibling and is connected to it's left sibling
 */




using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_3
{
    class MainClass
    {
        static void Main(string[] args)
        {
            Console.Write("Root==>  ");
            FileSystem System = new FileSystem(Console.ReadLine);
            while (true)
                {
                Console.WriteLine("Contol Panel: \n Select 1 to Add a file \n Select 2 to Remove a file \n Select 3 to Add a directory \n Select 4 to Remove Directory \n Select 5 to Count the number of files \n Select 6 to Print the complete File System \n Select 7 to Exit");
                int selection = Int32.Parse(Console.ReadLine());
                switch (selection)
                    {
                    case 0: 
                        break; 
                    case 1: 
                        Console.Write("Address to add file ==>  ");
                        System.AddFile(Console.ReadLine());
                        break;
                    case 2: 
                    case 3: 
                    case 4: 
                    case 5: 
                    case 6: 
                    case 7: 
                        return; 
}
                    

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

    public class FileSystem //Class with the algorithm to build the File System.
    {
        //Creates a file system with a root directory
        private Node root; //Creating a root directory 
        public FileSystem(string firstNode) //Method to initiate a File system and starting with a root 
        {
            root = new Node(firstNode); // referencing the root directory as the first Node.
        }

        //Adds a file at the given address
        //Returns false if the file already exists or the path is undefined; true otherwise
        public bool AddFile(string address) //Adding file into the directory
        {
            Node current = Add(address, root);  //Defining the current position using the given address and root

            if(current.Directory == address)    //if the path entered exists in the current directory 
                {                               // then
                Console.Write ("Name the File ==>");        // ask for the name of the file 
                current.File.Add(Console.ReadLine());       // then add that file to the directory 
                return true;
}
    else{           // else if the file already exists 
            return false; // return false
                }
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
    }
