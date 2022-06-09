using System;

namespace OrdersV2
{
    class Program
    {
        static void Main(string[] args)
        {
            string productType = Console.ReadLine();
            int productQuantity = int.Parse(Console.ReadLine());

            FinalPrice(productType, productQuantity);
        }

        private static void FinalPrice(string productType, int productQuantity)
        {
            string order = productType;
            double productPrice = 0;

            switch (order)
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

            double finalPrice = productPrice * productQuantity;
            Console.WriteLine($"{finalPrice:f2}");
        }
    }
}

