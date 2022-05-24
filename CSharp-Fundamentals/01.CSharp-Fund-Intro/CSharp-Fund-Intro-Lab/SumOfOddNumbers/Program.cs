using System;

namespace SumOfOddNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int totalSum = 0;

            for (int i = 0; i < n; i++)
            {

                int count = 1 + (i * 2);
                Console.WriteLine(count);
                totalSum += count;
            }

            Console.WriteLine($"Sum: {totalSum}");
        }
    }
}