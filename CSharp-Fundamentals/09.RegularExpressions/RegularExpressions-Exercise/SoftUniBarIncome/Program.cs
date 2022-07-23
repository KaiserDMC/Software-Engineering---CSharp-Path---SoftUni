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
            double totalIncome = 0;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end of shift")
                {
                    break;
                }

                string regexPattern =
                    @"%(?<name>[A-Z][a-z]+)\%[^|$%.]*\<(?<product>\w+)\>[^|$%.]*\|(?<count>\d+)\|[^|$%.]*?(?<price>\d+([.]\d+)?)\$";

                Match validMatch = Regex.Match(input, regexPattern);

                if (validMatch.Success)
                {
                    string name = validMatch.Groups["name"].Value;
                    string product = validMatch.Groups["product"].Value;
                    int count = int.Parse(validMatch.Groups["count"].Value);
                    double price = double.Parse(validMatch.Groups["price"].Value);

                    Console.WriteLine($"{name}: {product} - {(count * price):f2}");

                    totalIncome += (count * price);
                }
            }

            Console.WriteLine($"Total income: {totalIncome:f2}");
        }
    }
}
