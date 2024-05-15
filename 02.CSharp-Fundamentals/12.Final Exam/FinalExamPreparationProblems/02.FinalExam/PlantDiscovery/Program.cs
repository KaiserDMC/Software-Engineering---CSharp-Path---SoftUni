using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace PlantDiscovery
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfInputs = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<int, List<double>>> plantsByRarity = new Dictionary<string, Dictionary<int, List<double>>>();

            for (int i = 0; i < numberOfInputs; i++)
            {
                string[] plantInputs = Console.ReadLine().Split("<->").ToArray();

                if (!plantsByRarity.ContainsKey(plantInputs[0]))
                {
                    plantsByRarity.Add(plantInputs[0], new Dictionary<int, List<double>>());
                    plantsByRarity[plantInputs[0]].Add(int.Parse(plantInputs[1]), new List<double>());
                }
                else
                {
                    int tempKey = plantsByRarity[plantInputs[0]].Keys.First();

                    plantsByRarity[plantInputs[0]].Remove(tempKey);

                    plantsByRarity[plantInputs[0]].Add(int.Parse(plantInputs[1]), new List<double>());
                }
            }

            while (true)
            {
                string[] commandStrings = Console.ReadLine().Split(":").ToArray();

                if (commandStrings[0] == "Exhibition")
                {
                    break;
                }

                string commandName = commandStrings[0];
                string[] subCommandStrings = commandStrings[1].Split(" - ").ToArray();

                switch (commandName)
                {
                    case "Rate":
                        string plantName = subCommandStrings[0].TrimStart();
                        double rating = double.Parse(subCommandStrings[1]);

                        if (plantsByRarity.ContainsKey(plantName))
                        {
                            int tempKey = plantsByRarity[plantName].Keys.First();

                            plantsByRarity[plantName][tempKey].Add(rating);
                        }
                        else
                        {
                            Console.WriteLine($"error");
                        }

                        break;
                    case "Update":
                        plantName = subCommandStrings[0].TrimStart();
                        int rarity = int.Parse(subCommandStrings[1]);

                        if (plantsByRarity.ContainsKey(plantName))
                        {
                            int tempKey = plantsByRarity[plantName].Keys.First();
                            List<double> tempValue = plantsByRarity[plantName].Values.FirstOrDefault();

                            plantsByRarity[plantName].Remove(tempKey);

                            plantsByRarity[plantName].Add(rarity, tempValue);

                        }
                        else
                        {
                            Console.WriteLine($"error");
                        }

                        break;
                    case "Reset":
                        plantName = subCommandStrings[0].TrimStart();

                        if (plantsByRarity.ContainsKey(plantName))
                        {
                            int tempKey = plantsByRarity[plantName].Keys.First();

                            plantsByRarity[plantName][tempKey].Clear();

                        }
                        else
                        {
                            Console.WriteLine($"error");
                        }

                        break;
                }
            }


            Console.WriteLine($"Plants for the exhibition:");

            foreach (var plants in plantsByRarity)
            {
                Console.Write($"- {plants.Key}; ");

                Console.Write(string.Join("", plants.Value.Select(x => $"Rarity: {x.Key}; Rating: {(x.Value.Count > 0 ? x.Value.Average() : 0):f2}")));

                Console.WriteLine();
            }
        }
    }
}
