using System;
using System.Linq;
using System.Collections.Generic;

namespace Zig_ZagArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            int[] finalArrayOne = new int[input];
            int[] finalArrayTwo = new int[input];
            bool isEven = false;

            for (int i = 0; i < input; i++)
            {
                int[] zigZagArray = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

                isEven = i % 2 == 0;

                if (!isEven)
                {
                    finalArrayOne[i] = zigZagArray[1];
                    finalArrayTwo[i] = zigZagArray[0];
                }
                else
                {
                    finalArrayOne[i] = zigZagArray[0];
                    finalArrayTwo[i] = zigZagArray[1];
                }

            }

            foreach (int element in finalArrayOne)
            {
                Console.Write($"{element} ");
            }

            Console.WriteLine();

            foreach (int element in finalArrayTwo)
            {
                Console.Write($"{element} ");
            }
        }
    }
}
