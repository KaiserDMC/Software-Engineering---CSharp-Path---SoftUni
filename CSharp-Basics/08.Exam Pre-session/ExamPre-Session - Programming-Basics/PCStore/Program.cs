using System;

namespace PCStore
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input
            double priceCPU = double.Parse(Console.ReadLine()); //USD
            double priceGPU = double.Parse(Console.ReadLine()); //USD
            double priceRAM = double.Parse(Console.ReadLine()); //USD
            int numberDIMM = int.Parse(Console.ReadLine());
            double discountPercentage = double.Parse(Console.ReadLine());

            double currencyRate = 1.57;

            //Prices in BGN
            priceCPU *= currencyRate;
            priceGPU *= currencyRate;
            priceRAM *= currencyRate;

            //Discount CPU and GPU
            priceCPU -= (priceCPU * discountPercentage);
            priceGPU -= (priceGPU * discountPercentage);

            double totalCostParts = priceCPU + priceGPU + (priceRAM * numberDIMM);

            //Output
            Console.WriteLine($"Money needed - {totalCostParts:F2} leva.");
        }
    }
}
