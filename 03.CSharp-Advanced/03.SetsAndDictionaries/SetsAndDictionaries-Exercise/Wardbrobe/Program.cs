using System;
using System.Collections.Generic;
using System.Linq;

namespace Wardbrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int countInput = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, int>> clothesWardrobe =
                new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < countInput; i++)
            {
                string[] currentWardrobe = Console.ReadLine().Split(new string[] { " -> ", "," }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                string colour = currentWardrobe[0];

                if (!clothesWardrobe.ContainsKey(colour))
                {
                    clothesWardrobe.Add(colour, new Dictionary<string, int>());
                }

                for (int j = 1; j < currentWardrobe.Length; j++)
                {
                    string currentClothing = currentWardrobe[j];

                    if (!clothesWardrobe[colour].ContainsKey(currentClothing))
                    {
                        clothesWardrobe[colour].Add(currentClothing, 0);
                    }

                    clothesWardrobe[colour][currentClothing]++;
                }
            }

            string[] lookingFor = Console.ReadLine().Split(" ").ToArray();

            foreach (var clothing in clothesWardrobe)
            {
                Console.WriteLine($"{clothing.Key} clothes:");

                foreach (var clo in clothing.Value)
                {
                    if (clothing.Key == lookingFor[0])
                    {
                        if (clo.Key == lookingFor[1])
                        {
                            Console.WriteLine($"* {clo.Key} - {clo.Value} (found!)");
                            continue;
                        }
                    }

                    Console.WriteLine($"* {clo.Key} - {clo.Value}");
                }
            }
        }
    }
}
