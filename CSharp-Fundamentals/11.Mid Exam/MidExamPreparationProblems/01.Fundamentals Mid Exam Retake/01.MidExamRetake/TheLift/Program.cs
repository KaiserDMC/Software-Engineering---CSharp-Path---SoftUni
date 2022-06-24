using System;
using System.Linq;

namespace TheLift
{
    class Program
    {
        static void Main(string[] args)
        {
            int amountOfPeople = int.Parse(Console.ReadLine());
            int[] liftWagons = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            bool emptyQueue = false;
            bool emptySpots = false;
            for (int i = 0; i < liftWagons.Length; i++)
            {
                if (liftWagons[i] >= 0 && liftWagons[i] < 4)
                {
                    liftWagons[i]++;
                    amountOfPeople--;

                    if (amountOfPeople == 0)
                    {
                        emptyQueue = true;
                        break;
                    }

                    i = -1;
                }
            }

            if (emptyQueue)
            {
                for (int j = 0; j < liftWagons.Length; j++)
                {
                    if (liftWagons[j] < 4)
                    {
                        emptySpots = true;
                    }
                }

                if (emptySpots)
                {
                    Console.WriteLine($"The lift has empty spots!");
                    Console.WriteLine(string.Join(" ", liftWagons));
                }
                else
                {
                    Console.WriteLine(string.Join(" ", liftWagons));
                }
            }
            else
            {
                Console.WriteLine($"There isn't enough space! {amountOfPeople} people in a queue!");
                Console.WriteLine(string.Join(" ", liftWagons));
            }
        }
    }
}
