using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DestinationMapper
{
    class Program
    {
        static void Main(string[] args)
        {
            string mapLocations = Console.ReadLine();

            string regexPattern = @"(?<surround>[=\/])(?<destination>[A-Z][A-Za-z]{2,})\k<surround>";

            MatchCollection validDestinations = Regex.Matches(mapLocations, regexPattern);

            int travelPoints = 0;
            List<string> destinationList = new List<string>();

            foreach (Match destination in validDestinations)
            {
                destinationList.Add(destination.Groups["destination"].Value);
            }


            foreach (var location in destinationList)
            {
                travelPoints += location.Length;
            }

            Console.WriteLine("Destinations: " + string.Join(", ", destinationList));
            Console.WriteLine($"Travel Points: {travelPoints}");
        }
    }
}
