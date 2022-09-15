using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace P_rates
{
    class Program
    {
        static void Main(string[] args)
        {
            CityCollection citiesCollection = new CityCollection();

            while (true)
            {
                string[] inputStrings = Console.ReadLine().Split("||").ToArray();

                if (inputStrings[0] == "Sail")
                {
                    break;
                }

                string cityName = inputStrings[0];
                int cityPopulation = int.Parse(inputStrings[1]);
                int cityGold = int.Parse(inputStrings[2]);

                int presentCity = citiesCollection.Cities.FindIndex(c => c.Name == cityName);

                if (presentCity == -1)
                {
                    City city = new City
                    {
                        Name = cityName,
                        Population = cityPopulation,
                        Gold = cityGold
                    };

                    citiesCollection.Cities.Add(city);
                }
                else
                {
                    citiesCollection.Cities[presentCity].Population += cityPopulation;
                    citiesCollection.Cities[presentCity].Gold += cityGold;
                }
            }

            string[] eventStrings = Console.ReadLine().Split("=>").ToArray();

            while (eventStrings[0] != "End")
            {
                string eventName = eventStrings[0];

                switch (eventName)
                {
                    case "Plunder":
                        string currentCity = eventStrings[1];
                        int currentPeople = int.Parse(eventStrings[2]);
                        int currentGold = int.Parse(eventStrings[3]);

                        int indexOfCity = citiesCollection.Cities.FindIndex(c => c.Name == currentCity);

                        citiesCollection.Cities[indexOfCity].Plunder(currentPeople, currentGold);

                        Console.WriteLine($"{currentCity} plundered! {currentGold} gold stolen, {currentPeople} citizens killed.");

                        bool wipedOff = citiesCollection.Cities[indexOfCity].IsWipedOff();

                        if (wipedOff)
                        {
                            citiesCollection.Cities.RemoveAt(indexOfCity);

                            Console.WriteLine($"{currentCity} has been wiped off the map!");
                        }

                        break;
                    case "Prosper":
                        currentCity = eventStrings[1];
                        currentGold = int.Parse(eventStrings[2]);

                        indexOfCity = citiesCollection.Cities.FindIndex(c => c.Name == currentCity);

                        if (currentGold < 0)
                        {
                            Console.WriteLine($"Gold added cannot be a negative number!");
                        }
                        else
                        {
                            citiesCollection.Cities[indexOfCity].Prosper(currentGold);
                        }

                        break;
                }

                eventStrings = Console.ReadLine().Split("=>").ToArray();
            }

            if (citiesCollection.Cities.Count == 0)
            {
                Console.WriteLine($"Ahoy, Captain! All targets have been plundered and destroyed!");
            }
            else
            {
                Console.WriteLine($"Ahoy, Captain! There are {citiesCollection.Cities.Count} wealthy settlements to go to:");

                foreach (City city in citiesCollection.Cities)
                {
                    Console.WriteLine($"{city.Name} -> Population: {city.Population} citizens, Gold: {city.Gold} kg");
                }
            }
        }
    }

    class City
    {
        public string Name { get; set; }
        public int Population { get; set; }
        public int Gold { get; set; }

        public void Plunder(int people, int gold)
        {
            this.Population -= people;
            this.Gold -= gold;
        }

        public bool IsWipedOff()
        {
            bool wiped = false;

            if (this.Population <= 0 || this.Gold <= 0)
            {
                wiped = true;
            }

            return wiped;
        }

        public void Prosper(int gold)
        {
            this.Gold += gold;

            Console.WriteLine($"{gold} gold added to the city treasury. {this.Name} now has {this.Gold} gold.");
        }
    }

    class CityCollection
    {
        public CityCollection()
        {
            Cities = new List<City>();
        }
        public List<City> Cities { get; set; }
    }
}
