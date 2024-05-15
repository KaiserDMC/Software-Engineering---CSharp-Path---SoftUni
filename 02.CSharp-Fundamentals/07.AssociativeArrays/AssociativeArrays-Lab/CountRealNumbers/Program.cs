using System;
using System.Collections.Generic;
using System.Linq;

namespace CountRealNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<int, int> realNumbersByCountDictionary = new SortedDictionary<int, int>();

            int[] realNumbers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            foreach (int realNumber in realNumbers)
            {
                if (!realNumbersByCountDictionary.ContainsKey(realNumber))
                {
                    realNumbersByCountDictionary.Add(realNumber, 0);
                }

                realNumbersByCountDictionary[realNumber]++;
            }

            foreach (var realNumber in realNumbersByCountDictionary)
            {
                Console.WriteLine($"{realNumber.Key} -> {realNumber.Value}");
            }
        }
    }
}
