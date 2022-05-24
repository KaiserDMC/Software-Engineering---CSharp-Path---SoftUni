using System;

namespace FuelTankPartII
{
    class Program
    {
        static void Main(string[] args)
        {
            string fuelType = Console.ReadLine();
            double fuelAmount = double.Parse(Console.ReadLine());
            string clubCard = Console.ReadLine();

            double gasoline = 2.22;
            double diesel = 2.33;
            double gas = 0.93;

            double fuelCost = 0;

            if (clubCard == "Yes" || clubCard == "No")
            {
                if (clubCard == "Yes" && fuelType == "Gas")
                {
                    fuelCost = (gas * fuelAmount) - (fuelAmount * 0.08);
                }
                else if (clubCard == "Yes" && fuelType == "Diesel")
                {
                    fuelCost = (diesel * fuelAmount) - (fuelAmount * 0.12);
                }
                else if (clubCard == "Yes" && fuelType == "Gasoline")
                {
                    fuelCost = (gasoline * fuelAmount) - (fuelAmount * 0.18);
                }
                else if (clubCard == "No" && fuelType == "Gas")
                {
                    fuelCost = (gas * fuelAmount);
                }
                else if (clubCard == "No" && fuelType == "Diesel")
                {
                    fuelCost = (diesel * fuelAmount);
                }
                else if (clubCard == "No" && fuelType == "Gasoline")
                {
                    fuelCost = (gasoline * fuelAmount);
                }

                if (fuelAmount >= 20 && fuelAmount <= 25)
                {
                    fuelCost = fuelCost - (fuelCost * 0.08);
                }
                else if (fuelAmount > 25)
                {
                    fuelCost = fuelCost - (fuelCost * 0.1);
                }

                Console.WriteLine($"{fuelCost:f2} lv.");
            }
        }
    }
}
