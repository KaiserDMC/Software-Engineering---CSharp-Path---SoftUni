using System;
using System.Collections.Generic;
using System.Linq;

namespace FastFood
{
    class Program
    {
        static void Main(string[] args)
        {
            int quantityFood = int.Parse(Console.ReadLine());

            int[] incomingOrders = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            Queue<int> orderQueue = new Queue<int>(incomingOrders);

            Console.WriteLine($"{orderQueue.Max()}");

            while (orderQueue.Count > 0)
            {
                if (quantityFood >= orderQueue.Peek())
                {
                    quantityFood -= orderQueue.Dequeue();
                }
                else
                {
                    break;
                }

                if (quantityFood <= 0)
                {
                    break;
                }
            }

            if (orderQueue.Count > 0)
            {
                Console.WriteLine($"Orders left: {string.Join(" ", orderQueue)}");
            }
            else
            {
                Console.WriteLine($"Orders complete");
            }
        }
    }
}
