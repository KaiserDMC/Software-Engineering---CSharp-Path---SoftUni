using System;

namespace GodzillaVsKong
{
    class Program
    {
        static void Main(string[] args)
        {
            double movieBudget = double.Parse(Console.ReadLine());
            int actors = int.Parse(Console.ReadLine());
            double clothesPricePerActor = double.Parse(Console.ReadLine());

            double decors = movieBudget * 0.1;

            if (actors > 150)
            {
                clothesPricePerActor = clothesPricePerActor - clothesPricePerActor * 0.1;
            }

            double totalClothesPrice = clothesPricePerActor * actors;
            double budgetDifference = movieBudget - (totalClothesPrice + decors);

            if (budgetDifference >= 0)
            {
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {budgetDifference:f2} leva left.");
            }
            else
            {
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {Math.Abs(budgetDifference):f2} leva more.");
            }
        }
    }
}
