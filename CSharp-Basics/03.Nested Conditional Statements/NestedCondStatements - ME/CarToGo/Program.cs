using System;

namespace CarToGo
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            string type = string.Empty;
            double carPrice = 0;
            string car = string.Empty;

            if (budget <= 100)
            {
                type = "Economy class";
            }
            else if (budget > 100 && budget <= 500)
            {
                type = "Compact class";
            }
            else if (budget > 500)
            {
                type = "Luxury class";
            }

            switch (season)
            {
                case "Summer":
                    car = "Cabrio";
                    if (type == "Economy class")
                    {
                        carPrice = budget * 0.35;
                    }
                    else if (type == "Compact class")
                    {
                        carPrice = budget * 0.45;
                    }
                    else if (type == "Luxury class")
                    {
                        carPrice = budget * 0.9;
                    }
                    break;
                case "Winter":
                    car = "Jeep";
                    if (type == "Economy class")
                    {
                        carPrice = budget * 0.65;
                    }
                    else if (type == "Compact class")
                    {
                        carPrice = budget * 0.8;
                    }
                    else if (type == "Luxury class")
                    {
                        carPrice = budget * 0.9;
                    }
                    break;
            }

            if (budget > 500)
            {
                car = "Jeep";
            }

            Console.WriteLine($"{type}");
            Console.WriteLine($"{car} - {carPrice:f2}");
        }
    }
}
