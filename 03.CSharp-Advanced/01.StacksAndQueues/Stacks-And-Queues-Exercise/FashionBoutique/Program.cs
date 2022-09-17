using System;
using System.Collections.Generic;
using System.Linq;

namespace FashionBoutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sequenceInts = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int rackCapacity = int.Parse(Console.ReadLine());

            Stack<int> stackClothes = new Stack<int>(sequenceInts);

            int sumOfClothing = 0;
            int counterRacks = 1;

            while (stackClothes.Count > 0)
            {
                int currentClothing = stackClothes.Peek();

                if (sumOfClothing + currentClothing <= rackCapacity)
                {
                    sumOfClothing += currentClothing;
                    stackClothes.Pop();

                    if (sumOfClothing == rackCapacity)
                    {
                        sumOfClothing = 0;

                        if (stackClothes.Count > 0)
                        {
                            counterRacks++;
                        }
                    }
                }
                else
                {
                    counterRacks++;
                    sumOfClothing = 0;
                }
            }

            Console.WriteLine($"{counterRacks}");
        }
    }
}
