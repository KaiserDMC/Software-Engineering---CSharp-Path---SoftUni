using System;
using System.Linq;

namespace MagicSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int equalSum = int.Parse(Console.ReadLine());

            for (int i = 0; i < numbers.Length; i++)
            {
                int currNumber = numbers[i];

                for (int j = i + 1; j < numbers.Length; j++)
                {
                    int nextNumber = numbers[j];

                    if (currNumber + nextNumber == equalSum)
                    {
                        Console.WriteLine($"{currNumber} {nextNumber}");
                    }
                }
            }
        }
    }
}
