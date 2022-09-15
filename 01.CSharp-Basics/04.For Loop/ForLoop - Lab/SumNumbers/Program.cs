using System;

namespace SumNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double sum = 0;

            for (int i = 1; i <= n; i++)
            {
                double number = double.Parse(Console.ReadLine());
                sum += number;
            }

            Console.WriteLine(sum);
        }

    }
}
