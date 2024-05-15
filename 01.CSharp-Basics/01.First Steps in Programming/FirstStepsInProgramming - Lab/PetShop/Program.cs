using System;

namespace PetShop
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfDogFoodPackages = int.Parse(Console.ReadLine());
            int numberOfCatFoodPackages = int.Parse(Console.ReadLine());

            double dogFoodExpenses = numberOfDogFoodPackages * 2.50;
            int catFoodExpenses = numberOfCatFoodPackages * 4;
            double sum = dogFoodExpenses + catFoodExpenses;
            Console.WriteLine($"{sum} lv.");
        }
    }
}
