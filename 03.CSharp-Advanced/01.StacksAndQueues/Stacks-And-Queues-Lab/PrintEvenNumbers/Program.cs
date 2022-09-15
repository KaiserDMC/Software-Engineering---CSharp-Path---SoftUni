using System;
using System.Collections.Generic;
using System.Linq;

namespace PrintEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputNumbers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            Queue<int> tailNumbers = new Queue<int>();

            for (int i = 0; i < inputNumbers.Length; i++)
            {
                int currentNumber = inputNumbers[i];

                if (currentNumber % 2 == 0)
                {
                    tailNumbers.Enqueue(currentNumber);
                }
            }
            
            Console.WriteLine(string.Join(", ", tailNumbers));
        }
    }
}
