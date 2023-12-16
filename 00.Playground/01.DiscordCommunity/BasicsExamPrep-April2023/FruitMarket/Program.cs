using System;

namespace FruitMarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double priceStrawberries = double.Parse(Console.ReadLine());
            double quantityBananas = double.Parse(Console.ReadLine());
            double quantityOranges = double.Parse(Console.ReadLine());
            double quantityRaspberries = double.Parse(Console.ReadLine());
            double quantityStrawberries = double.Parse(Console.ReadLine());

            double priceRaspberries = priceStrawberries * 0.5;
            double priceOranges = priceRaspberries * 0.6;
            // double priceOrange = priceRaspberries - (priceRaspberries * 0.4);
            double priceBananas = priceRaspberries * 0.2;

            double totalStrawberries = priceStrawberries * quantityStrawberries;
            double totalBananas = priceBananas * quantityBananas;
            double totalOranges = priceOranges * quantityOranges;
            double totalRaspberries = priceRaspberries * quantityRaspberries;

            double totalSumToPay = totalStrawberries + totalBananas + totalOranges + totalRaspberries;

            Console.WriteLine($"{totalSumToPay:f2}");
        }
    }
}