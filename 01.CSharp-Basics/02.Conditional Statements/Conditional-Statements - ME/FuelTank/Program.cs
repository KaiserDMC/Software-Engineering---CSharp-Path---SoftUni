using System;

namespace FuelTank
{
    class Program
    {
        static void Main(string[] args)
        {
            string fuelType = Console.ReadLine();
            double fuelAmount = double.Parse(Console.ReadLine());

            if (fuelType == "Diesel" || fuelType == "Gasoline" || fuelType == "Gas")
            {
                if (fuelAmount >= 25)
                {
                    Console.WriteLine($"You have enough {fuelType.ToLower()}.");
                }
                else
                {
                    Console.WriteLine($"Fill your tank with {fuelType.ToLower()}!");
                }
            }
            else
            {
                Console.WriteLine("Invalid fuel!");
            }
        }
    }
}
