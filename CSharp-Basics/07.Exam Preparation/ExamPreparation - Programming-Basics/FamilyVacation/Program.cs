using System;

namespace FamilyVacation
{
    class Program
    {
        static void Main(string[] args)
        {
            double familyBudget = double.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());
            double pricePerNight = double.Parse(Console.ReadLine());
            int percentageExtraCost = int.Parse(Console.ReadLine());

            if (days > 7)
            {
                pricePerNight -= pricePerNight * 0.05;
            }

            double costForVacation = days * pricePerNight;
            double extraExpenses = familyBudget * percentageExtraCost / 100;
            costForVacation += extraExpenses;

            if (familyBudget >= costForVacation)
            {
                Console.WriteLine($"Ivanovi will be left with {familyBudget - costForVacation:f2} leva after vacation.");
            }
            else
            {
                Console.WriteLine($"{Math.Abs(familyBudget - costForVacation):f2} leva needed.");
            }
        }
    }
}
