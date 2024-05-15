using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Furniture
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputConsole = Console.ReadLine();

            string regexPattern =
                @"[>]{2}(?<furnitureName>[A-Za-z\s]+)[<]{2}(?<price>\d+(.\d+)?)[!]{1}(?<quantity>\d+)";

            double totalPrice = 0;
            List<string> boughtFurniture = new List<string>();

            while (inputConsole != "Purchase")
            {
                Match furnitureMatch = Regex.Match(inputConsole, regexPattern);

                if (furnitureMatch.Success)
                {
                    string furnitureName = furnitureMatch.Groups["furnitureName"].Value;
                    double price = double.Parse(furnitureMatch.Groups["price"].Value);
                    int quantity = int.Parse(furnitureMatch.Groups["quantity"].Value);

                    totalPrice += (price * quantity);

                    boughtFurniture.Add(furnitureName);
                }

                inputConsole = Console.ReadLine();
            }

            Console.WriteLine($"Bought furniture:");

            foreach (string furniture in boughtFurniture)
            {
                Console.WriteLine($"{furniture}");
            }

            Console.WriteLine($"Total money spend: {totalPrice:f2}");
        }
    }
}
