using System;
using System.Text.RegularExpressions;

namespace MatchPhoneNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputToMatch = Console.ReadLine();

            string regexPattern = @"\+359(?<sep>[ \-])[2]{1}\k<sep>[0-9]{3}\k<sep>[0-9]{4}\b";

            MatchCollection matchedPhones = Regex.Matches(inputToMatch, regexPattern);

            Console.WriteLine(string.Join(", ", matchedPhones));
        }
    }
}
