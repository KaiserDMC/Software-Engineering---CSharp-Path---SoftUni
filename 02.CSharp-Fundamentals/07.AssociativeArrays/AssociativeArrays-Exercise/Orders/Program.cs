using System;
using System.Collections.Generic;
using System.Linq;

namespace Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> productsByPriceDictionary = new Dictionary<string, List<double>>();

            string[] productInputString = Console.ReadLine().Split(" ").ToArray();

            while (productInputString[0] != "buy")
            {
                string productName = productInputString[0];
                double singleProductPrice = double.Parse(productInputString[1]);
                int quantity = int.Parse(productInputString[2]);

                if (!productsByPriceDictionary.ContainsKey(productName))
                {
                    List<double> tempProductList = new List<double>();
                    tempProductList.Add(singleProductPrice);
                    tempProductList.Add(quantity);

                    productsByPriceDictionary.Add(productName, tempProductList);
                }
                else
                {
                    productsByPriceDictionary[productName][0] = singleProductPrice;
                    productsByPriceDictionary[productName][1] += quantity;
                }

                productInputString = Console.ReadLine().Split().ToArray();
            }

            foreach (var VARIABLE in productsByPriceDictionary)
            {
                Console.WriteLine($"{VARIABLE.Key} -> {(VARIABLE.Value[0] * VARIABLE.Value[1]):f2}");
            }
        }
    }
}
