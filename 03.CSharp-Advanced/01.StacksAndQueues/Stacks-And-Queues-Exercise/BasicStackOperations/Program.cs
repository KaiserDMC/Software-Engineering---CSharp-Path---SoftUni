using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BasicStackOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputParameters = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            int[] numberIntegers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            Stack<int> stackNumbers = new Stack<int>();

            for (int i = 0; i < inputParameters[0]; i++)
            {
                stackNumbers.Push(numberIntegers[i]);
            }

            for (int j = 0; j < inputParameters[1]; j++)
            {
                stackNumbers.Pop();
            }

            if (stackNumbers.Count > 0)
            {
                if (stackNumbers.Contains(inputParameters[2]))
                {
                    Console.WriteLine($"true");
                }
                else
                {
                    Console.WriteLine($"{stackNumbers.Min()}");
                }
            }
            else
            {
                Console.WriteLine($"{0}");
            }
        }
    }
}
