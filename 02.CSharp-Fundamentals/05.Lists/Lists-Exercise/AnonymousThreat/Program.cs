using System;
using System.Collections.Generic;
using System.Linq;

namespace AnonymousThreat
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> inputString = Console.ReadLine().Split(" ").ToList();
            string[] input = Console.ReadLine().Split(" ").ToArray();

            while (input[0] != "3:1")
            {
                string[] commandSequence = input;
                string commandToken = commandSequence[0];

                switch (commandToken)
                {
                    case "merge":
                        int startIndex = int.Parse(commandSequence[1]);
                        int endIndex = int.Parse(commandSequence[2]);
                        string concatenatedList = MergeLists(inputString, startIndex, endIndex);
                        int newStartIndex = FixedStartIndex(inputString, startIndex);
                        int newEndIndex = FixedEndIndex(inputString, endIndex);
                        inputString.RemoveRange(newStartIndex, newEndIndex - newStartIndex + 1);
                        inputString.Insert(newStartIndex, concatenatedList);
                        break;
                    case "divide":
                        int index = int.Parse(commandSequence[1]);
                        int partitions = int.Parse(commandSequence[2]);
                        List<string> dividedList = DivideLists(inputString, index, partitions);
                        inputString.InsertRange(index, dividedList);
                        break;
                }

                input = Console.ReadLine().Split(" ").ToArray();
            }

            Console.WriteLine(string.Join(" ", inputString));
        }

        static string MergeLists(List<string> inputString, int startIndex, int endIndex)
        {
            string concatenatedList = String.Empty;

            if (startIndex < 0 || startIndex >= inputString.Count)
            {
                startIndex = 0;
            }

            if (endIndex >= inputString.Count || endIndex < 0)
            {
                endIndex = inputString.Count - 1;
            }

            for (int i = startIndex; i <= endIndex; i++)
            {
                concatenatedList += inputString[i];
            }

            return concatenatedList;
        }

        static int FixedStartIndex(List<string> inputString, int startIndex)
        {
            if (startIndex < 0 || startIndex >= inputString.Count)
            {
                startIndex = 0;
            }

            return startIndex;
        }

        static int FixedEndIndex(List<string> inputString, int endIndex)
        {
            if (endIndex >= inputString.Count || endIndex < 0)
            {
                endIndex = inputString.Count - 1;
            }

            return endIndex;
        }

        static List<string> DivideLists(List<string> inputString, int index, int partitions)
        {
            List<string> dividedList = new List<string>();
            string stringToDivide = inputString[index];
            inputString.RemoveAt(index);
            int stringToDivideLength = stringToDivide.Length;
            int dividedParts = stringToDivideLength / partitions;

            for (int i = 0; i < partitions; i++)
            {
                if (i == partitions - 1)
                {
                    dividedList.Add((stringToDivide.Substring(i * dividedParts)));
                }
                else
                {
                    dividedList.Add((stringToDivide.Substring(i * dividedParts, dividedParts)));
                }
            }

            return dividedList;
        }
    }
}
