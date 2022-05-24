using System;

namespace Dishwasher
{
    class Program
    {
        static void Main(string[] args)
        {
            int bottlesDetergent = int.Parse(Console.ReadLine());
            string numberOfDishes = Console.ReadLine();
            int detergentPlates = 5;
            int detergentPots = 15;
            int totalAmountDetergent = 750 * bottlesDetergent;
            int i = 0;
            int amountOfPlates = 0;
            int amountOfPots = 0;

            do
            {
                int dishes = int.Parse(numberOfDishes);
                i++;

                if (i % 3 == 0)
                {
                    totalAmountDetergent -= dishes * detergentPots;
                    amountOfPots += dishes;
                }
                else
                {
                    totalAmountDetergent -= dishes * detergentPlates;
                    amountOfPlates += dishes;
                }

                if (totalAmountDetergent < 0)
                {
                    break;
                }

                numberOfDishes = Console.ReadLine();

            } while (numberOfDishes != "End");

            if (totalAmountDetergent >= 0)
            {
                Console.WriteLine($"Detergent was enough!");
                Console.WriteLine($"{amountOfPlates} dishes and {amountOfPots} pots were washed.");
                Console.WriteLine($"Leftover detergent {totalAmountDetergent} ml.");
            }
            else
            {
                Console.WriteLine($"Not enough detergent, {Math.Abs(totalAmountDetergent)} ml. more necessary!");
            }
        }
    }
}
