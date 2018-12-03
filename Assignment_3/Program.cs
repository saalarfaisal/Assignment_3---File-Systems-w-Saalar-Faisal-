/* 
 * COIS 2020 - Data Structures and Algorithms, Trent University Fall 2018 
 * Assignment 3
 * Submitted by: Nikhil Pai Ganesh - 0595517
 *               Salaar Faisal - Student #
 * Description: Using the concept of a binary tree to create a filing system.
 */

using System; //imported C# library
using System.Collections.Generic; //imported C# library
using System.Linq; //imported C# library
using System.Text; //imported C# library
using System.Threading.Tasks; //imported C# library

namespace Assignment3 //namespace
{
    class Program //class 
    {
        class Node //class 
        {
            public string Directory { get; set; } // creating a sting directory
            public List<string> File { get; set; } //creating a list of strings called file 
            public Node LeftMostChild { get; set; } //creating a Node called leftMostChild 
            public Node RightSibling { get; set; } //creating a Node called rightSibling

            public Node(string directory, List<string> file, Node leftMostChild, Node rightSibling)
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
                LeftMostChild = null;  //defining the LeftMostChild to null
                RightSibling = null; //defining the RightSibling to null
            }
        }
        class FileSystem //Class with the algorithm to build the File System.
        {
            //Creates a file system with a root directory
            public Node root; //Creating a root directory
            int count = 0;
        
            public FileSystem(string start) //Method to initiate a File system and starting with a root
            {
                root = new Node(start); // referencing the root directory as the first Node.
            }
            // Adds a file at the given address
            // Returns false if the file already exists or the path is undefined; true otherwise
            public bool AddFile(string address) //Adding file into the directory
            {
                Node current = moveAlong(address, root); //Defining the current position using the given address and root


                if (current.Directory == address) //if the path entered exists in the current directory 
                {                   // then
                    Console.Write("Name the File ==>  ");   // ask for the name of the file
                    current.File.Add(Console.ReadLine());    // then add that file to the directory 
                    return true;
                }
                else     // else if the file already exists 
                {
                    return false;  // return false
                }
            }
            // Removes the file at the given address
            // Returns false if the file is not found or the path is undefined; true otherwise
            public bool RemoveFile(string address) // Removing file from the directory 
            {
                string directory = address.Remove(address.Length - 1); // from the directory make the length of the address reduce by 1
                string file = address[address.Length - 1].ToString();

                Node current = moveAlong(directory, root); // set the current address by moving along the directory and the root 
                if (current.Directory == directory)  //if the file exists the directory we are currently in  
                {        // then 
                    current.File.Remove(file);  // remove the file

                }
                return false;   // if the file doesnt exist return false;
            }
            // Adds a directory at the given address
            // Returns false if the directory already exists or the path is undefined; true otherwise
            public bool AddDirectory(string address) // Method to add directory 
            {
                Node current = moveAlong(address, root); // find the current node by moving along the address and the root 
                if (current.Directory == address) //if the current directory is in the right adress
                {
                    if (current.LeftMostChild == null) //move along the left most child until you find a null point 
                    {                   // if the null point is found 
                        Console.Write("Name the directory ==>  ");  // Name the directory that you want to add
                        current.LeftMostChild = new Node(current.Directory + Console.ReadLine()); //Add the directory to the tree
                    }
                    else  // if there is no null point found along the left most child 
                    {
                        Node temp = current.LeftMostChild; 
                        while (temp.RightSibling != null) // move along the right sibling of the left most child to find the null point 
                        {
                            temp = temp.RightSibling; // if found 
                        }
                        Console.Write("Name the directory ==>  "); //Name the directory that you want to add 
                        temp.RightSibling = new Node(current.Directory + Console.ReadLine()); // Add the directory there 
                    }
                    return true; // returns true - does the above if the directory doesnt exist
                }
                else // else
                {
                    return false; // return false if the directory alredy exists
                }

            }
            // Removes the directory (and its subdirectories) at the given address
            // Returns false if the directory is not found or the path is undefined; true otherwise
            public bool RemoveDirectory(string address) //method to remove the directory from the file system
            {   
                string parent = address.Remove(address.Length - 1); // defining parent variable 

                Node current = moveAlong(parent, root); // find the current node by moving along the parent and the root node
                if (current.LeftMostChild.Directory == address) // if the given adress is along the left most child
                {
                    current.LeftMostChild = current.LeftMostChild.RightSibling; // the current left most child is the current left most child's right sibling 
                    return true; // directory is found, delete it
                }
                else // else
                    return false; //directory is not found, return false
            }
            // Returns the number of files in the file system
            public int NumberFiles(Node current)    // Faulty Method 
            {
                count++;

                NumberFiles(current.RightSibling);

                NumberFiles(current.LeftMostChild);

                return count;
            }
            // Prints the directories in a pre-order fashion along with their files
            public void PrintFileSystem(Node current)  // printing the file systems in pre-order 
            {
                if (current == null)  
                    return;

                Console.WriteLine(current.Directory); // print the directory
                foreach (string d in current.File)
                {
                    Console.Write("-{0} ", d); // in a pre order treversal fashion 
                }

                PrintFileSystem(current.RightSibling); //calling the right sibling

                PrintFileSystem(current.LeftMostChild); //calling the left most child 
            }
            public Node moveAlong(string address, Node current)     //method to navigate along the nodes to find the given address
            {
                if (current == null)    // if the current address is null
                    return current;     // then return the current node 
                if (address == current.Directory)   // if the address mentioned is the directory 
                {
                    return current; //return current 
                }
                else 
                {
                    if (current.RightSibling != null) //if the current right sibling is not null
                        current = moveAlong(address, current.RightSibling); //move along the right sibling path to find the address 

                    if (current.LeftMostChild != null) // if the current left most sibling is not null 
                        current = moveAlong(address, current.LeftMostChild); // move along the left most sibling path to find the address
                    return current; //return the current node it is on when the address is found 
                }
            }
        }

