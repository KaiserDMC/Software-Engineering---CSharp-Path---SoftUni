using System;

namespace WorldSwimmingRecord
{
    class Program
    {
        static void Main(string[] args)
        {
            double worldRecordTime = double.Parse(Console.ReadLine());
            double worldRecordDistance = double.Parse(Console.ReadLine());
            double timeToSwimOneMetre = double.Parse(Console.ReadLine());

            double timeToSwimFullDistance = worldRecordDistance * timeToSwimOneMetre;
            timeToSwimFullDistance = timeToSwimFullDistance + (Math.Floor((worldRecordDistance / 15)) * 12.5);

            double worldRecordDifference = timeToSwimFullDistance - worldRecordTime;

            if (worldRecordDifference >= 0)
            {
                Console.WriteLine($"No, he failed! He was {worldRecordDifference:f2} seconds slower.");
            }
            else
            {
                Console.WriteLine($"Yes, he succeeded! The new world record is {timeToSwimFullDistance:f2} seconds.");
            }
        }
    }
}
