using System;

namespace ExtractFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string pathString = Console.ReadLine();

            int indexOfLastDirectory = pathString.LastIndexOf((char)92);
            int indexOfDotForExtension = pathString.LastIndexOf((char)46);

            int lenghtOfFileName = indexOfDotForExtension - indexOfLastDirectory;

            string fileName = pathString.Substring(indexOfLastDirectory + 1, lenghtOfFileName - 1);
            string extensionName = pathString.Substring(indexOfDotForExtension + 1);

            Console.WriteLine($"File name: {fileName}");
            Console.WriteLine($"File extension: {extensionName}");
        }
    }
}
