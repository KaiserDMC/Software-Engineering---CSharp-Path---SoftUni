using System;
using System.Collections.Generic;
using System.Linq;

namespace TreasureHunt
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> initialLootList = Console.ReadLine().Split("|").ToList();
            string inputString = Console.ReadLine();

            while (inputString != "Yohoho!")
            {
                string[] commandString = inputString.Split(" ").ToArray();
                string commandName = commandString[0];

                switch (commandName)
                {
                    case "Loot":
                        for (int i = 1; i < commandString.Length; i++)
                        {
                            string currentLootItem = commandString[i];
                            bool isLootPresent = LootPresent(initialLootList, currentLootItem);

                            if (!isLootPresent)
                            {
                                initialLootList.Insert(0, currentLootItem);
                            }
                        }
                        break;
                    case "Drop":
                        int indexToDrop = int.Parse(commandString[1]);
                        if (indexToDrop >= 0 && indexToDrop < initialLootList.Count)
                        {
                            string tempItemSaving = initialLootList[indexToDrop];
                            initialLootList.RemoveAt(indexToDrop);
                            initialLootList.Add(tempItemSaving);
                        }
                        break;
                    case "Steal":
                        int stealCount = int.Parse(commandString[1]);
                        List<string> stolenLootList = new List<string>();

                        if (stealCount > initialLootList.Count)
                        {
                            stolenLootList.AddRange(initialLootList);
                            initialLootList.RemoveRange(0, initialLootList.Count);
                        }
                        else
                        {
                            stolenLootList = initialLootList.Skip(initialLootList.Count - stealCount).Take(stealCount)
                                .ToList();
                            initialLootList.RemoveRange(initialLootList.IndexOf(stolenLootList[0]), stealCount);
                        }

                        Console.WriteLine(string.Join(", ", stolenLootList));
                        break;
                }

                inputString = Console.ReadLine();
            }

            if (initialLootList.Count == 0)
            {
                Console.WriteLine($"Failed treasure hunt.");
            }
            else
            {
                double sum = 0;
                for (int i = 0; i < initialLootList.Count; i++)
                {
                    sum += initialLootList[i].Length;
                }

                double averageGain = 0;
                averageGain = sum / (double)initialLootList.Count;

                Console.WriteLine($"Average treasure gain: {averageGain:f2} pirate credits.");
            }
        }

        static bool LootPresent(List<string> initialLootList, string lootItem)
        {
            bool isLootPresent = false;

            if (initialLootList.Contains(lootItem))
            {
                isLootPresent = true;
            }

            return isLootPresent;
        }
    }
}
