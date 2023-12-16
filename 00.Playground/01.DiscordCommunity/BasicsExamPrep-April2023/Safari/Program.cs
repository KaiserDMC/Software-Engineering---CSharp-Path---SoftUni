using System;

namespace Safari
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            double litresFuel = double.Parse(Console.ReadLine());
            string dayOfWeek = Console.ReadLine();

            double priceFuel = 2.1;
            double priceTourGuide = 100;

            double totalFuelPrice = priceFuel * litresFuel;

            double price = priceTourGuide + totalFuelPrice;

            //double discount = price * 0.1;
            if (dayOfWeek == "Saturday")
            {
                price *= 0.9;
                //price = price * 0.9;
                //price = price - discount;
                //price -= discount;
            }
            else { price *= 0.8; }

            if (budget >= price)
            {
                Console.WriteLine($"Safari time! Money left: {(budget - price):f2} lv.");
            }
            else
            {
                Console.WriteLine($"Not enough money! Money needed: {price - budget:f2} lv.");
                //Console.WriteLine($"Not enough money! Money needed: {Math.Abs(budget - price):f2} lv.");
            }
        }
    }
}