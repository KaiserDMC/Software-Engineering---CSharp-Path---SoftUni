using System;

namespace DivisionWithoutRemainder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            double p1 = 0;
            double p2 = 0;
            double p3 = 0;

            for (int i = 0; i < number; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());

                if (currentNumber % 2 == 0)
                    p1++;

                if (currentNumber % 3 == 0)
                    p2++;

                if (currentNumber % 4 == 0)
                    p3++;
            }

            p1 = (p1 / number) * 100;
            p2 = (p2 / number) * 100;
            p3 = (p3 / number) * 100;

            Console.WriteLine($"{p1:f2}%");
            Console.WriteLine($"{p2:f2}%");
            Console.WriteLine($"{p3:f2}%");
        }
    }
}