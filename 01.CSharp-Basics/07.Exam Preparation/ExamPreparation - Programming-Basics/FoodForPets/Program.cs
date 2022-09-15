using System;

namespace FoodForPets
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            double totalAmountFood = double.Parse(Console.ReadLine());

            int dayCounter = 0;
            double totalAmountBiscuits = 0;
            double totalAmountDog = 0;
            double totalAmountCat = 0;
            double totalAmountBothPets = 0;


            for (int i = 1; i <= days; i++)
            {
                double foodEatenDog = double.Parse(Console.ReadLine());
                double foodEatenCat = double.Parse(Console.ReadLine());

                dayCounter++;

                double totalEatenPerDay = foodEatenDog + foodEatenCat;
                double biscuitAmount = totalEatenPerDay * 0.1;

                if (dayCounter == 3)
                {
                    totalAmountBiscuits += biscuitAmount;
                    dayCounter = 0;
                }

                totalAmountDog += foodEatenDog;
                totalAmountCat += foodEatenCat;
                totalAmountBothPets += totalEatenPerDay;
            }

            Console.WriteLine($"Total eaten biscuits: {Math.Ceiling(totalAmountBiscuits)}gr.");
            Console.WriteLine($"{(totalAmountBothPets / totalAmountFood * 100):f2}% of the food has been eaten.");
            Console.WriteLine($"{(totalAmountDog / totalAmountBothPets * 100):f2}% eaten from the dog.");
            Console.WriteLine($"{(totalAmountCat / totalAmountBothPets * 100):f2}% eaten from the cat.");
        }
    }
}
