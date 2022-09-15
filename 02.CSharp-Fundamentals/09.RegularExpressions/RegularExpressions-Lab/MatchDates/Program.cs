using System;
using System.Text.RegularExpressions;

namespace MatchDates
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputToMatch = Console.ReadLine();

            string regexPattern = @"\b(?<day>[0-9]{2})(?<sep>[\S])(?<month>[A-Z][a-z]{2})\k<sep>(?<year>[0-9]{4})\b";

            MatchCollection matchedDates = Regex.Matches(inputToMatch, regexPattern);

            foreach (Match date in matchedDates)
            {
                Console.WriteLine($"Day: {date.Groups["day"].Value}, Month: {date.Groups["month"].Value}, Year: {date.Groups["year"].Value}");
            }
        }
    }
}
