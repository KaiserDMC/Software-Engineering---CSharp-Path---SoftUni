using System;

namespace Flowers
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberHrizantemi = int.Parse(Console.ReadLine());
            int numberRoses = int.Parse(Console.ReadLine());
            int numberTulips = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            char weekend = char.Parse(Console.ReadLine());

            double costHrizantemi = 0;
            double costRoses = 0;
            double costTulips = 0;
            int totalFlowers = numberHrizantemi + numberRoses + numberTulips;

            switch (season)
            {
                case "Spring":
                case "Summer":
                    costHrizantemi = 2;
                    costRoses = 4.1;
                    costTulips = 2.5;
                    break;
                case "Autumn":
                case "Winter":
                    costHrizantemi = 3.75;
                    costRoses = 4.5;
                    costTulips = 4.15;
                    break;
            }

            double totalCost = 0;

            if (weekend == 'N')
            {
                totalCost = costHrizantemi * numberHrizantemi + costRoses * numberRoses + costTulips * numberTulips;
            }
            else
            {
                totalCost = (costHrizantemi * numberHrizantemi + costRoses * numberRoses + costTulips * numberTulips) * 1.15;
            }

            if (numberTulips > 7 && season == "Spring")
            {
                totalCost = totalCost * 0.95;
            }
            else if (numberRoses >= 10 && season == "Winter")
            {
                totalCost = totalCost * 0.9;
            }

            if (totalFlowers > 20)
            {
                totalCost = totalCost * 0.8;
            }

            totalCost = totalCost + 2;

            Console.WriteLine($"{totalCost:f2}");
        }
    }
}
