using System;

namespace Aluminum_Joinery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int quantity = int.Parse(Console.ReadLine());
            string type = Console.ReadLine();
            string delivery = Console.ReadLine();

            if (quantity < 10)
            {
                Console.WriteLine($"Invalid order");
                return;
            }

            double singlePrice = 0;
            double totalPrice = 0;

            switch (type)
            {
                case "90X130":
                    singlePrice = 110;

                    if (quantity > 30 && quantity <= 60)
                    {
                        singlePrice *= 0.95;
                    }
                    else if (quantity > 60)
                    {
                        singlePrice *= 0.92;
                    }
                    break;
                case "100X150":
                    singlePrice = 140;

                    if (quantity > 40 && quantity <= 80)
                    {
                        singlePrice *= 0.94;
                    }
                    else if (quantity > 80)
                    {
                        singlePrice *= 0.9;
                    }

                    break;
                case "130X180":
                    singlePrice = 190;

                    if (quantity > 20 && quantity <= 50)
                    {
                        singlePrice *= 0.93;
                    }
                    else if (quantity > 50)
                    {
                        singlePrice *= 0.88;
                    }

                    break;
                case "200X300":
                    singlePrice = 250;

                    if (quantity > 25 && quantity <= 50)
                    {
                        singlePrice *= 0.91;
                    }
                    else if (quantity > 50)
                    {
                        singlePrice *= 0.86;
                    }

                    break;
            }

            totalPrice = singlePrice * quantity;

            switch (delivery)
            {
                case "With delivery":
                    totalPrice += 60;
                    break;
                default:
                    break;
            }

            if (quantity > 99)
            {
                totalPrice *= 0.96;
            }

            Console.WriteLine($"{totalPrice:f2} BGN");
        }
    }
}