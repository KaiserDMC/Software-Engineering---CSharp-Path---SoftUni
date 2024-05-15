using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LineNumbers
{
    using System;
    public class LineNumbers
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";
            string outputFilePath = @"..\..\..\output.txt";

            ProcessLines(inputFilePath, outputFilePath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            string[] separateRows = File.ReadAllLines(inputFilePath);

            int indexRow = 1;

            for (int i = 0; i < separateRows.Length; i++)
            {
                string toAddLine = "Line " + indexRow + ": ";

                int countLetters = separateRows[i].Count(l => Char.IsLetter(l));
                int countPunkt = separateRows[i].Count(p => Char.IsPunctuation(p));

                separateRows[i] = toAddLine + separateRows[i] + $" ({countLetters})({countPunkt})";

                indexRow++;
            }
            
            File.WriteAllLines(outputFilePath, separateRows);
        }
    }
}
