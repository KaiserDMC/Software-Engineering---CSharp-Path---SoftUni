using System;
using System.Linq;
using System.Collections.Generic;

namespace ArrayRotation
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numberArray = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int rotations = int.Parse(Console.ReadLine());

            for (int i = 0; i < rotations; i++)
            {
                int lastIndex = numberArray[0];

                for (int j = 0; j < numberArray.Length - 1; j++)
                {
                    numberArray[j] = numberArray[j + 1];
                }

                numberArray[numberArray.Length - 1] = lastIndex;
            }

            foreach (int element in numberArray)
            {
                Console.Write($"{element} ");
            }
        }
    }
}
