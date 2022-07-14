using System;

namespace SuitcaseLoad
{
    class Program
    {
        static void Main(string[] args)
        {
            double loadCapacity = double.Parse(Console.ReadLine());

            string inputString = Console.ReadLine();
            int counterSuitcase = 0;

            while (inputString != "End")
            {
                double currentSuitcase = double.Parse(inputString);
                counterSuitcase++;

                if (counterSuitcase % 3 == 0)
                {
                    currentSuitcase *= 1.1;
                }

                if (currentSuitcase > loadCapacity)
                {
                    Console.WriteLine($"No more space!");
                    counterSuitcase--;
                    break;
                }

                loadCapacity = loadCapacity - currentSuitcase;

                inputString = Console.ReadLine();
            }

            if (inputString == "End")
            {
                Console.WriteLine($"Congratulations! All suitcases are loaded!");
            }

            Console.WriteLine($"Statistic: {counterSuitcase} suitcases loaded.");
        }
    }
}
