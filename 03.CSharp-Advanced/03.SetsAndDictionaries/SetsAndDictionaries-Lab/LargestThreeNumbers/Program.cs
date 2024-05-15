using System;
using System.Collections.Generic;
using System.Linq;

namespace LargestThreeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> inputNumbers = Console.ReadLine().Split(" ").Select(int.Parse).ToList();

            inputNumbers = inputNumbers.OrderByDescending(x => x).Take(3).ToList();

            foreach (var number in inputNumbers)
            {
                Console.Write($"{number} ");
            }
        }
    }
}
