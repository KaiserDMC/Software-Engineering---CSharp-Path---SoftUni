using System;

namespace MountainRun
{
    class Program
    {
        static void Main(string[] args)
        {
            double recordInSeconds = double.Parse(Console.ReadLine());
            double distanceMetres = double.Parse(Console.ReadLine());
            double timeForOneMetre = double.Parse(Console.ReadLine());

            double runTime = distanceMetres * timeForOneMetre;
            double additionalTime = Math.Floor(distanceMetres / 50) * 30;

            double totalRunTime = runTime + additionalTime;

            double difference = recordInSeconds - totalRunTime;

            if (difference > 0)
            {
                Console.WriteLine($"Yes! The new record is {totalRunTime:f2} seconds.");
            }
            else
            {
                Console.WriteLine($"No! He was {Math.Abs(difference):f2} seconds slower.");
            }
        }
    }
}
