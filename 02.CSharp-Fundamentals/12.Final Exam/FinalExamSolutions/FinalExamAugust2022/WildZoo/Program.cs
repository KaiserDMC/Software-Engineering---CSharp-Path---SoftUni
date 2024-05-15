using System;
using System.Collections.Generic;
using System.Linq;

namespace WildZoo
{
    class Program
    {
        static void Main(string[] args)
        {
            AnimalCollection animalCollection = new AnimalCollection();

            while (true)
            {
                string[] animalCommandStrings = Console.ReadLine().Split(":").ToArray();

                if (animalCommandStrings[0] == "EndDay")
                {
                    break;
                }

                string commandName = animalCommandStrings[0];

                string[] animalInformation = animalCommandStrings[1].Split("-").ToArray();

                switch (commandName)
                {
                    case "Add":
                        string animalName = animalInformation[0].TrimStart();
                        double animalFood = double.Parse(animalInformation[1]);
                        string animalArea = animalInformation[2];

                        int indexOfAnimal = animalCollection.Animals.FindIndex(a => a.Name == animalName);

                        if (indexOfAnimal != -1)
                        {
                            animalCollection.Animals[indexOfAnimal].FoodNeeded += animalFood;
                        }
                        else
                        {
                            Animal animal = new Animal(animalName, animalFood, animalArea);
                            animalCollection.Animals.Add(animal);
                        }

                        break;
                    case "Feed":
                        animalName = animalInformation[0].TrimStart();
                        animalFood = double.Parse(animalInformation[1]);

                        indexOfAnimal = animalCollection.Animals.FindIndex(a => a.Name == animalName);

                        if (indexOfAnimal != -1)
                        {
                            animalCollection.Animals[indexOfAnimal].FoodNeeded -= animalFood;

                            if (animalCollection.Animals[indexOfAnimal].FoodNeeded <= 0)
                            {
                                animalCollection.Animals.Remove(animalCollection.Animals[indexOfAnimal]);
                                Console.WriteLine($"{animalName} was successfully fed");
                            }
                        }

                        break;
                }
            }

            Console.WriteLine("Animals:");
            foreach (var animal in animalCollection.Animals)
            {
                Console.WriteLine($" {animal.Name} -> {animal.FoodNeeded}g");
            }

            List<Animal> areasWithHungryAnimalsList = animalCollection.Animals.Where(a => a.FoodNeeded > 0).ToList();

            //List<string> areasList = areasWithHungryAnimalsList.Select(a => a.Area).ToList();

            int count = 0;
            Dictionary<string, int> areaAndCount = new Dictionary<string, int>();
            Console.WriteLine($"Areas with hungry animals:");
            foreach (var animal in areasWithHungryAnimalsList)
            {
                string currentArea = animal.Area;

                if (animal.Area.Equals(currentArea))
                {
                    if (!areaAndCount.ContainsKey(currentArea))
                    {
                        areaAndCount.Add(currentArea, count + 1);

                    }
                    else
                    {
                        areaAndCount[currentArea]++;
                    }
                }
            }

            foreach (var VARIABLE in areaAndCount)
            {
                Console.WriteLine($"{VARIABLE.Key}: {VARIABLE.Value}");

            }
        }
    }

    class Animal
    {
        public Animal(string name, double foodNeeded, string area)
        {
            this.Name = name;
            this.FoodNeeded = foodNeeded;
            this.Area = area;
        }

        public string Name { get; set; }
        public double FoodNeeded { get; set; }
        public string Area { get; set; }
    }

    class AnimalCollection
    {
        public AnimalCollection()
        {
            Animals = new List<Animal>();
        }

        public List<Animal> Animals { get; set; }
    }

}
