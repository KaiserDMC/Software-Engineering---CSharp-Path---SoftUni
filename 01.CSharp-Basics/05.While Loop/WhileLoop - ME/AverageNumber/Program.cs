using System;

namespace AverageNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sum = 0;
            double average = 0;

            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());
                sum += number;
            }

            average = (double)sum / n;

            Console.WriteLine($"{average:f2}");
        }
    }
}
