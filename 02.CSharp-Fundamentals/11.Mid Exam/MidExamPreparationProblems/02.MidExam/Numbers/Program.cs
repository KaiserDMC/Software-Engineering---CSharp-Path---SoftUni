using System;
using System.Collections.Generic;
using System.Linq;

namespace Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] integersArray = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            double averageValue = 0;

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

            var finalTopIntList = topIntegersList.OrderByDescending(x => x).Take(5);

            if (topIntegersList.Count == 0)
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
