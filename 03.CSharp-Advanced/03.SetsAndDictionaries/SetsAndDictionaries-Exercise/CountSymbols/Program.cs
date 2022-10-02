using System;
using System.Collections.Generic;

namespace CountSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<char, int> characterByCount = new SortedDictionary<char, int>();

            string input = Console.ReadLine();

            for (int i = 0; i < input.Length; i++)
            {
                char currentChar = input[i];

                if (!characterByCount.ContainsKey(currentChar))
                {
                    characterByCount.Add(currentChar, 0);
                }

                characterByCount[currentChar]++;
            }

            foreach (var character in characterByCount)
            {
                Console.WriteLine($"{character.Key}: {character.Value} time/s");
            }
        }
    }
}
