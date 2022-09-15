using System;

namespace OddEvenSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sumEven = 0;
            int sumOdd = 0;

            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());

                if (i % 2 == 0)
                {
                    sumEven += number;
                }
                else
                {
                    sumOdd += number;
                }
            }

            int totalsum = sumEven;
            int difference = Math.Abs(sumEven - sumOdd);
            if (sumEven == sumOdd)
            {
                Console.WriteLine($"Yes");
                Console.WriteLine($"Sum = {totalsum}");
            }
            else
            {
                Console.WriteLine($"No");
                Console.WriteLine($"Diff = {difference}");
            }
        }
    }
}
