using System;
using System.Collections.Generic;
using System.Linq;

namespace SetCover
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var universe = Console.ReadLine().Split(", ").Select(int.Parse).ToList();
            int numberOfSets = int.Parse(Console.ReadLine());
            List<int[]> sets = new List<int[]>();
            List<int[]> selectedSets = new List<int[]>();

            for (int i = 0; i < numberOfSets; i++)
            {
                var currentSet = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
                sets.Add(currentSet);
            }

            while (universe.Count > 0)
            {
                var currentSet = sets.OrderByDescending(s => s.Count(e => universe.Contains(e))).FirstOrDefault();

                foreach (var number in currentSet)
                {
                    universe.Remove(number);
                }

                sets.Remove(currentSet);
                selectedSets.Add(currentSet);
            }

            Console.WriteLine($"Sets to take ({selectedSets.Count}):");
            
            foreach (var set in selectedSets)
            {
                Console.WriteLine($"{ string.Join(", ", set) }");
            }
        }
    }
}