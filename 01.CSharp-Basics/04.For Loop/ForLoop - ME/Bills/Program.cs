using System;

namespace Bills
{
    class Program
    {
        static void Main(string[] args)
        {
            int months = int.Parse(Console.ReadLine());

            double waterBill = 20 * months;
            double internetBill = 15 * months;
            double miscBill = 0;
            double totalElectricityBill = 0;

            for (int i = 0; i < months; i++)
            {
                double electricityBill = double.Parse(Console.ReadLine());

                totalElectricityBill += electricityBill;
                miscBill += (35 + electricityBill) * 1.2;
            }

            double totalBill = waterBill + internetBill + totalElectricityBill + miscBill;
            double avgBill = totalBill / months;

            Console.WriteLine($"Electricity: {totalElectricityBill:f2} lv");
            Console.WriteLine($"Water: {waterBill:f2} lv");
            Console.WriteLine($"Internet: {internetBill:f2} lv");
            Console.WriteLine($"Other: {miscBill:f2} lv");
            Console.WriteLine($"Average: {avgBill:f2} lv");
        }
    }
}
