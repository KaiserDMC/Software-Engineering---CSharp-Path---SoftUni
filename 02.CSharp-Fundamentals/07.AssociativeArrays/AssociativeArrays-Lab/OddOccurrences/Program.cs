using System;
using System.Collections.Generic;
using System.Linq;

namespace OddOccurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> wordSequenceByCountDictionary = new Dictionary<string, int>();

            string[] wordSequence = Console.ReadLine().Split(" ").Select(w => w.ToLower()).ToArray();

            foreach (string word in wordSequence)
            {
                if (!wordSequenceByCountDictionary.ContainsKey(word))
                {
                    wordSequenceByCountDictionary.Add(word, 0);
                }

                wordSequenceByCountDictionary[word]++;
            }

            List<KeyValuePair<string, int>> wordSequenceToPrint = wordSequenceByCountDictionary.Where(x => x.Value % 2 != 0).ToList();

            foreach (KeyValuePair<string, int> VARIABLE in wordSequenceToPrint)
            {
                Console.Write($"{VARIABLE.Key} ");
            }
        }
    }
}
