using System;

namespace SleepyTomCat
{
    class Program
    {
        static void Main(string[] args)
        {
            int vacationDays = int.Parse(Console.ReadLine());

            int workingDays = 365 - vacationDays;
            int totalPlayTime = (workingDays * 63) + (vacationDays * 127);
            int normPlayTime = 30000;

            int difference = normPlayTime - totalPlayTime;
            int differenceInHrs = difference / 60;
            int differenceInMin = difference % 60;

            if (difference >= 0)
            {
                Console.WriteLine("Tom sleeps well");
                Console.WriteLine($"{differenceInHrs} hours and {differenceInMin} minutes less for play");
            }
            else
            {
                Console.WriteLine("Tom will run away");
                Console.WriteLine($"{Math.Abs(differenceInHrs)} hours and {Math.Abs(differenceInMin)} minutes more for play");
            }
        }
    }
}
