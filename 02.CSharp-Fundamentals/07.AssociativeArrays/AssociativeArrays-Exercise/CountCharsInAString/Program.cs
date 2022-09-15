using System;
using System.Collections.Generic;
using System.Linq;

namespace CountCharsInAString
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<char, int> charactersInWordsByCountDictionary = new Dictionary<char, int>();

            string[] inputWords = Console.ReadLine().Split(" ").ToArray();

            foreach (string word in inputWords)
            {
                char[] individualChars = word.ToCharArray();

                for (int i = 0; i < individualChars.Length; i++)
                {
                    if (!charactersInWordsByCountDictionary.ContainsKey(individualChars[i]))
                    {
                        charactersInWordsByCountDictionary.Add(individualChars[i], 0);
                    }

                    charactersInWordsByCountDictionary[individualChars[i]]++;
                }
            }

            foreach (KeyValuePair<char, int> character in charactersInWordsByCountDictionary)
            {
                Console.WriteLine($"{character.Key} -> {character.Value}");
            }
        }
    }
}
