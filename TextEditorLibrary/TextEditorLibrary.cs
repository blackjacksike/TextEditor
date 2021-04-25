using System;
using System.IO;
using System.Text;

namespace TextEditorLibrary
{
    public class TextFile
    {
        private string fileName, folderPath, filePath, content;
        private StringBuilder sb = new StringBuilder();
        
        public bool IsRightType()
        {
            if (Path.GetExtension(filePath) == ".txt")
            {
                return true;
            }
            else 
            {
                return false;
            }
        }
        
        public void CreateFile()
        {
            /* First problem: You could create any type of file, not only *.txt. [Solved] */

            try
            {
                Console.WriteLine("Where do you want to create your text file?");
                folderPath = Console.ReadLine();
                Console.WriteLine("Please name your text file.");
                fileName = Console.ReadLine();
                filePath = (folderPath.EndsWith('\\') == true) ? String.Concat(folderPath, fileName) : String.Concat(folderPath + "\\", fileName);
                /* If the path ends with '\', then it will concatenate. Otherwise, it will add that character and then concatenate. */
                if (IsRightType() == true) // can only create the right type of file
                {
                    File.Create(filePath);
                }
                else 
                {
                    Console.WriteLine("Wrong extension.");
                }
            }
            catch (Exception e) 
            {
                Console.WriteLine(e.Message);
            }
        }

        public void EditFile()
        {
            /* Third problem: You can't list all files within a folder. */
            
            try
            {
                Console.WriteLine("Where is the file you want to edit?");
                folderPath = Console.ReadLine();
                Console.WriteLine("Which file do you want to edit?");
                fileName = Console.ReadLine();
                filePath = (folderPath.EndsWith('\\') == true) ? String.Concat(folderPath, fileName) : String.Concat(folderPath + "\\", fileName);

                if (File.Exists(filePath) == true && IsRightType() == true) // if the file exists and is the right type, then you can edit it.
                {
                    Console.WriteLine("Please enter whatever you like.");
                    while(true)
                    {
                        if (Console.ReadKey().Key == ConsoleKey.End)
                        {
                            break;
                        }

                        sb.AppendLine(Console.ReadLine());
                        content = sb.ToString();
                    }

                    File.WriteAllText(filePath, content);
                }
                else if (File.Exists(filePath) == true) // if the file exists, that means that it simply wasn't the right type.
                {
                    Console.WriteLine("Wrong extension.");
                }
                else // failure to meet the above requirement means that both conditions were false.
                {
                    Console.WriteLine($"The file {fileName} does not exist in the path {folderPath}.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void DeleteFile()
        {
            try
            {
                Console.WriteLine("Where is the file you want to delete?");
                folderPath = Console.ReadLine();
                Console.WriteLine("Which file do you want to delete?");
                fileName = Console.ReadLine();
                filePath = (folderPath.EndsWith('\\') == true) ? String.Concat(folderPath, fileName) : String.Concat(folderPath + "\\", fileName);

                if (File.Exists(filePath) == true) // can't delete a file that doesn't exist AND the user can delete any type of file for practical reasons
                {
                    File.Delete(filePath);
                }
                else
                {
                    Console.WriteLine($"The file {fileName} does not exist in the path {folderPath}.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
