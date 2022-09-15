using System;

namespace GameOfIntervals
{
    class Program
    {
        static void Main(string[] args)
        {
            int moves = int.Parse(Console.ReadLine());

            double p0 = 0;
            double p1 = 0;
            double p2 = 0;
            double p3 = 0;
            double p4 = 0;
            double pInvalid = 0;
            double points = 0;

            for (int i = 0; i < moves; i++)
            {
                int number = int.Parse(Console.ReadLine());

                if (number >= 0 && number <= 9)
                {
                    points += 0.2 * number;
                    p0++;
                }
                else if (number >= 10 && number < 20)
                {
                    points += 0.3 * number;
                    p1++;
                }
                else if (number >= 20 && number < 30)
                {
                    points += 0.4 * number;
                    p2++;
                }
                else if (number >= 30 && number < 40)
                {
                    points += 50;
                    p3++;
                }
                else if (number >= 40 && number <= 50)
                {
                    points += 100;
                    p4++;
                }
                else if (number < 0 || number > 50)
                {
                    points /= 2;
                    pInvalid++;
                }
            }

            double percentageP0 = (double)p0 / moves * 100;
            double percentageP1 = (double)p1 / moves * 100;
            double percentageP2 = (double)p2 / moves * 100;
            double percentageP3 = (double)p3 / moves * 100;
            double percentageP4 = (double)p4 / moves * 100;
            double percentagePInvalid = (double)pInvalid / moves * 100;

            Console.WriteLine($"{points:f2}");
            Console.WriteLine($"From 0 to 9: {percentageP0:f2}%");
            Console.WriteLine($"From 10 to 19: {percentageP1:f2}%");
            Console.WriteLine($"From 20 to 29: {percentageP2:f2}%");
            Console.WriteLine($"From 30 to 39: {percentageP3:f2}%");
            Console.WriteLine($"From 40 to 50: {percentageP4:f2}%");
            Console.WriteLine($"Invalid numbers: {percentagePInvalid:f2}%");
        }
    }
}
