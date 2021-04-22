using System;
using System.IO;

namespace TextEditorLibrary
{
    public class TextFile
    {
        private string fileName;
        private string folderPath;
        private string filePath;
        private string content;

        public void CreateFile()
        {
            Console.WriteLine("Where do you want to create your text file?");
            folderPath = Console.ReadLine();
            Console.WriteLine("Please name your text file.");
            fileName = Console.ReadLine();
            filePath = (folderPath.EndsWith('\\') == true) ? String.Concat(folderPath, fileName) : String.Concat(folderPath + "\\", fileName);
            /* If the path ends with '\', then it will concatenate. Otherwise, it will add that character and then concatenate. */
            File.Create(filePath);
        }

        public void EditFile()
        {
            Console.WriteLine("Where is the file you want to edit?");
            folderPath = Console.ReadLine();
            Console.WriteLine("Which file do you want to edit?");
            fileName = Console.ReadLine();
            filePath = (folderPath.EndsWith('\\') == true) ? String.Concat(folderPath, fileName) : String.Concat(folderPath + "\\", fileName);
            Console.WriteLine("Please enter whatever you like.");
            content = Console.ReadLine();
            File.WriteAllText(filePath, content);
        }

        public void DeleteFile()
        {
            Console.WriteLine("Where is the file you want to delete?");
            folderPath = Console.ReadLine();
            Console.WriteLine("Which file do you want to delete?");
            fileName = Console.ReadLine();
            filePath = (folderPath.EndsWith('\\') == true) ? String.Concat(folderPath, fileName) : String.Concat(folderPath + "\\", fileName);
            File.Delete(filePath);
        }
    }
}
