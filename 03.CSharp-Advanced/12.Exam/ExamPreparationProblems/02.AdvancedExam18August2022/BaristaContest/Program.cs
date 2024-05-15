using System;
using System.Collections.Generic;
using System.Linq;

namespace BaristaContest
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] coffeeInput = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int[] milkInput = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            Queue<int> coffeeQuantities = new Queue<int>();
            Stack<int> milkQuantities = new Stack<int>();

            Dictionary<string, int> drinksByQuatity = new Dictionary<string, int>()
            {
                { "Cortado", 50 },
                { "Espresso", 75 },
                { "Capuccino", 100 },
                { "Americano", 150 },
                { "Latte", 200 }
            };

            Dictionary<string, int> actualDrinks = new Dictionary<string, int>();

            foreach (var number in coffeeInput)
            {
                coffeeQuantities.Enqueue(number);
            }

            foreach (var number in milkInput)
            {
                milkQuantities.Push(number);
            }


            while (true)
            {
                if (coffeeQuantities.Count == 0 || milkQuantities.Count == 0)
                {
                    break;
                }

                bool validDrink = false;

                int currentCoffeeQuantity = coffeeQuantities.Dequeue();
                int currentMilkQuantity = milkQuantities.Pop();

                int sumLiquids = currentCoffeeQuantity + currentMilkQuantity;

                foreach (var drink in drinksByQuatity)
                {
                    if (sumLiquids == drink.Value)
                    {
                        if (!actualDrinks.ContainsKey(drink.Key))
                        {
                            actualDrinks.Add(drink.Key, 0);
                        }

                        actualDrinks[drink.Key]++;
                        validDrink = true;
                    }
                }

                if (!validDrink)
                {
                    currentMilkQuantity -= 5;
                    milkQuantities.Push(currentMilkQuantity);
                }
            }

            if (coffeeQuantities.Count == 0 && milkQuantities.Count == 0)
            {
                Console.WriteLine($"Nina is going to win! She used all the coffee and milk!");
            }
            else
            {
                Console.WriteLine($"Nina needs to exercise more! She didn't use all the coffee and milk!");
            }

            if (coffeeQuantities.Count != 0)
            {
                Console.Write($"Coffee left: ");
                Console.WriteLine(string.Join(", ", coffeeQuantities));
            }
            else
            {
                Console.WriteLine($"Coffee left: none");
            }

            if (milkQuantities.Count != 0)
            {
                Console.Write($"Milk left: ");
                Console.WriteLine(string.Join(", ", milkQuantities));
            }
            else
            {
                Console.WriteLine($"Milk left: none");
            }

            foreach (var drink in actualDrinks.OrderBy(d => d.Value).ThenByDescending(d => d.Key))
            {
                Console.WriteLine($"{drink.Key}: {drink.Value}");
            }
        }
    }
}