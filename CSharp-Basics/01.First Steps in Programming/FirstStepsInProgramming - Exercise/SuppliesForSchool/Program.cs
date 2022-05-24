using System;

namespace SuppliesForSchool
{
    class Program
    {
        static void Main(string[] args)
        {
            int pens = int.Parse(Console.ReadLine());
            int markers = int.Parse(Console.ReadLine());
            int litres = int.Parse(Console.ReadLine());
            int discount = int.Parse(Console.ReadLine());

            double penCost = 5.80;
            double markerCost = 7.20;
            double litreCost = 1.20;

            double totalCost = pens * penCost + markers * markerCost + litres * litreCost;
            double totalAfterDiscount = totalCost - (totalCost * discount / 100);
            Console.WriteLine(totalAfterDiscount);
        }
    }
}
