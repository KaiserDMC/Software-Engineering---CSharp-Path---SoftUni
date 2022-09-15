using System;

namespace SkiTrip
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            string typeOfRoom = Console.ReadLine();
            string review = Console.ReadLine();

            double oneNightPrice = 0;
            double totalCost = 0;

            switch (typeOfRoom)
            {
                case "room for one person":
                    oneNightPrice = 18;
                    break;
                case "apartment":
                    oneNightPrice = 25;
                    if (days < 10)
                    {
                        oneNightPrice -= oneNightPrice * 0.3;
                    }
                    else if (days >= 10 && days <= 15)
                    {
                        oneNightPrice -= oneNightPrice * 0.35;
                    }
                    else if (days > 15)
                    {
                        oneNightPrice -= oneNightPrice * 0.5;
                    }
                    break;
                case "president apartment":
                    oneNightPrice = 35;
                    if (days < 10)
                    {
                        oneNightPrice -= oneNightPrice * 0.1;
                    }
                    else if (days >= 10 && days <= 15)
                    {
                        oneNightPrice -= oneNightPrice * 0.15;
                    }
                    else if (days > 15)
                    {
                        oneNightPrice -= oneNightPrice * 0.2;
                    }
                    break;
            }

            totalCost = oneNightPrice * (days - 1);
            if (review == "positive")
            {
                totalCost += totalCost * 0.25;
            }
            else if (review == "negative")
            {
                totalCost -= totalCost * 0.1;
            }

            Console.WriteLine($"{totalCost:f2}");
        }
    }
}
