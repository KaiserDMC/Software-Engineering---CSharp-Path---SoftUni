using System;

namespace LeftAndRightSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sum1 = 0;
            int sum2 = 0;

            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());
                sum1 += number;
            }

            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());
                sum2 += number;
            }

            int totalsum = sum1;
            int difference = Math.Abs(sum1 - sum2);
            if (sum1 == sum2)
            {
                Console.WriteLine($"Yes, sum = {totalsum}");
            }
            else
            {
                Console.WriteLine($"No, diff = {difference}");
            }
        }
    }
}
