using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EvenLines
{
    using System;
    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            Dictionary<int, List<string>> textByRows = new Dictionary<int, List<string>>();

            using (var reader = new StreamReader(inputFilePath))
            {
                string curLine = reader.ReadLine();
                int lineCounter = 0;

                while (curLine != null)
                {
                    if (lineCounter % 2 == 0)
                    {
                        textByRows.Add(lineCounter, new List<string>());

                        char[] reverseAndReplace = curLine.ToCharArray();
                        char[] newChars = new char[reverseAndReplace.Length];

                        for (int i = 0; i < reverseAndReplace.Length; i++)
                        {
                            char currChar = reverseAndReplace[i];

                            if (currChar == '-' || currChar == ',' || currChar == '.' || currChar == '!' || currChar == '?')
                            {
                                currChar = '@';
                            }

                            newChars[i] = currChar;
                        }

                        string[] tempString = string.Join("", newChars).Split(" ");

                        for (int i = tempString.Length - 1; i >= 0; i--)
                        {
                            textByRows[lineCounter].Add(tempString[i]);
                        }
                    }

                    lineCounter++;

                    curLine = reader.ReadLine();
                }
            }

            string outputString = String.Empty;

            foreach (var rowText in textByRows)
            {
                foreach (var s in rowText.Value)
                {
                    outputString += s + " ";
                }

                outputString += "\n";
            }

            return outputString;
        }
    }
}
