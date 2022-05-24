using System;

namespace FootballLeague
{
    class Program
    {
        static void Main(string[] args)
        {
            int capacityStadium = int.Parse(Console.ReadLine());
            int totalFans = int.Parse(Console.ReadLine());

            int teamOne = 0;
            int teamTwo = 0;
            int sectorA = 0;
            int sectorB = 0;
            int sectorV = 0;
            int sectorG = 0;

            for (int i = 0; i < totalFans; i++)
            {
                char sector = char.Parse(Console.ReadLine());

                if (sector == 'A')
                {
                    sectorA++;
                    teamOne++;
                }
                else if (sector == 'B')
                {
                    sectorB++;
                    teamOne++;
                }
                else if (sector == 'V')
                {
                    sectorV++;
                    teamTwo++;
                }
                else if (sector == 'G')
                {
                    sectorG++;
                    teamTwo++;
                }
            }

            double avgFansSectorA = (double)sectorA / totalFans * 100;
            double avgFansSectorB = (double)sectorB / totalFans * 100;
            double avgFansSectorV = (double)sectorV / totalFans * 100;
            double avgFansSectorG = (double)sectorG / totalFans * 100;
            double avgFansPercentage = (double)totalFans / capacityStadium * 100;

            Console.WriteLine($"{avgFansSectorA:f2}%");
            Console.WriteLine($"{avgFansSectorB:f2}%");
            Console.WriteLine($"{avgFansSectorV:f2}%");
            Console.WriteLine($"{avgFansSectorG:f2}%");
            Console.WriteLine($"{avgFansPercentage:f2}%");
        }
    }
}
