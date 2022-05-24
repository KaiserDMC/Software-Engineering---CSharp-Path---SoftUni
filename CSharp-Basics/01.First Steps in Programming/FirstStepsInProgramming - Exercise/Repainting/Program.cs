using System;

namespace Repainting
{
    class Program
    {
        static void Main(string[] args)
        {
            int nailon = int.Parse(Console.ReadLine());
            int paint = int.Parse(Console.ReadLine());
            int bleacher = int.Parse(Console.ReadLine());
            int hours = int.Parse(Console.ReadLine());

            if (nailon == 0 || paint == 0 || bleacher == 0 || hours == 0)
            {

            }
            else
            {
                double priceNailon = 1.5;
                double pricePaint = 14.5;
                double priceBleacher = 5.0;
                double priceBags = 0.4;

                double totalPriceNailon = (nailon + 2) * priceNailon;
                double totalPricePaint = (paint * 1.1) * pricePaint;
                double totalPriceBleacher = bleacher * priceBleacher;

                double totalSum = totalPriceNailon + totalPricePaint + totalPriceBleacher + priceBags;

                double workPrice = (totalSum * 0.3) * hours;
                double finalPrice = totalSum + workPrice;

                Console.WriteLine(finalPrice);
            }
        }
    }
}
