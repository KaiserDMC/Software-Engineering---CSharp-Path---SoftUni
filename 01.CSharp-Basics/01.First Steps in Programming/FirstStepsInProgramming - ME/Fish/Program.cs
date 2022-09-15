using System;

namespace Fish
{
    class Program
    {
        static void Main(string[] args)
        {
            double priceMackerel = double.Parse(Console.ReadLine());
            double priceSprat = double.Parse(Console.ReadLine());
            double weightSarda = double.Parse(Console.ReadLine());
            double weightSaurels = double.Parse(Console.ReadLine());
            int weightMussels = int.Parse(Console.ReadLine());

            double priceSarda = priceMackerel + priceMackerel * 0.6;
            double priceSaurels = priceSprat + priceSprat * 0.8;

            double sumSarda = weightSarda * priceSarda;
            double sumSaurels = weightSaurels * priceSaurels;
            double sumMussels = weightMussels * 7.5;

            double totalSum = sumSarda + sumSaurels + sumMussels;
            //totalSum = Math.Round(totalSum, 2, MidpointRounding.ToEven);

            Console.WriteLine($"{totalSum:f2}");
        }
    }
}
