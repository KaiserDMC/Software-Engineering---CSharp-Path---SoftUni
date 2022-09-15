using System;
using System.Collections.Generic;
using System.Linq;

namespace WordFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] wordsToBeFiltered = Console.ReadLine().Split(" ").ToArray();

            List<string> filteredWordsList = wordsToBeFiltered.Where(w => w.Length % 2 == 0).ToList();

            foreach (string word in filteredWordsList)
            {
                Console.WriteLine($"{word}");
            }
        }
    }
}
