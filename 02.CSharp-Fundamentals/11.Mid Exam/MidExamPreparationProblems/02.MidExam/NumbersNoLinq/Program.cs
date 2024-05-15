using System;
using System.Collections.Generic;
using System.Linq;

namespace NumbersNoLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] integersArray = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            double averageValue = 0;
            int maxValue = int.MinValue;
            int index = 0;

            for (int i = 0; i < integersArray.Length; i++)
            {
                averageValue += integersArray[i];
            }

            averageValue /= integersArray.Length;

            List<int> topIntegersList = new List<int>();
            for (int i = 0; i < integersArray.Length; i++)
            {
                if (integersArray[i] > averageValue)
                {
                    topIntegersList.Add(integersArray[i]);
                }
            }

            List<int> finalTopIntList = new List<int>();
            if (topIntegersList.Count != 0)
            {

                for (int i = 0; i < 5; i++)
                {
                    maxValue = topIntegersList[0];

                    for (int j = 1; j < topIntegersList.Count; j++)
                    {
                        if (maxValue < topIntegersList[j])
                        {
                            maxValue = topIntegersList[j];
                            index = j;
                        }
                    }

                    if (finalTopIntList.Count < topIntegersList.Count)
                    {
                        finalTopIntList.Add(maxValue);
                    }

                    topIntegersList[index] = int.MinValue;
                }
            }

            if (finalTopIntList.Count == 0)
            {
                Console.WriteLine($"No");
            }
            else
            {
                Console.WriteLine(string.Join(" ", finalTopIntList));
            }
        }
    }
}
