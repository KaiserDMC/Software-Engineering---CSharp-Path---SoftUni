using System;

namespace MointainRun
{
    class Program
    {
        static void Main(string[] args)
        {
            double recordInSeconds = double.Parse(Console.ReadLine());
            double distanceMetres = double.Parse(Console.ReadLine());
            double timeFor1Metre = double.Parse(Console.ReadLine());

            double runTime = distanceMetres * timeFor1Metre;

            double additionalTime = Math.Floor(distanceMetres / 50) * 30;

            double totalTime = runTime + additionalTime;

            double difference = recordInSeconds - totalTime;

            if (difference > 0)
            {
                Console.WriteLine($"Yes! The new record is {totalTime:f2} seconds.");
            }
            else
            {
                Console.WriteLine($"No! He was {Math.Abs(difference):f2} seconds slower.");
            }
        }
    }
}
