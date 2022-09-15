using System;
using System.Collections.Generic;
using System.Linq;

namespace DragonArmy
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, SortedDictionary<string, Dragon>> dragonCollectionDictionary =
                new Dictionary<string, SortedDictionary<string, Dragon>>();

            int numberOfDragons = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfDragons; i++)
            {
                string[] inputStrings = Console.ReadLine().Split(" ").ToArray();

                string dragonType = inputStrings[0];
                string dragonName = inputStrings[1];
                string dragonDamage = inputStrings[2];
                string dragonHealth = inputStrings[3];
                string dragonArmor = inputStrings[4];

                if (!dragonCollectionDictionary.ContainsKey(dragonType))
                {
                    dragonCollectionDictionary.Add(dragonType, new SortedDictionary<string, Dragon>());
                }

                if (dragonCollectionDictionary[dragonType].ContainsKey(dragonName))
                {
                    //Override Stat Values

                    if (dragonHealth != "null")
                    {
                        dragonCollectionDictionary[dragonType][dragonName].Health = double.Parse(dragonHealth);
                    }
                    else
                    {
                        dragonCollectionDictionary[dragonType][dragonName].Health = 250;
                    }

                    if (dragonDamage != "null")
                    {
                        dragonCollectionDictionary[dragonType][dragonName].Damage = double.Parse(dragonDamage);
                    }
                    else
                    {
                        dragonCollectionDictionary[dragonType][dragonName].Damage = 45;
                    }


                    if (dragonArmor != "null")
                    {
                        dragonCollectionDictionary[dragonType][dragonName].Armor = double.Parse(dragonArmor);
                    }
                    else
                    {
                        dragonCollectionDictionary[dragonType][dragonName].Armor = 10;
                    }
                }
                else
                {
                    dragonCollectionDictionary[dragonType].Add(dragonName, new Dragon());

                    if (dragonHealth != "null")
                    {
                        dragonCollectionDictionary[dragonType][dragonName].Health = double.Parse(dragonHealth);
                    }

                    if (dragonDamage != "null")
                    {
                        dragonCollectionDictionary[dragonType][dragonName].Damage = double.Parse(dragonDamage);
                    }

                    if (dragonArmor != "null")
                    {
                        dragonCollectionDictionary[dragonType][dragonName].Armor = double.Parse(dragonArmor);
                    }
                }

            }

            foreach (var dragonTYPE in dragonCollectionDictionary)
            {
                double averageHealth = dragonTYPE.Value.Sum(x => x.Value.Health) / dragonTYPE.Value.Count();
                double averageDamage = dragonTYPE.Value.Sum(x => x.Value.Damage) / dragonTYPE.Value.Count();
                double averageArmor = dragonTYPE.Value.Sum(x => x.Value.Armor) / dragonTYPE.Value.Count();

                Console.WriteLine($"{dragonTYPE.Key}::({averageDamage:f2}/{averageHealth:f2}/{averageArmor:f2})");

                Console.WriteLine(string.Join(Environment.NewLine, dragonTYPE.Value.Select(x => $"-{x.Key} -> damage: {x.Value.Damage}, health: {x.Value.Health}, armor: {x.Value.Armor}")));
            }
        }
    }

    class Dragon
    {
        public Dragon()
        {
            this.Health = 250;
            this.Damage = 45;
            this.Armor = 10;
        }

        public double Health { get; set; }
        public double Damage { get; set; }
        public double Armor { get; set; }
    }
}
