using System;
using System.Collections.Generic;
using System.Linq;

namespace HotPotato
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] kidsNames = Console.ReadLine().Split(" ").ToArray();
            int maxTosses = int.Parse(Console.ReadLine());

            Queue<string> kidQueue = new Queue<string>(kidsNames);

            int tossCounter = 1;
            while (kidQueue.Count > 1)
            {
                string currentKid = kidQueue.Dequeue();

                if (tossCounter == maxTosses)
                {
                    Console.WriteLine($"Removed {currentKid}");
                    tossCounter = 1;
                }
                else
                {
                    tossCounter++;
                    kidQueue.Enqueue(currentKid);
                }
            }

            Console.WriteLine($"Last is {kidQueue.Dequeue()}");
        }
    }
}
