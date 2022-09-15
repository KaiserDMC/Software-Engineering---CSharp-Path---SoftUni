using System;

namespace FishingBoat
{
    class Program
    {
        static void Main(string[] args)
        {
            int totalBudget = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            int numberFishers = int.Parse(Console.ReadLine());

            double boatCost = 0;

            switch (season)
            {
                case "Spring":
                    boatCost = 3000;
                    break;
                case "Summer":
                case "Autumn":
                    boatCost = 4200;
                    break;
                case "Winter":
                    boatCost = 2600;
                    break;
            }

            if (numberFishers <= 6)
            {
                boatCost = boatCost - (boatCost * 0.1);
            }
            else if (numberFishers >= 7 && numberFishers <= 11)
            {
                boatCost = boatCost - (boatCost * 0.15);
            }
            else if (numberFishers >= 12)
            {
                boatCost = boatCost - (boatCost * 0.25);
            }

            bool extraDiscountCheck = numberFishers % 2 == 0;

            if (extraDiscountCheck && season != "Autumn")
            {
                boatCost = boatCost - (boatCost * 0.05);
            }

            double difference = totalBudget - boatCost;
            if (difference >= 0)
            {
                Console.WriteLine($"Yes! You have {difference:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {Math.Abs(difference):f2} leva.");
            }
        }
    }
}
