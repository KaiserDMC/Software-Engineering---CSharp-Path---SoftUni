using System.Collections.Generic;

namespace MergeFiles
{
    using System;
    using System.IO;
    public class MergeFiles
    {
        static void Main()
        {
            var firstInputFilePath = @"..\..\..\Files\input1.txt";
            var secondInputFilePath = @"..\..\..\Files\input2.txt";
            var outputFilePath = @"..\..\..\Files\output.txt";

            MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
        }

        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {
            List<string> rowsList1 = new List<string>();
            List<string> rowsList2 = new List<string>();

            using (var reader1 = new StreamReader(firstInputFilePath))
            {
                string currentRow = reader1.ReadLine();

                while (currentRow != null)
                {
                    rowsList1.Add(currentRow);

                    currentRow = reader1.ReadLine();
                }


            }

            using (var reader2 = new StreamReader(secondInputFilePath))
            {
                string currentRow = reader2.ReadLine();

                while (currentRow != null)
                {
                    rowsList2.Add(currentRow);

                    currentRow = reader2.ReadLine();
                }
            }

            int largestText = Math.Max(rowsList1.Count, rowsList2.Count);
            List<string> tempList = rowsList1.Count > rowsList2.Count ? rowsList1 : rowsList2;
            int minimumText = Math.Min(rowsList1.Count, rowsList2.Count);

            using (var writer = new StreamWriter(outputFilePath))
            {
                for (int i = 0; i < largestText; i++)
                {
                    if (i < minimumText)
                    {
                        writer.WriteLine(rowsList1[i]);
                        writer.WriteLine(rowsList2[i]);
                    }
                    else
                    {
                        writer.WriteLine(tempList[i]);
                    }
                }
            }
        }
    }
}
