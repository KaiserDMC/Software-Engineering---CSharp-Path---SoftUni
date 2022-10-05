using System.IO;

namespace CopyDirectory
{
    using System;
    public class CopyDirectory
    {
        static void Main()
        {
            string inputPath =  @$"{Console.ReadLine()}";
            string outputPath = @$"{Console.ReadLine()}";

            CopyAllFiles(inputPath, outputPath);
        }

        public static void CopyAllFiles(string inputPath, string outputPath)
        {
            foreach (var directoryPath in Directory.GetDirectories(inputPath,"*", SearchOption.TopDirectoryOnly))
            {
                Directory.CreateDirectory((directoryPath.Replace(inputPath, outputPath)));
            }

            foreach (var output in Directory.GetFiles(inputPath, "*.*", SearchOption.TopDirectoryOnly))
            {
                File.Copy(inputPath,output.Replace(inputPath,outputPath),true);
            }
        }
    }
}
