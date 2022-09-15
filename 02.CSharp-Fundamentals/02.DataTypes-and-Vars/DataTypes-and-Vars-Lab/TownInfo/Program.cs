using System;

namespace TownInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            string city = Console.ReadLine();
            long population = long.Parse(Console.ReadLine());
            int area = int.Parse(Console.ReadLine());

            Console.WriteLine($"Town {city} has population of {population} and area {area} square km.");
        }
    }
}
