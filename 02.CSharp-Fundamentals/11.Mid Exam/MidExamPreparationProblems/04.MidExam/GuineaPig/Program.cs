using System;
using System.Diagnostics.Tracing;

namespace GuineaPig
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal quantityOfFood = decimal.Parse(Console.ReadLine());
            decimal quantityOfHay = decimal.Parse(Console.ReadLine());
            decimal quantityOfCover = decimal.Parse(Console.ReadLine());
            decimal guineapigWeight = decimal.Parse(Console.ReadLine());

            int counterDays = 0;
            bool isEnough = false;

            while (true)
            {
                counterDays++;

                if (quantityOfFood <= 0)
                {
                    break;
                }

                if (counterDays > 30)
                {
                    isEnough = true;
                    break;
                }

                quantityOfFood -= 0.3m;

                if (counterDays % 2 == 0)
                {
                    quantityOfHay -= 0.05m * quantityOfFood;

                    if (quantityOfHay <= 0)
                    {
                        break;
                    }
                }

                if (counterDays % 3 == 0)
                {
                    quantityOfCover -= guineapigWeight * 1m / 3m;

                    if (quantityOfCover <= 0)
                    {
                        break;
                    }
                }
            }

            if (isEnough)
            {
                Console.WriteLine($"Everything is fine! Puppy is happy! Food: {quantityOfFood:f2}, Hay: {quantityOfHay:f2}, Cover: {quantityOfCover:f2}.");
            }
            else
            {
                Console.WriteLine($"Merry must go to the pet store!");
            }
        }
    }
}