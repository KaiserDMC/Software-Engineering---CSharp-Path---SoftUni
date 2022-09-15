using System;
using System.Collections.Generic;
using System.Linq;

namespace DrumSet
{
    class Program
    {
        static void Main(string[] args)
        {
            double savings = double.Parse(Console.ReadLine());
            List<int> drumSetQuality = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
            string inputCommand = Console.ReadLine();
            List<int> originalDrumQuality = new List<int>();
            originalDrumQuality.AddRange(drumSetQuality);

            while (inputCommand != "Hit it again, Gabsy!")
            {
                int hitPower = int.Parse(inputCommand);

                for (int i = 0; i < drumSetQuality.Count; i++)
                {
                    int costForDrum = originalDrumQuality[i] * 3;

                    drumSetQuality[i] -= hitPower;


                    if (drumSetQuality[i] <= 0)
                    {
                        if (savings < 0 || costForDrum > savings)
                        {
                            drumSetQuality.RemoveAt(i);
                            originalDrumQuality.RemoveAt(i);
                            i--;
                        }

                        if (savings >= costForDrum)
                        {
                            savings -= costForDrum;
                            drumSetQuality.RemoveAt(i);
                            drumSetQuality.Insert(i, originalDrumQuality[i]);
                        }
                    }
                }

                inputCommand = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", drumSetQuality));
            Console.WriteLine($"Gabsy has {savings:f2}lv.");

        }
    }
}
