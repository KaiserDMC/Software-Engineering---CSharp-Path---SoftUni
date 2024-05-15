using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductShop
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, double>> shopListDictionary =
                new Dictionary<string, Dictionary<string, double>>();

            while (true)
            {
                string[] inputCommand = Console.ReadLine().Split(", ").ToArray();

                if (inputCommand[0] == "Revision")
                {
                    break;
                }

                string shopName = inputCommand[0];
                string product = inputCommand[1];
                double price = double.Parse(inputCommand[2]);

                if (!shopListDictionary.ContainsKey(shopName))
                {
                    shopListDictionary.Add(shopName, new Dictionary<string, double>());
                }

                if (!shopListDictionary[shopName].ContainsKey(product))
                {
                    shopListDictionary[shopName].Add(product, price);
                }
                else
                {
                    shopListDictionary[shopName][product] = price;
                }
            }

            foreach (var shop in shopListDictionary.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{shop.Key}->");
                Console.WriteLine(string.Join(Environment.NewLine, shop.Value.Select(x => $"Product: {x.Key}, Price: {x.Value}")));
            }
        }
    }
}
