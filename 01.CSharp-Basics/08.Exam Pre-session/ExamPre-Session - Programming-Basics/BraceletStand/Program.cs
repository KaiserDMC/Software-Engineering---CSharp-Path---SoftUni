using System;

namespace BraceletStand
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input
            double dailyAllowence = double.Parse(Console.ReadLine());
            double dailyProfit = double.Parse(Console.ReadLine());
            double costAllPeriod = double.Parse(Console.ReadLine());
            double costGift = double.Parse(Console.ReadLine());

            //Calculations
            int days = 5;
            double savedAllowence = dailyAllowence * days;
            double profitAllPeriod = dailyProfit * days;
            double totalSaved = savedAllowence + profitAllPeriod;

            totalSaved -= costAllPeriod;

            //Output
            if (totalSaved >= costGift)
            {
                Console.WriteLine($"Profit: {totalSaved:F2} BGN, the gift has been purchased.");
            }
            else
            {
                Console.WriteLine($"Insufficient money: {(costGift - totalSaved):F2} BGN.");
            }
        }
    }
}
