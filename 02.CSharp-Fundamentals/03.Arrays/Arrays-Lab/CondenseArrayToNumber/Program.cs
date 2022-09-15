using System;
using System.Linq;

namespace CondenseArrayToNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            while (numbers.Length > 1)
            {
                int[] numbersCondensed = new int[numbers.Length];

                for (int i = 0; i + 1 < numbers.Length; i++)
                {
                    numbersCondensed[i] = numbers[i] + numbers[i + 1];
                }

                numbersCondensed.CopyTo(numbers, 0);
                Array.Resize(ref numbers, numbersCondensed.Length - 1);
            }

            Console.WriteLine($"{numbers[0]}");
        }
    }
}
