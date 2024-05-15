using System;
using System.Collections.Generic;
using System.Linq;

namespace CarRace
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> raceList = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
            int raceLength = raceList.Count / 2;
            double timeFirstDriver = 0;
            double timeSecondDriver = 0;

            for (int i = 0; i < raceLength; i++)
            {
                int currentTime = raceList[i];
                timeFirstDriver += currentTime;

                if (currentTime == 0)
                {
                    timeFirstDriver *= 0.8;
                }

            }

            for (int i = raceList.Count - 1; i > raceLength; i--)
            {
                int currentTime = raceList[i];
                timeSecondDriver += currentTime;

                if (currentTime == 0)
                {
                    timeSecondDriver *= 0.8;
                }
            }

            if (timeFirstDriver < timeSecondDriver)
            {
                int wholeNumber;
                bool result = int.TryParse(timeFirstDriver.ToString(), out wholeNumber);

                if (result)
                {
                    Console.WriteLine($"The winner is left with total time: {timeFirstDriver}");
                }
                else
                {
                    Console.WriteLine($"The winner is left with total time: {timeFirstDriver:f1}");
                }

            }
            else
            {
                int wholeNumber;
                bool result = int.TryParse(timeSecondDriver.ToString(), out wholeNumber);

                if (result)
                {
                    Console.WriteLine($"The winner is right with total time: {timeSecondDriver}");
                }
                else
                {
                    Console.WriteLine($"The winner is right with total time: {timeSecondDriver:f1}");
                }
            }
        }
    }
}
