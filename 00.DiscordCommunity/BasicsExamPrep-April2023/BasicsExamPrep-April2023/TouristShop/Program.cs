using System;

namespace TouristShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            double totalPrice = 0;
            int counter = 0;

            while (true)
            {
                string productName = Console.ReadLine();

                if (productName == "Stop")
                {
                    Console.WriteLine($"You bought {counter} products for {totalPrice:f2} leva.");
                    break;
                }

                double productPrice = double.Parse(Console.ReadLine());
                counter++;

                if (counter % 3 == 0)
                {
                    productPrice *= 0.5;
                }

                totalPrice += productPrice;

                if (budget >= productPrice)
                {
                    budget -= productPrice;
                }
                else
                {
                    Console.WriteLine($"You don't have enough money!");
                    Console.WriteLine($"You need {(Math.Abs(budget - productPrice)):f2} leva!");
                    break;
                }
            }
        }
    }
}