using System;
using System.Collections.Generic;
using System.Linq;

namespace MergingLists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstList = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
            List<int> secondList = Console.ReadLine().Split(" ").Select(int.Parse).ToList();

            List<int> finalList = new List<int>();
            int stopIndex = 0;

            if (firstList.Count >= secondList.Count)
            {
                for (int i = 0; i <= secondList.Count - 1; i++)
                {
                    int currentElementFirstList = firstList[i];
                    int currentElementSecondList = secondList[i];

                    finalList.Add(currentElementFirstList);
                    finalList.Add(currentElementSecondList);
                    stopIndex = i;
                }

                for (int j = stopIndex + 1; j <= firstList.Count - 1; j++)
                {
                    int currentElementFirstList = firstList[j];
                    finalList.Add(currentElementFirstList);
                }
            }
            else
            {
                for (int i = 0; i <= firstList.Count - 1; i++)
                {
                    int currentElementFirstList = firstList[i];
                    int currentElementSecondList = secondList[i];

                    finalList.Add(currentElementFirstList);
                    finalList.Add(currentElementSecondList);
                    stopIndex = i;
                }

                for (int j = stopIndex + 1; j <= secondList.Count - 1; j++)
                {
                    int currentElementSecondList = secondList[j];
                    finalList.Add(currentElementSecondList);
                }
            }

            Console.WriteLine(string.Join(" ", finalList));
        }
    }
}
