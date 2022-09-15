using System;
using System.Text.RegularExpressions;

namespace ExtractEmails
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputString = Console.ReadLine();

            string regexPattern =
                @"(?<=\s|^)[A-Za-z0-9]+((\.|_|-)?[A-Za-z0-9]+)*@[A-Za-z]+((-|\.)?[A-za-z]+)*\.[A-Za-z]+";

            MatchCollection validEmails = Regex.Matches(inputString, regexPattern);

            foreach (Match email in validEmails)
            {
                Console.WriteLine($"{email}");
            }
        }
    }
}
