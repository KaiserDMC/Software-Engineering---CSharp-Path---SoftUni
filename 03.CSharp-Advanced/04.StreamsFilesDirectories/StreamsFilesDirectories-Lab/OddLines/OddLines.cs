using System.Collections.Generic;
using System.Security.Cryptography;

namespace OddLines
{
    using System.IO;

    public class OddLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\Files\input.txt";
            string outputFilePath = @"..\..\..\Files\output.txt";

            ExtractOddLines(inputFilePath, outputFilePath);
        }

        public static void ExtractOddLines(string inputFilePath, string outputFilePath)
        {
            var streamRead = new StreamReader(inputFilePath);
            var streamWriter = new StreamWriter(outputFilePath);

            using (streamRead)
            {
                int counter = 0;

                using (streamWriter)
                {
                    while (true)
                    {
                        string currentRow = streamRead.ReadLine();

                        if (currentRow == null)
                        {
                            break;
                        }

                        if (counter % 2 != 0)
                        {
                            streamWriter.WriteLine(currentRow);
                        }

                        counter++;
                    }
                }
            }
        }
    }
}
