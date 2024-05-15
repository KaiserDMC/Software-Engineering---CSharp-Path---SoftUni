namespace FolderSize
{
    using System;
    using System.IO;
    public class FolderSize
    {
        static void Main(string[] args)
        {
            string folderPath = @"..\..\..\Files\TestFolder";
            string outputPath = @"..\..\..\Files\output.txt";

            GetFolderSize(folderPath, outputPath);
        }

        public static void GetFolderSize(string folderPath, string outputFilePath)
        {
            DirectoryInfo dirs = new DirectoryInfo(folderPath);
            FileInfo[] filesInfos = dirs.GetFiles("*", SearchOption.AllDirectories);
            double size = 0;

            for (int i = 0; i < filesInfos.Length; i++)
            {
                size += filesInfos[i].Length;
            }

            size /= 1024.0;

            File.WriteAllText(outputFilePath, size.ToString() + " KB");
        }
    }
}
