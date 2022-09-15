using System;

namespace Logistics
{
    class Program
    {
        static void Main(string[] args)
        {
            int loads = int.Parse(Console.ReadLine());

            int pricePerTonMinivan = 200;
            int pricePerTonTruck = 175;
            int pricePerTonTrain = 120;
            int minivanWeight = 0;
            int truckWeight = 0;
            int trainWeight = 0;
            int totalWeight = 0;

            for (int i = 0; i < loads; i++)
            {
                int weight = int.Parse(Console.ReadLine());

                totalWeight += weight;

                if (weight <= 3)
                {
                    minivanWeight += weight;
                }
                else if (weight >= 4 && weight <= 11)
                {
                    truckWeight += weight;
                }
                else if (weight >= 12)
                {
                    trainWeight += weight;
                }
            }

            double averagePrice = (double)(minivanWeight * pricePerTonMinivan + truckWeight * pricePerTonTruck + trainWeight * pricePerTonTrain) / totalWeight;
            double percentageMinivan = (double)minivanWeight / totalWeight * 100;
            double percentageTruck = (double)truckWeight / totalWeight * 100;
            double percentageTrain = (double)trainWeight / totalWeight * 100;

            Console.WriteLine($"{averagePrice:f2}");
            Console.WriteLine($"{percentageMinivan:f2}%");
            Console.WriteLine($"{percentageTruck:f2}%");
            Console.WriteLine($"{percentageTrain:f2}%");
        }
    }
}
