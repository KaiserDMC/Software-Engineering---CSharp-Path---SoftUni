using System;
using System.Collections.Generic;
using System.Linq;

namespace RemoveNegativesAndReverse
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numberList = Console.ReadLine().Split(" ").Select(int.Parse).ToList();

            for (int i = 0; i < numberList.Count; i++)
            {
                if (numberList[i] < 0)
                {
                    numberList.RemoveAt(i);
                    i = -1;
                }
            }

            if (numberList.Count == 0)
            {
                Console.WriteLine($"empty");
            }
            else
            {
                numberList.Reverse();
                Console.WriteLine(string.Join(" ", numberList));
            }
        }
    }
}
