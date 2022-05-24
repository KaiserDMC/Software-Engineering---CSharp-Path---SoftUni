using System;

namespace FruitShop
{
    class Program
    {
        static void Main(string[] args)
        {
            string fruit = Console.ReadLine();
            string day = Console.ReadLine();
            double quantity = double.Parse(Console.ReadLine());

            double fruitPrice = 0;

            switch (day)
            {
                case "Monday":
                case "Tuesday":
                case "Wednesday":
                case "Thursday":
                case "Friday":
                    if (fruit == "banana")
                    {
                        fruitPrice = 2.5;
                    }
                    else if (fruit == "apple")
                    {
                        fruitPrice = 1.20;
                    }
                    else if (fruit == "orange")
                    {
                        fruitPrice = 0.85;
                    }
                    else if (fruit == "grapefruit")
                    {
                        fruitPrice = 1.45;
                    }
                    else if (fruit == "kiwi")
                    {
                        fruitPrice = 2.70;
                    }
                    else if (fruit == "pineapple")
                    {
                        fruitPrice = 5.50;
                    }
                    else if (fruit == "grapes")
                    {
                        fruitPrice = 3.85;
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                    break;
                case "Saturday":
                case "Sunday":
                    if (fruit == "banana")
                    {
                        fruitPrice = 2.7;
                    }
                    else if (fruit == "apple")
                    {
                        fruitPrice = 1.25;
                    }
                    else if (fruit == "orange")
                    {
                        fruitPrice = 0.90;
                    }
                    else if (fruit == "grapefruit")
                    {
                        fruitPrice = 1.60;
                    }
                    else if (fruit == "kiwi")
                    {
                        fruitPrice = 3;
                    }
                    else if (fruit == "pineapple")
                    {
                        fruitPrice = 5.60;
                    }
                    else if (fruit == "grapes")
                    {
                        fruitPrice = 4.20;
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                    break;

                default:
                    Console.WriteLine("error");
                    break;
            }


            double totalPrice = fruitPrice * quantity;
            if (totalPrice != 0)
            {
                Console.WriteLine($"{totalPrice:f2}");
            }
        }
    }
}
