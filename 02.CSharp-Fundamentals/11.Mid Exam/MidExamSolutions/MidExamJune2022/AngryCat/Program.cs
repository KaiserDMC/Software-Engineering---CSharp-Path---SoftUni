using System;
using System.Collections.Generic;
using System.Linq;

namespace AngryCat
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> priceRatingsList = Console.ReadLine().Split(", ").Select(int.Parse).ToList();
            int entryPoint = int.Parse(Console.ReadLine());
            string itemTypeToBreak = Console.ReadLine();

            switch (itemTypeToBreak)
            {
                case "cheap":
                    int cheapItemToBreakRight = 0;

                    for (int i = entryPoint + 1; i < priceRatingsList.Count; i++)
                    {
                        if (priceRatingsList[entryPoint] > priceRatingsList[i])
                        {
                            cheapItemToBreakRight += priceRatingsList[i];
                        }
                    }

                    int cheapItemToBreakLeft = 0;

                    for (int i = entryPoint - 1; i >= 0; i--)
                    {
                        if (priceRatingsList[entryPoint] > priceRatingsList[i])
                        {
                            cheapItemToBreakLeft += priceRatingsList[i];
                        }
                    }

                    if (cheapItemToBreakLeft == cheapItemToBreakRight || cheapItemToBreakLeft > cheapItemToBreakRight)
                    {
                        Console.WriteLine($"Left - {cheapItemToBreakLeft}");
                    }
                    else if (cheapItemToBreakRight > cheapItemToBreakLeft)
                    {
                        Console.WriteLine($"Right - {cheapItemToBreakRight}");
                    }
                    break;
                case "expensive":
                    int expensiveItemToBreakRight = 0;

                    for (int i = entryPoint + 1; i < priceRatingsList.Count; i++)
                    {
                        if (priceRatingsList[entryPoint] <= priceRatingsList[i])
                        {
                            expensiveItemToBreakRight += priceRatingsList[i];
                        }
                    }

                    int expensiveItemToBreakLeft = 0;

                    for (int i = entryPoint - 1; i >= 0; i--)
                    {
                        if (priceRatingsList[entryPoint] <= priceRatingsList[i])
                        {
                            expensiveItemToBreakLeft += priceRatingsList[i];
                        }
                    }

                    if (expensiveItemToBreakLeft == expensiveItemToBreakRight || expensiveItemToBreakLeft > expensiveItemToBreakRight)
                    {
                        Console.WriteLine($"Left - {expensiveItemToBreakLeft}");
                    }
                    else if (expensiveItemToBreakRight > expensiveItemToBreakLeft)
                    {
                        Console.WriteLine($"Right - {expensiveItemToBreakRight}");
                    }
                    break;
            }
        }
    }
}
