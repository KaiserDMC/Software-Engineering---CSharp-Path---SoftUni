using System;

namespace SumSeconds
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstRunnerTime = int.Parse(Console.ReadLine());
            int secondRunnerTime = int.Parse(Console.ReadLine());
            int thirdRunnerTime = int.Parse(Console.ReadLine());

            int totalRunnerTime = firstRunnerTime + secondRunnerTime + thirdRunnerTime;
            int totalTimeMinutes = totalRunnerTime / 60;
            int totalTimeSeconds = totalRunnerTime % 60;

            if (totalTimeSeconds < 10)
            {
                Console.WriteLine($"{totalTimeMinutes}:0{totalTimeSeconds}");
            }
            else
            {
                Console.WriteLine($"{totalTimeMinutes}:{totalTimeSeconds}");
            }

        }
    }
}
