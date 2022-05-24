using System;

namespace Harvest
{
    class Program
    {
        static void Main(string[] args)
        {
            int harvestArea = int.Parse(Console.ReadLine());
            double winePerSqm = double.Parse(Console.ReadLine());
            int wineLitres = int.Parse(Console.ReadLine());
            int numberWorkers = int.Parse(Console.ReadLine());

            double totalWineArea = harvestArea * winePerSqm;
            double actualWine = (totalWineArea * 40 / 100) / 2.5;

            double difference = actualWine - wineLitres;

            if(difference>=0)
            {
                double winePerWorker = difference / numberWorkers;
                Console.WriteLine($"Good harvest this year! Total wine: {Math.Floor(actualWine)} liters.");
                Console.WriteLine($"{Math.Ceiling(difference)} liters left -> {Math.Ceiling(winePerWorker)} liters per person.");
            }
            else
            {
                Console.WriteLine($"It will be a tough winter! More {Math.Floor(Math.Abs(difference))} liters wine needed.");
            }
        }
    }
}
