using System.Collections.Generic;
using System.Text;

namespace ExtractBytes
{
    using System;
    using System.IO;
    public class ExtractBytes
    {
        static void Main()
        {
            string binaryFilePath = @"..\..\..\Files\example.png";
            string bytesFilePath = @"..\..\..\Files\bytes.txt";
            string outputPath = @"..\..\..\Files\output.bin";

            ExtractBytesFromBinaryFile(binaryFilePath, bytesFilePath, outputPath);
        }

        public static void ExtractBytesFromBinaryFile(string binaryFilePath, string bytesFilePath, string outputPath)
        {
            List<byte> bytesFromFile = new List<byte>();

            using (var streamBytes = new StreamReader(bytesFilePath))
            {
                string currentByte = streamBytes.ReadLine();

                while (currentByte != null)
                {
                    bytesFromFile.Add(byte.Parse(currentByte));

                    currentByte = streamBytes.ReadLine();
                }
            }

            List<byte> commonList = new List<byte>();

            using (var streamPNG = new FileStream(binaryFilePath, FileMode.Open))
            using (var streamOutput = new FileStream(outputPath, FileMode.Create))
            {
                byte[] bufferBytes = new byte[streamPNG.Length];

                streamPNG.Read(bufferBytes, 0, bufferBytes.Length);

                for (int i = 0; i < bufferBytes.Length; i++)
                {
                    byte bytesRead = bufferBytes[i];

                    if (bytesFromFile.Contains(bytesRead))
                    {
                        commonList.Add(bytesRead);
                    }
                }
                streamOutput.Write(commonList.ToArray(), 0, commonList.Count);
            }
        }
    }
}
