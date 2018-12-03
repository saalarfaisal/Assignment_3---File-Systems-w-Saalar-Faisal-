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

  namespace Assignment_3{
  class program
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
                        Console.Write("Address to remove the file ==> ");
                        System.RemoveFile(Console.ReadLine());
                        break;
                    case 3: 
                        Console.Write("Address to Add the directory ==> ");
                        System.AddDirectory(Console.ReadLine());
                     case 4:
                        Console.WriteLine("Address to remove the directory ==>  ");
                        System.RemoveDirectory(Console.ReadLine());
                        break;
                    case 5:
                        System.NumberFiles(System.Root);
                        break;
                    case 6:
                        System.PrintFileSystem(System.Root);
                        break;
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
            int num = 0;
        public FileSystem(string firstNode) //Method to initiate a File system and starting with a root 
        {
            root = new Node(firstNode); // referencing the root directory as the first Node.
        }

        //Adds a file at the given address
        //Returns false if the file already exists or the path is undefined; true otherwise
        public bool AddFile(string address) //Adding file into the directory
        {
            Node current = moveAlong(address, root);  //Defining the current position using the given address and root

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
        public bool RemoveFile(string address) // Removing file from the directory 
        {
            string directory = address.Remove(address.Length -1); // from the directory make the length of the address reduce by 1
            string file = address[address.Length - 1].ToString(); 
            
            Node current = moveAlong(directory, root);// set the current address by moving along the directory and the root 
            if(current.Directory == directory) //if the file exists the directory we are currently in  
                    {                               // then 
                    current.File.Remove(file); // remove the file 
}else{ // is the file doesnt exist
          
            return false; //return false; 
      }      
        }

        //Adds a directory at the given address
        //Returns false if the directory already exists or the path is undefined; true otherwise
        public bool AddDirectory(string address)
        {
                Node current = moveAlong(address, root);
                if (current.Directory == address)
                    {
                        if(current.LeftMostChild == null)
                         {
                            Console.Write("Name the directory ==>  ");
                            current.LeftMostChild = new Node(current.Directory + Console.ReadLine());
}else {
                            Node temp = current.LeftMostChild;
                            while (temp.RightSibling != null)
                                {
                                temp = temp.RightSibling;

}
                            Console.Write("Name the directory ==>  ");
                            temp.RightSibling = new Node(current.Directory + Console.ReadLine());
}
                        return true;
                      } 
                    else {
                        return false;
}

    }
                
        //Removes the directory at the given address
        //Returns false if the directory is not found or the path is undefined; true otherwise
        public bool RemoveDirectory(string address)
        {
                string parent = address.Remove(address.Length - 1);

                Node current = moveAlong(parent, Root);
                if (current.LeftMostChild.Directory == address)
                {
                    current.LeftMostChild = current.LeftMostChild.RightSibling;
                    return true;
                }
                else
                    return false;
        }

        //Returns the number of files in the file system
        public int NumberFiles(Node current)
        {
                num++; 

                NumberFiles(current.RightSibling);
                NumberFiles (current.LeftMostChild);

                return num;
           
        }

        //Prints the directories in a pre-order fashion along with their files 
        public void PrintFileSystem(Node current)
        {
                if (current == null)
                    return; 
            Console.WriteLine(current.Directory);
                foreach (string s in current.File)
                    {
                    Console.Write("-{0}", s);
                    }
                PrintFileSystem(current.RightSibling);
                PrintFileSystem(current.LeftMostChild);
                                                 
        }
        
        public Node moveAlong(string address,Node current)
                {
                {
                if(current = null)
                    return current;
                if(address = current.Directory)
                    {
                        return current;
                    }
                else
                    {
                    if (current.RightSibling != null) 
                        current = moveAlong(address, current.RightSibling);

                    if(currrent.LeftMostChild != null)
                        current = moveAlong(address, current.LeftMostChild);
                    return current;
               }
          }     

    }
  }
}
    }