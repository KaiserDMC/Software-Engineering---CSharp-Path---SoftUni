using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicQueueOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputParameters = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            int[] numberIntegers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            Queue<int> queueNumbers = new Queue<int>();

            for (int i = 0; i < inputParameters[0]; i++)
            {
                queueNumbers.Enqueue(numberIntegers[i]);
            }

            for (int j = 0; j < inputParameters[1]; j++)
            {
                queueNumbers.Dequeue();
            }

            if (queueNumbers.Count > 0)
            {
                if (queueNumbers.Contains(inputParameters[2]))
                {
                    Console.WriteLine($"true");
                }
                else
                {
                    Console.WriteLine($"{queueNumbers.Min()}");
                }
            }
            else
            {
                Console.WriteLine($"{0}");
            }
        }
    }
}
