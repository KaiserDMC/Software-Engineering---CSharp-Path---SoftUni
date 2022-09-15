using System;

namespace ConvertMetresToKm
{
    class Program
    {
        static void Main(string[] args)
        {
            int metres = int.Parse(Console.ReadLine());

            double kilometres = (double)metres / 1000;
            kilometres = Math.Round(kilometres, 2);

            Console.WriteLine($"{kilometres:f2}");
        }
    }
}
