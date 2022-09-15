using System;

namespace FoodDelivery
{
    class Program
    {
        static void Main(string[] args)
        {
            int chickenMenus = int.Parse(Console.ReadLine());
            int fishMenus = int.Parse(Console.ReadLine());
            int vegMenus = int.Parse(Console.ReadLine());

            double priceChickenMenus = chickenMenus * 10.35;
            double priceFishMenus = fishMenus * 12.40;
            double priceVegMenus = vegMenus * 8.15;

            double totalMenuPrice = priceChickenMenus + priceFishMenus + priceVegMenus;
            double dessertPrice = totalMenuPrice * 0.2;
            double delivery = 2.5;

            double totalSumToPay = totalMenuPrice + dessertPrice + delivery;

            Console.WriteLine(totalSumToPay);
        }
    }
}
