using System;

namespace TouristShop_Alternative
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int counter = 0;
            double total = 0;

            double budget = double.Parse(Console.ReadLine());
            string product = Console.ReadLine();
            double price = double.Parse(Console.ReadLine());

            while (product != "Stop")
            {
                counter++;
                if (counter % 3 == 0) price *= 0.50;
                total += price;
                if (budget >= price)
                    budget -= price;
                else
                {
                    Console.WriteLine($"You don't have enough money!");
                    Console.WriteLine($"You need {(price - budget):f2} leva!");
                    counter--;
                    break;
                }

                product = Console.ReadLine();
                if (product != "Stop")
                    price = double.Parse(Console.ReadLine());
                else
                    Console.WriteLine($"You bought {counter} products for {total:f2} leva.");
            }
        }
    }
}