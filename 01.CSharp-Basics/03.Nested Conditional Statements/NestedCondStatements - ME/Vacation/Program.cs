using System;

namespace Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            string accommodation = string.Empty;
            string destination = string.Empty;
            double cost = 0;

            if (budget <= 1000)
            {
                accommodation = "Camp";
            }
            else if (budget > 1000 && budget <= 3000)
            {
                accommodation = "Hut";
            }
            else if (budget > 3000)
            {
                accommodation = "Hotel";
            }

            switch (season)
            {
                case "Summer":
                    destination = "Alaska";
                    if (accommodation == "Camp")
                    {
                        cost = budget * 0.65;
                    }
                    else if (accommodation == "Hut")
                    {
                        cost = budget * 0.8;
                    }
                    else
                    {
                        cost = budget * 0.9;
                    }
                    break;
                case "Winter":
                    destination = "Morocco";
                    if (accommodation == "Camp")
                    {
                        cost = budget * 0.45;
                    }
                    else if (accommodation == "Hut")
                    {
                        cost = budget * 0.6;
                    }
                    else
                    {
                        cost = budget * 0.9;
                    }
                    break;
            }

            Console.WriteLine($"{destination} - {accommodation} - {cost:f2}");
        }
    }
}
