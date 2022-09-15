using System;

namespace LunchBreak
{
    class Program
    {
        static void Main(string[] args)
        {
            string seriesName = Console.ReadLine();
            int seriesLenght = int.Parse(Console.ReadLine());
            int breakLenght = int.Parse(Console.ReadLine());

            double lunchTime = breakLenght * 0.125;
            double relaxTime = breakLenght * 0.25;

            double timeLeft = breakLenght - (lunchTime + relaxTime);

            double timeDifference = timeLeft - seriesLenght;

            if (timeDifference >= 0)
            {
                Console.WriteLine($"You have enough time to watch {seriesName} and left with {Math.Ceiling(timeDifference)} minutes free time.");
            }
            else
            {
                Console.WriteLine($"You don't have enough time to watch {seriesName}, you need {Math.Ceiling(Math.Abs(timeDifference))} more minutes.");
            }
        }
    }
}
