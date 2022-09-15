using System;

namespace EnergyBooster
{
    class Program
    {
        static void Main(string[] args)
        {
            string fruit = Console.ReadLine();
            string setSize = Console.ReadLine();
            int setNumber = int.Parse(Console.ReadLine());

            double singleFruitPrice = 0;
            int numberInPack = 0;

            if (setSize == "small")
            {
                numberInPack = 2;
            }
            else
            {
                numberInPack = 5;
            }

            switch (fruit)
            {
                case "Watermelon":
                    if (setSize == "small")
                    {
                        singleFruitPrice = 56;
                    }
                    else
                    {
                        singleFruitPrice = 28.70;
                    }
                    break;
                case "Mango":
                    if (setSize == "small")
                    {
                        singleFruitPrice = 36.66;
                    }
                    else
                    {
                        singleFruitPrice = 19.60;
                    }
                    break;
                case "Pineapple":
                    if (setSize == "small")
                    {
                        singleFruitPrice = 42.10;
                    }
                    else
                    {
                        singleFruitPrice = 24.80;
                    }
                    break;
                case "Raspberry":
                    if (setSize == "small")
                    {
                        singleFruitPrice = 20;
                    }
                    else
                    {
                        singleFruitPrice = 15.20;
                    }
                    break;
            }

            double totalPriceBeforeDiscount = singleFruitPrice * setNumber * numberInPack;

            if (totalPriceBeforeDiscount >= 400 && totalPriceBeforeDiscount <= 1000)
            {
                totalPriceBeforeDiscount = totalPriceBeforeDiscount - (totalPriceBeforeDiscount * 0.15);
            }
            else if (totalPriceBeforeDiscount > 1000)
            {
                totalPriceBeforeDiscount = totalPriceBeforeDiscount - (totalPriceBeforeDiscount * 0.50);
            }

            Console.WriteLine($"{totalPriceBeforeDiscount:f2} lv.");
        }
    }
}
