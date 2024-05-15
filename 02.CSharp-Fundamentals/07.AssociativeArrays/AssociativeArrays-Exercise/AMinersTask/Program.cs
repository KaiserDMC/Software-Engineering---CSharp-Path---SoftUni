using System;
using System.Collections.Generic;

namespace AMinersTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> resourceQuantitiesDictionary = new Dictionary<string, int>();

            while (true)
            {
                string inputResource = Console.ReadLine();

                if (inputResource == "stop")
                {
                    break;
                }

                int quantity = int.Parse(Console.ReadLine());

                if (!resourceQuantitiesDictionary.ContainsKey(inputResource))
                {
                    resourceQuantitiesDictionary.Add(inputResource, quantity);
                }
                else
                {
                    resourceQuantitiesDictionary[inputResource] += quantity;
                }
            }

            foreach (KeyValuePair<string, int> VARIABLE in resourceQuantitiesDictionary)
            {
                Console.WriteLine($"{VARIABLE.Key} -> {VARIABLE.Value}");
            }
        }
    }
}
