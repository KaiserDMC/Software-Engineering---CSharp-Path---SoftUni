using System;

namespace Shopping
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int gpuCount = int.Parse(Console.ReadLine());
            int cpuCount = int.Parse(Console.ReadLine());
            int ramCount = int.Parse(Console.ReadLine());

            double totalGpuPrice = 250 * gpuCount;
            double totalCpuPrice = totalGpuPrice * 0.35 * cpuCount;
            double totalRamPrice = totalGpuPrice * 0.10 * ramCount;
            double totalCost = totalGpuPrice + totalCpuPrice + totalRamPrice;

            if (gpuCount > cpuCount)
            {
                totalCost = totalCost * 0.85;
            }

            double budgetDifference = budget - totalCost;

            if(budgetDifference>=0)
            {
                Console.WriteLine($"You have {budgetDifference:f2} leva left!");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {Math.Abs(budgetDifference):f2} leva more!");
            }
        }
    }
}
