using System;
using System.Collections.Generic;
using System.Linq;

namespace TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberPumps = int.Parse(Console.ReadLine());

            Queue<string> pumpQueue = new Queue<string>();
            int sumFuel = 0;

            for (int i = 0; i < numberPumps; i++)
            {
                pumpQueue.Enqueue(Console.ReadLine());
            }

            for (int j = 0; j < numberPumps; j++)
            {
                bool isPossible = true;

                for (int k = 0; k < pumpQueue.Count; k++)
                {
                    int availableFuel = int.Parse(pumpQueue.Peek().Split().First());
                    int distanceTravel = int.Parse(pumpQueue.Peek().Split().Last());

                    pumpQueue.Enqueue(pumpQueue.Dequeue());

                    if (!isPossible)
                    {
                        continue;
                    }
                    sumFuel += availableFuel;

                    if (sumFuel >= distanceTravel)
                    {
                        sumFuel -= distanceTravel;
                    }
                    else
                    {
                        isPossible = false;
                    }

                }

                if (isPossible)
                {
                    Console.WriteLine(j);
                    return;
                }

                pumpQueue.Enqueue(pumpQueue.Dequeue());
                sumFuel = 0;
            }
        }
    }
}
