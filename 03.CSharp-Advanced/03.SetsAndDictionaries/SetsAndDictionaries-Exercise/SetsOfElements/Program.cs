using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace SetsOfElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] setLengths = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            HashSet<int> firstSet = new HashSet<int>();
            HashSet<int> secondSet = new HashSet<int>();

            for (int i = 0; i < setLengths[0] + setLengths[1]; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());

                if (i < setLengths[0])
                {
                    firstSet.Add(currentNumber);
                    continue;
                }

                secondSet.Add(currentNumber);
            }

            firstSet.IntersectWith(secondSet);

            Console.WriteLine(string.Join(" ", firstSet));
        }
    }
}
