using System;

namespace DepositCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            double depositSum = double.Parse(Console.ReadLine());
            int depositMonths = int.Parse(Console.ReadLine());
            double percentage = double.Parse(Console.ReadLine());

            double amountedTax = depositSum * percentage / 100;
            double oneMonthTax = amountedTax / 12;

            double finalSum = depositSum + (depositMonths * oneMonthTax);

            Console.WriteLine(finalSum);
        }
    }
}
