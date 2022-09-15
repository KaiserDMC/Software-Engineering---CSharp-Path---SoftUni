using System;

namespace Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            int productQuantity = int.Parse(Console.ReadLine());

            double productPrice = 0;

            switch (product)
            {
                case "coffee":
                    productPrice = 1.5;
                    break;
                case "water":
                    productPrice = 1;
                    break;
                case "coke":
                    productPrice = 1.4;
                    break;
                case "snacks":
                    productPrice = 2;
                    break;
                default:
                    break;
            }

            FinalPrice(productQuantity, productPrice);
        }

        static void FinalPrice(int productQuantity, double productPrice)
        {
            double finalPrice = productQuantity * productPrice;
            Console.WriteLine($"{finalPrice:f2}");
        }
    }
}
