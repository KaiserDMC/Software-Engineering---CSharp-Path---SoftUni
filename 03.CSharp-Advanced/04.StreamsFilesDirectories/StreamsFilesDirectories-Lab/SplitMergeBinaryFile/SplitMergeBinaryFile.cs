using System.Collections.Generic;

namespace SplitMergeBinaryFile
{
    using System;
    using System.IO;
    using System.Linq;

    public class SplitMergeBinaryFile
    {
        static void Main()
        {
            string sourceFilePath = @"..\..\..\Files\example.png";
            string joinedFilePath = @"..\..\..\Files\example-joined.png";
            string partOnePath = @"..\..\..\Files\part-1.bin";
            string partTwoPath = @"..\..\..\Files\part-2.bin";

            SplitBinaryFile(sourceFilePath, partOnePath, partTwoPath);
            MergeBinaryFiles(partOnePath, partTwoPath, joinedFilePath);
        }

        public static void SplitBinaryFile(string sourceFilePath, string partOneFilePath, string partTwoFilePath)
        {
            using (var streamPNG = new FileStream(sourceFilePath, FileMode.Open))
            using (var part1Output = new FileStream(partOneFilePath, FileMode.Create))
            using (var part2Output = new FileStream(partTwoFilePath, FileMode.Create))
            {
                byte[] bufferFirstBytes = new byte[(streamPNG.Length + 1) / 2];

                streamPNG.Read(bufferFirstBytes, 0, bufferFirstBytes.Length);

                part1Output.Write(bufferFirstBytes.ToArray(), 0, bufferFirstBytes.Length);

                byte[] bufferSecondBytes = new byte[streamPNG.Length / 2];

                streamPNG.Read(bufferSecondBytes, 0, bufferSecondBytes.Length);

                part2Output.Write(bufferSecondBytes.ToArray(), 0, bufferSecondBytes.Length);
            }
        }

        public static void MergeBinaryFiles(string partOneFilePath, string partTwoFilePath, string joinedFilePath)
        {
            using (var fileJoined = new FileStream(joinedFilePath, FileMode.Create))
            {
                byte[] firstBytes = null;

                using (var fileOne = new FileStream(partOneFilePath, FileMode.Open))
                {
                    firstBytes = new byte[fileOne.Length];
                    fileJoined.Write(firstBytes);
                }

                byte[] secondBytes = null;

                using (var fileTwo = new FileStream(partTwoFilePath, FileMode.Open))
                {
                    secondBytes = new byte[fileTwo.Length];
                    fileJoined.Write(secondBytes, 0, secondBytes.Length);
                }
            }
        }
    }
}