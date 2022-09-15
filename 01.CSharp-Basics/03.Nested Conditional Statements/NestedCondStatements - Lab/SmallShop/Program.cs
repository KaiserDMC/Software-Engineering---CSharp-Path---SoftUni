using System;

namespace SmallShop
{
    class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            string city = Console.ReadLine();
            double quantity = double.Parse(Console.ReadLine());

            double price = 0;

            switch (city)
            {
                case "Sofia":
                    if (product == "coffee")
                    {
                        price = 0.5;
                    }
                    else if (product == "water")
                    {
                        price = 0.8;
                    }
                    else if (product == "beer")
                    {
                        price = 1.2;
                    }
                    else if (product == "sweets")
                    {
                        price = 1.45;
                    }
                    else if (product == "peanuts")
                    {
                        price = 1.60;
                    }
                    break;
                case "Plovdiv":
                    if (product == "coffee")
                    {
                        price = 0.4;
                    }
                    else if (product == "water")
                    {
                        price = 0.7;
                    }
                    else if (product == "beer")
                    {
                        price = 1.15;
                    }
                    else if (product == "sweets")
                    {
                        price = 1.30;
                    }
                    else if (product == "peanuts")
                    {
                        price = 1.50;
                    }
                    break;
                case "Varna":
                    if (product == "coffee")
                    {
                        price = 0.45;
                    }
                    else if (product == "water")
                    {
                        price = 0.7;
                    }
                    else if (product == "beer")
                    {
                        price = 1.1;
                    }
                    else if (product == "sweets")
                    {
                        price = 1.35;
                    }
                    else if (product == "peanuts")
                    {
                        price = 1.55;
                    }
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    break;
            }

            Console.WriteLine($"{quantity * price}");

        }
    }
}
