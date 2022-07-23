using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace SoftUniBarIncome
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, double>> customersByProductAndPrice =
                new Dictionary<string, Dictionary<string, double>>();

            double totalIncome = 0;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end of shift")
                {
                    break;
                }

                string regexPattern =
                    @"%(?<name>[A-Z][a-z]+)%([^|$%.]*)<(?<product>\w+)>([^|$%.]*)\|(?<count>\d+)\|([^|$%.]*?)(?<price>\d+.*\d+)\$";

                Match validMatch = Regex.Match(input, regexPattern);

                if (validMatch.Success)
                {
                    string name = validMatch.Groups["name"].Value;
                    string product = validMatch.Groups["product"].Value;
                    int count = int.Parse(validMatch.Groups["count"].Value);
                    double price = double.Parse(validMatch.Groups["price"].Value);

                    if (!customersByProductAndPrice.ContainsKey(name))
                    {
                        customersByProductAndPrice.Add(name, new Dictionary<string, double>());
                        customersByProductAndPrice[name].Add(product, count * price);
                    }

                    totalIncome += (count * price);
                }
            }

            foreach (var customer in customersByProductAndPrice)
            {
                Console.Write($"{customer.Key}: ");
                Console.Write(string.Join("", customer.Value.Select(x => $"{x.Key} - {x.Value:f2}")));

                Console.WriteLine();
            }

            Console.WriteLine($"Total income: {totalIncome:f2}");
        }
    }
}
