using System;
using System.Collections.Generic;
using System.Linq;

namespace MixedUpLists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numberListOne = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
            List<int> numberListTwo = Console.ReadLine().Split(" ").Select(int.Parse).ToList();

            int longestList = Math.Max(numberListOne.Count, numberListTwo.Count);
            List<int> concatenatedList = new List<int>();
            List<int> constraintsList = new List<int>();

            bool firstListIsBigger = numberListOne.Count == longestList;

            if (firstListIsBigger)
            {
                constraintsList.Add(numberListOne[numberListOne.Count - 1]);
                constraintsList.Add(numberListOne[numberListOne.Count - 2]);

                int indexSecondList = longestList - 2;
                for (int i = 0; i < longestList - 2; i++)
                {
                    concatenatedList.Add(numberListOne[i]);
                    concatenatedList.Add(numberListTwo[indexSecondList - 1]);
                    indexSecondList--;
                }
            }
            else
            {
                constraintsList.Add(numberListTwo[0]);
                constraintsList.Add(numberListTwo[1]);

                int indexSecondList = numberListTwo.Count;
                for (int i = 0; i < longestList - 2; i++)
                {
                    concatenatedList.Add(numberListOne[i]);
                    concatenatedList.Add(numberListTwo[indexSecondList - 1]);
                    indexSecondList--;
                }
            }

            List<int> outputList = new List<int>();
            int minValueConstraint = Math.Min(constraintsList[0], constraintsList[1]);
            int maxValueConstraint = Math.Max(constraintsList[0], constraintsList[1]);
            for (int j = 0; j < concatenatedList.Count; j++)
            {
                if (concatenatedList[j] > minValueConstraint && concatenatedList[j] < maxValueConstraint)
                {
                    outputList.Add(concatenatedList[j]);
                }
            }

            outputList.Sort();
            Console.WriteLine(string.Join(" ", outputList));
        }
    }
}
