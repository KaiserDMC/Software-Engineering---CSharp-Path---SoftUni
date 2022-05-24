using System;

namespace VegM
{
    class Program
    {
        static void Main(string[] args)
        {
            double priceVeg = double.Parse(Console.ReadLine());
            double priceFruit = double.Parse(Console.ReadLine());
            int weightVeg = int.Parse(Console.ReadLine());
            int weightFruit = int.Parse(Console.ReadLine());

            double totalPriceVeg = priceVeg * weightVeg;
            double totalPriceVegEU = totalPriceVeg / 1.94;
            double totalPriceFruit = priceFruit * weightFruit;
            double totalPriceFruitEU = totalPriceFruit / 1.94;

            double totalIncomeEU = totalPriceVegEU + totalPriceFruitEU;

            Console.WriteLine($"{totalIncomeEU:f2}");
        }
    }
}
