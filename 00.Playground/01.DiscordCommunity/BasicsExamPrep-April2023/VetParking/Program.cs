using System;

namespace VetParking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int hours = int.Parse(Console.ReadLine());

            double currentPrice = 0;
            double total = 0;

            for (int i = 1; i <= days; i++)
            {
                for (int j = 1; j <= hours; j++)
                {
                    if (i % 2 == 0 && j % 2 != 0)
                    {
                        currentPrice += 2.5;
                    }
                    else if (i % 2 != 0 && j % 2 == 0)
                    {
                        currentPrice += 1.25;
                    }
                    else
                    {
                        currentPrice += 1;
                    }
                }

                total += currentPrice;

                Console.WriteLine($"Day: {i} - {currentPrice:f2} leva");
                currentPrice = 0;
            }

            Console.WriteLine($"Total: {total:f2} leva");
        }
    }
}