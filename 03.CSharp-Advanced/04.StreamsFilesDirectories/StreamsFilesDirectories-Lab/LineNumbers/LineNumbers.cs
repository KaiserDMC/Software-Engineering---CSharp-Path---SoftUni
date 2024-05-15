using System.Runtime.InteropServices;

namespace LineNumbers
{
    using System.IO;
    public class LineNumbers
    {
        static void Main()
        {
            string inputPath = @"..\..\..\Files\input.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            RewriteFileWithLineNumbers(inputPath, outputPath);
        }

        public static void RewriteFileWithLineNumbers(string inputFilePath, string outputFilePath)
        {
            var streamRead = new StreamReader(inputFilePath);
            var streamWriter = new StreamWriter(outputFilePath);

            using (streamRead)
            {
                int counter = 1;

                using (streamWriter)
                {
                    string currentRow = streamRead.ReadLine();

                    while (currentRow != null)
                    {
                        streamWriter.WriteLine($"{counter}. {currentRow}");

                        counter++;

                        currentRow = streamRead.ReadLine();
                    }
                }
            }
        }
    }
}
