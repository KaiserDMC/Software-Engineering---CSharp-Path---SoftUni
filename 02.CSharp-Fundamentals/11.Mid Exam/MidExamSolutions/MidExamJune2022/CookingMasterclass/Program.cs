using System;

namespace CookingMasterclass
{
    class Program
    {
        static void Main(string[] args)
        {
            //Github Upload
            double budget = double.Parse(Console.ReadLine());
            int numberOfStudents = int.Parse(Console.ReadLine());
            double priceFlour = double.Parse(Console.ReadLine());
            double priceSingleEgg = double.Parse(Console.ReadLine());
            double priceApron = double.Parse(Console.ReadLine());

            double amountOfAprons = numberOfStudents;
            amountOfAprons *= 1.2;
            amountOfAprons = Math.Ceiling(amountOfAprons);

            double totalCost = 0;
            int counterFreeFlour = 0;
            for (int i = 0; i < numberOfStudents; i++)
            {
                double costsPerStudent = priceFlour + (10 * priceSingleEgg);
                counterFreeFlour++;

                if (counterFreeFlour % 5 == 0 && counterFreeFlour != 0)
                {
                    costsPerStudent -= priceFlour;
                }

                totalCost += costsPerStudent;
            }

            totalCost += amountOfAprons * priceApron;

            double differenceInBudget = budget - totalCost;

            if (differenceInBudget >= 0)
            {
                Console.WriteLine($"Items purchased for {totalCost:f2}$.");
            }
            else
            {
                Console.WriteLine($"{Math.Abs(differenceInBudget):f2}$ more needed.");
            }
        }
    }
}
