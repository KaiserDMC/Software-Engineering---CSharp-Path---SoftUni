using System;
using System.Collections.Generic;
using System.Linq;

namespace CupsAndBottles
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> waterCupQueue = new Queue<int>(Console.ReadLine().Split(" ").Select(int.Parse).ToArray());
            Stack<int> bottleStack = new Stack<int>(Console.ReadLine().Split(" ").Select(int.Parse).ToArray());

            int wastedWater = 0;

            while (bottleStack.Count > 0 && waterCupQueue.Count > 0)
            {
                int currentBottle = bottleStack.Pop();
                int currentWaterCup = waterCupQueue.Peek();

                int difference = currentBottle - currentWaterCup;

                if (difference >= 0)
                {
                    waterCupQueue.Dequeue();
                    wastedWater += difference;
                }
                else
                {
                    while (currentWaterCup > 0 && bottleStack.Count >= 0)
                    {
                        currentWaterCup -= currentBottle;

                        if (currentWaterCup <= 0)
                        {
                            wastedWater += Math.Abs(currentWaterCup);
                            waterCupQueue.Dequeue();

                            break;
                        }

                        if (bottleStack.Count > 0)
                        {
                            currentBottle = bottleStack.Pop();
                        }
                    }
                }
            }

            if (bottleStack.Count > 0)
            {
                Console.WriteLine($"Bottles: {string.Join(" ", bottleStack)}");
            }
            else
            {
                Console.WriteLine($"Cups: {string.Join(" ", waterCupQueue)}");
            }

            Console.WriteLine($"Wasted litters of water: {wastedWater}");
        }
    }
}
