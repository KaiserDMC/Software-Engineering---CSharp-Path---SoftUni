using System;

namespace CoffeeMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            string drink = Console.ReadLine();
            string sugar = Console.ReadLine();
            int amount = int.Parse(Console.ReadLine());

            double price = 0;

            switch (drink)
            {
                case "Espresso":
                    switch (sugar)
                    {
                        case "Without":
                            price = 0.9;
                            break;
                        case "Normal":
                            price = 1.0;
                            break;
                        case "Extra":
                            price = 1.2;
                            break;
                    }
                    break;
                case "Cappuccino":
                    switch (sugar)
                    {
                        case "Without":
                            price = 1.0;
                            break;
                        case "Normal":
                            price = 1.2;
                            break;
                        case "Extra":
                            price = 1.6;
                            break;
                    }
                    break;
                case "Tea":
                    switch (sugar)
                    {
                        case "Without":
                            price = 0.5;
                            break;
                        case "Normal":
                            price = 0.6;
                            break;
                        case "Extra":
                            price = 0.7;
                            break;
                    }
                    break;
            }

            price *= amount;

            if (sugar == "Without")
            {
                price *= 0.65;
            }

            if (drink == "Espresso" && amount >= 5)
            {
                price *= 0.75;
            }

            if (price > 15.00)
            {
                price *= 0.80;
            }

            Console.WriteLine($"You bought {amount} cups of {drink} for {price:f2} lv.");
        }
    }
}