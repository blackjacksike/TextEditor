using System;
using TextEditorLibrary;

namespace TextEditor
{
    
    
    class Program
    {
        static void Main(string[] args)
        {
            TextFile textFile = new TextFile();

            while (true) 
            {
                Console.WriteLine("This is a text editor. Type 'help' if you're unsure what to do.");
                string choice = Console.ReadLine();

                switch (choice) 
                {
                    case "create":
                        textFile.CreateFile();
                        continue;

                    case "edit":
                        textFile.EditFile();
                        continue;

                    case "delete":
                        textFile.DeleteFile();
                        continue;

                    case "help":
                        Console.WriteLine("create-Create a file.\nedit-Edit a file.\ndelete-Delete a file.\nexit-Exit the program.");
                        continue;

                    case "exit":
                        Console.WriteLine("Press <Enter> to exit...");
                        while (Console.ReadKey().Key != ConsoleKey.Enter) { } // makes sure that only the Enter key will close the program
                        break;

                    default:
                        Console.WriteLine("Wrong input.");
                        continue;
                }
                break;
            }
        }
    }
}
