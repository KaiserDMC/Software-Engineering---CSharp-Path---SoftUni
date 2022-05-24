using System;

namespace Histogram
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double percent1 = 0;
            double percent2 = 0;
            double percent3 = 0;
            double percent4 = 0;
            double percent5 = 0;

            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());

                if (number < 200)
                {
                    percent1++;
                }
                else if (number >= 200 && number <= 399)
                {
                    percent2++;
                }
                else if (number >= 400 && number <= 599)
                {
                    percent3++;
                }
                else if (number >= 600 && number <= 799)
                {
                    percent4++;
                }
                else if (number >= 800)
                {
                    percent5++;
                }
            }

            double p1 = percent1 / n * 100;
            double p2 = percent2 / n * 100;
            double p3 = percent3 / n * 100;
            double p4 = percent4 / n * 100;
            double p5 = percent5 / n * 100;

            Console.WriteLine($"{p1:f2}%");
            Console.WriteLine($"{p2:f2}%");
            Console.WriteLine($"{p3:f2}%");
            Console.WriteLine($"{p4:f2}%");
            Console.WriteLine($"{p5:f2}%");
        }
    }
}
