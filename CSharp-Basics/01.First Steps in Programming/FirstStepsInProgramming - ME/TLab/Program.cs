using System;

namespace TLab
{
    class Program
    {
        static void Main(string[] args)
        {
            double w = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());

            double desksPerRow = ((h * 100) - 100) / 70;
            desksPerRow = Math.Floor(desksPerRow);
            double rows = (w * 100) / 120;
            rows = Math.Floor(rows);

            double availablePlaces = (desksPerRow * rows) - 3;

            Console.WriteLine(availablePlaces);
        }
    }
}
