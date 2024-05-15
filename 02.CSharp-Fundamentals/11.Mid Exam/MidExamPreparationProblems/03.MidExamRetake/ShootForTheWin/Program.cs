using System;
using System.Collections.Generic;
using System.Linq;

namespace ShootForTheWin
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> targetSequence = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
            string inputString = Console.ReadLine();
            int targetCount = 0;

            while (inputString != "End")
            {
                int indexToShoot = int.Parse(inputString);
                int targetValueToCompare = 0;

                if (indexToShoot >= 0 && indexToShoot < targetSequence.Count)
                {
                    targetValueToCompare = targetSequence[indexToShoot];
                    targetSequence[indexToShoot] = -1;
                    targetCount++;

                    for (int i = 0; i < targetSequence.Count; i++)
                    {
                        if (targetSequence[i] != -1)
                        {
                            if (targetSequence[i] > targetValueToCompare)
                            {
                                targetSequence[i] -= targetValueToCompare;
                            }
                            else
                            {
                                targetSequence[i] += targetValueToCompare;
                            }
                        }

                    }
                }

                inputString = Console.ReadLine();
            }

            Console.WriteLine($"Shot targets: {targetCount} -> {string.Join(" ", targetSequence)}");
        }
    }
}
