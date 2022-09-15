using System;
using System.Collections.Generic;
using System.Linq;

namespace WordSynonyms
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> wordsAndSynonymsDictionary = new Dictionary<string, List<string>>();

            int numberOfInputs = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfInputs; i++)
            {
                string word = Console.ReadLine();
                string synonym = Console.ReadLine();

                if (!wordsAndSynonymsDictionary.ContainsKey(word))
                {
                    wordsAndSynonymsDictionary.Add(word, new List<string> { synonym });
                }
                else
                {
                    wordsAndSynonymsDictionary[word].Add(synonym);
                }
            }

            foreach (KeyValuePair<string, List<string>> VARIABLE in wordsAndSynonymsDictionary)
            {
                Console.WriteLine($"{VARIABLE.Key} - {string.Join(", ", VARIABLE.Value)}");
            }
        }
    }
}
