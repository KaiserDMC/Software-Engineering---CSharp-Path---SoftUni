using System;
using System.Text.RegularExpressions;

namespace MatchFullName
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputToMatch = Console.ReadLine();

            string regexPattern = @"\b[A-Z][a-z]+ [A-Z][a-z]+\b";

            MatchCollection outputNames = Regex.Matches(inputToMatch, regexPattern);

            foreach (Match name in outputNames)
            {
                Console.Write($"{name} ");
            }
        }
    }
}
