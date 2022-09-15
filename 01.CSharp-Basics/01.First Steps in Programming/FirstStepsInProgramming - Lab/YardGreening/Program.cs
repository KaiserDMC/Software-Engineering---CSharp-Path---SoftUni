using System;

namespace YardGreening
{
    class Program
    {
        static void Main(string[] args)
        {
            double area = double.Parse(Console.ReadLine());
            if (area > 10000)
            {
                Console.WriteLine("The total area cannot be more than 10 000 sq. m.!");
            }
            else
            {
                double priceBeforeDiscount = area * 7.61;
                double discount = priceBeforeDiscount * 0.18;
                double priceAfterDiscount = priceBeforeDiscount - (discount);
                Console.WriteLine($"The final price is: {priceAfterDiscount} lv.");
                Console.WriteLine($"The discount is: {discount} lv.");
            }
        }
    }
}