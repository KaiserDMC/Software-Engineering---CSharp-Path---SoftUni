using System;

namespace ExcursionSale
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input
            int numberExcursionSea = int.Parse(Console.ReadLine());
            int numberExcursionMountain = int.Parse(Console.ReadLine());
            string userInput = Console.ReadLine();

            double profit = 0;
            double priceExcursionSea = 680;
            double priceExcursionMountain = 499;
            int counterSea = 0;
            int counterMountain = 0;
            bool soldOutSea = false;
            bool soldOutMountain = false;

            //Calculations
            while (userInput != "Stop")
            {
                string excursionType = userInput;

                if (excursionType == "sea")
                {
                    counterSea++;

                    if (counterSea > numberExcursionSea)
                    {
                        soldOutSea = true;
                    }
                    else if (counterSea == numberExcursionSea)
                    {
                        profit += priceExcursionSea;
                        soldOutSea = true;
                    }
                    else
                    {
                        profit += priceExcursionSea;
                    }
                }
                else if (excursionType == "mountain")
                {
                    counterMountain++;

                    if (counterMountain > numberExcursionMountain)
                    {
                        soldOutMountain = true;
                    }
                    else if (counterMountain == numberExcursionMountain)
                    {
                        soldOutMountain = true;
                        profit += priceExcursionMountain;
                    }
                    else
                    {
                        profit += priceExcursionMountain;
                    }
                }

                if (soldOutSea && soldOutMountain)
                {
                    break;
                }

                userInput = Console.ReadLine();
            }

            //Output
            if (soldOutSea && soldOutMountain)
            {
                Console.WriteLine($"Good job! Everything is sold.");
            }

            Console.WriteLine($"Profit: {profit} leva.");
        }
    }
}
