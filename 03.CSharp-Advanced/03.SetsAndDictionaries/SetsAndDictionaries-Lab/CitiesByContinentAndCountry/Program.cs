using System;
using System.Collections.Generic;
using System.Linq;

namespace CitiesByContinentAndCountry
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, List<string>>> cityAndCountryByContinent =
                new Dictionary<string, Dictionary<string, List<string>>>();

            int inputCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < inputCount; i++)
            {
                string[] inputStrings = Console.ReadLine().Split(" ").ToArray();

                string continent = inputStrings[0];
                string country = inputStrings[1];
                string city = inputStrings[2];

                if (!cityAndCountryByContinent.ContainsKey(continent))
                {
                    cityAndCountryByContinent.Add(continent, new Dictionary<string, List<string>>());
                }

                if (!cityAndCountryByContinent[continent].ContainsKey(country))
                {
                    cityAndCountryByContinent[continent].Add(country, new List<string>());
                }

                cityAndCountryByContinent[continent][country].Add(city);
            }

            foreach (var cityAndCountry in cityAndCountryByContinent)
            {
                Console.WriteLine($"{cityAndCountry.Key}:");
                Console.WriteLine(string.Join(Environment.NewLine, cityAndCountry.Value.Select(x => $"{x.Key} -> {string.Join(", ", x.Value)}")));
            }
        }
    }
}
