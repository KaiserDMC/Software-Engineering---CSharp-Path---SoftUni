using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace KeyRevolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int priceOfBullets = int.Parse(Console.ReadLine());
            int sizeGunBarrel = int.Parse(Console.ReadLine());
            int[] bullets = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int[] locks = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int intelligenceValue = int.Parse(Console.ReadLine());

            Stack<int> bulletStack = new Stack<int>(bullets);
            Queue<int> lockQueue = new Queue<int>(locks);

            int counterBullets = 0;

            while (bulletStack.Count > 0 && lockQueue.Count > 0)
            {
                int currentBullet = bulletStack.Pop();
                int currentLock = lockQueue.Peek();

                if (currentBullet <= currentLock)
                {
                    Console.WriteLine($"Bang!");
                    lockQueue.Dequeue();
                }
                else
                {
                    Console.WriteLine($"Ping!");
                }

                counterBullets++;
                intelligenceValue -= priceOfBullets;

                if (counterBullets == sizeGunBarrel && bulletStack.Count > 0)
                {
                    Console.WriteLine($"Reloading!");
                    counterBullets = 0;
                }
            }

            if (bulletStack.Count == 0 && lockQueue.Count > 0)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {lockQueue.Count}");
            }
            else if (lockQueue.Count == 0)
            {
                Console.WriteLine($"{bulletStack.Count} bullets left. Earned ${intelligenceValue}");
            }
        }
    }
}
