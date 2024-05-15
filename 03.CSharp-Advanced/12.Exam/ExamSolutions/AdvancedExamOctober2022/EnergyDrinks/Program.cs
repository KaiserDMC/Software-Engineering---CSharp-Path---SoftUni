using System;
using System.Collections.Generic;
using System.Linq;

namespace EnergyDrinks
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> caffeineMiligrams = new Stack<int>();
            Queue<int> energyDrinkMiligrams = new Queue<int>();

            int[] caffeine = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int[] energyDrink = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            foreach (var caf in caffeine)
            {
                caffeineMiligrams.Push(caf);
            }

            foreach (var energy in energyDrink)
            {
                energyDrinkMiligrams.Enqueue(energy);
            }

            int sumDailyCaf = 0;

            while (true)
            {
                if (!caffeineMiligrams.Any() || !energyDrinkMiligrams.Any())
                {
                    break;
                }

                int currCaffeine = caffeineMiligrams.Pop();
                int currEnergyDrink = energyDrinkMiligrams.Dequeue();
                int currentDrinkIntake = currCaffeine * currEnergyDrink;

                if (currentDrinkIntake <= 300)
                {
                    sumDailyCaf += currentDrinkIntake;

                    if (sumDailyCaf > 300)
                    {
                        sumDailyCaf -= currentDrinkIntake;
                        energyDrinkMiligrams.Enqueue(currEnergyDrink);
                        sumDailyCaf -= 30;

                        if (sumDailyCaf < 0)
                        {
                            sumDailyCaf = 0;
                        }
                    }
                }
                else
                {
                    energyDrinkMiligrams.Enqueue(currEnergyDrink);
                    sumDailyCaf -= 30;

                    if (sumDailyCaf < 0)
                    {
                        sumDailyCaf = 0;
                    }
                }
            }

            if (energyDrinkMiligrams.Any())
            {
                Console.Write($"Drinks left: ");
                Console.WriteLine(string.Join(", ", energyDrinkMiligrams));
            }
            else
            {
                Console.WriteLine($"At least Stamat wasn't exceeding the maximum caffeine.");
            }

            Console.WriteLine($"Stamat is going to sleep with {sumDailyCaf} mg caffeine.");
        }
    }
}