        static void Main() // main method to call all of the methods mentioned above
        {
            Console.WriteLine ("***********************************************************************************************************"); //Design
            Console.WriteLine ("******************************* COIS 2020 - Data Structures and Algorithms ********************************"); //Design
            Console.WriteLine ("************************************* Assignment - 3 File Systems  ****************************************"); //Design
            Console.WriteLine ("***********************************************************************************************************"); //Design
            Console.Write("Enter Root Directory==>   ");  // Prompt to ask for the root directory 
            FileSystem System = new FileSystem(Console.ReadLine()); //read the root directory and initiate a file system 
            while (true)
            {
                // Prompt to ask for operations to perform
                Console.WriteLine("Contol Panel: \n Select 1 to Add a file \n Select 2 to Remove a file \n Select 3 to Add a directory \n Select 4 to Remove Directory \n Select 5 to Count the number of files \n Select 6 to Print the complete File System \n Select 7 to Exit");
                int operation = Int32.Parse(Console.ReadLine()); // creating an integer variable to read the above operations and Parse them per the switch-case-break operation 
                switch (operation) // parsing the given selection of operation and parse them to identify which operation to perform as per switch-case-break
                {
                    case 0: // if selected 0, then break the program and loop the contol panel 
                        break;
                    case 1:
                        Console.Write("Address to add file ==>  "); // prompt to ask where to add the file 
                        System.AddFile(Console.ReadLine()); // Calling the AddFile method to read the prompt
                        break; //Loop again 
                    case 2:
                        Console.Write("Address to remove the file ==> ");  //prompt to ask where to remove the file from 
                        System.RemoveFile(Console.ReadLine());  // Calling the RomoveFile method to read the prompt
                        break; // Loop Again
                    case 3:
                        Console.Write("Address to Add the directory ==> "); //prompt to ask where to add the directory
                        System.AddDirectory(Console.ReadLine()); // Calling the AddDirectory method to read the prompt
                        break;
                    case 4:
                        Console.Write("Address to remove the directory ==> "); //prompt to ask where to remove the directory from 
                        System.RemoveDirectory(Console.ReadLine()); //Calling the RemoveDirectory method to read the prompt
                        break; // Loop Again
                    case 5:
                        System.NumberFiles(System.root); //Calling the NumberFiles method when option 5 is selected to count the number of files inserted in the file system  
                        break;
                    case 6:
                        System.PrintFileSystem(System.root); //Calling the PrintFileSystem method when option 6 is selected to print the entire file system 
                        break;
                    case 7: 
                        return;  // break the program when option 7 is selected   
                }
            }
        }
    }
}

// Thank You for a great Semester!