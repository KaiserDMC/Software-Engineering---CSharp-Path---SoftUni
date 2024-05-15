using System;
using System.Text.RegularExpressions;

namespace BossRush
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfInputs = int.Parse(Console.ReadLine());

            string regexPattern =
                @"(?<surr1>[\|])(?<bossName>[A-Z]{4,})\k<surr1>:(?<surr2>[#])(?<title>[A-Za-z]+ [A-Za-z]+)\k<surr2>";

            for (int i = 0; i < numberOfInputs; i++)
            {
                string currentInput = Console.ReadLine();

                Match validMatch = Regex.Match(currentInput, regexPattern);

                if (validMatch.Success)
                {
                    string bossName = validMatch.Groups["bossName"].Value;
                    string title = validMatch.Groups["title"].Value;

                    int strength = bossName.Length;
                    int armor = title.Length;

                    Console.WriteLine($"{bossName}, The {title}");
                    Console.WriteLine($">> Strength: {strength}");
                    Console.WriteLine($">> Armor: {armor}");
                }
                else
                {
                    Console.WriteLine($"Access denied!");
                }
            }
        }
    }
}
