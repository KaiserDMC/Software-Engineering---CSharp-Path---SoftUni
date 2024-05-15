using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Race
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> runnerNames = Console.ReadLine().Split(", ").ToList();

            string regexPattern = @"(?<name>[A-Za-z]+)|(?<distance>\d)";

            Dictionary<string, int> distanceByRunner = new Dictionary<string, int>();

            while (true)
            {
                string currentRunner = Console.ReadLine();

                if (currentRunner == "end of race")
                {
                    break;
                }

                MatchCollection validRunners = Regex.Matches(currentRunner, regexPattern);

                string name = string.Empty;
                int separateDigits = 0;

                foreach (Match letterOrDigit in validRunners)
                {
                    foreach (char letter in letterOrDigit.Groups["name"].Value)
                    {
                        name += letter;
                    }

                    foreach (char digit in letterOrDigit.Groups["distance"].Value)
                    {
                        separateDigits += int.Parse(letterOrDigit.Groups["distance"].Value);

                    }
                }

                if (runnerNames.Contains(name))
                {
                    string runnerName = name;
                    int runnerDistance = separateDigits;

                    if (distanceByRunner.ContainsKey(name))
                    {
                        distanceByRunner[name] += separateDigits;
                    }
                    else
                    {
                        distanceByRunner.Add(runnerName, runnerDistance);
                    }

                }
            }

            int placeCounter = 1;
            string derivative = String.Empty;

            foreach (var runner in distanceByRunner.OrderByDescending(n => n.Value).Take(3))
            {
                if (placeCounter == 1)
                {
                    derivative = "st";
                }
                else if (placeCounter == 2)
                {
                    derivative = "nd";
                }
                else
                {
                    derivative = "rd";
                }

                Console.WriteLine($"{placeCounter}{derivative} place: {runner.Key}");
                placeCounter++;
            }
        }
    }
}
