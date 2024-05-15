using System.IO;
using System.Linq;

namespace CopyBinaryFile
{
    using System;
    public class CopyBinaryFile
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\copyMe.png";
            string outputFilePath = @"..\..\..\copyMe-copy.png";

            CopyFile(inputFilePath, outputFilePath);
        }

        public static void CopyFile(string inputFilePath, string outputFilePath)
        {
            using (var pngToCopy = new FileStream(inputFilePath, FileMode.Open))
            using (var copiedPgn = new FileStream(outputFilePath, FileMode.Create))
            {
                byte[] bufferBytes = new byte[pngToCopy.Length];

                pngToCopy.Read(bufferBytes, 0, bufferBytes.Length);

                copiedPgn.Write(bufferBytes.ToArray(), 0, bufferBytes.Length);
            }
        }
    }
}
