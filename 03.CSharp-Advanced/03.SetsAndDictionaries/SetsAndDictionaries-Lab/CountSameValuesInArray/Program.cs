using System;
using System.Collections.Generic;
using System.Linq;

namespace CountSameValuesInArray
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<double, int> valuesCounterDictionary = new Dictionary<double, int>();

            double[] inputDoubles = Console.ReadLine().Split(" ").Select(double.Parse).ToArray();

            for (int i = 0; i < inputDoubles.Length; i++)
            {
                double currentNumber = inputDoubles[i];

                if (!valuesCounterDictionary.ContainsKey(currentNumber))
                {
                    valuesCounterDictionary.Add(currentNumber, 0);
                }

                valuesCounterDictionary[currentNumber]++;
            }

            foreach (var values in valuesCounterDictionary)
            {
                Console.WriteLine($"{values.Key} - {values.Value} times");
            }
        }
    }
}
