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
            throw new NotImplementedException();
        }
    }
}
