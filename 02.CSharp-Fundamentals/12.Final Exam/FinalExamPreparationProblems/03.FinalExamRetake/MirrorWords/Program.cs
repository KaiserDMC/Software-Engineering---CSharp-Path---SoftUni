using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace MirrorWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputOfWords = Console.ReadLine();

            string regexPattern =
                @"(?<surround>[@#])(?<word>[A-Za-z]{3,})\k<surround>{2}(?<word2>[A-Za-z]{3,})\k<surround>";

            Dictionary<string, string> wordAndReverse = new Dictionary<string, string>();

            MatchCollection wordMatches = Regex.Matches(inputOfWords, regexPattern);

            foreach (Match word in wordMatches)
            {
                string firstWord = word.Groups["word"].Value;
                string secondWord = word.Groups["word2"].Value;

                if (firstWord.Length == secondWord.Length)
                {
                    char[] firstWordChars = firstWord.ToCharArray();
                    char[] secondWordChars = secondWord.ToCharArray();

                    Array.Reverse(firstWordChars);
                    bool isMirror = false;

                    string firstReversed = string.Join("", firstWordChars.ToArray());

                    if (firstReversed == secondWord)
                    {
                        isMirror = true;
                    }

                    //for (int i = 0; i < secondWordChars.Length; i++)
                    //{
                    //    if (firstWordChars[i] == secondWordChars[i])
                    //    {
                    //        isMirror = true;
                    //    }
                    //    else
                    //    {
                    //        isMirror = false;
                    //        break;
                    //    }
                    //}

                    if (isMirror)
                    {
                        wordAndReverse.Add(firstWord, secondWord);
                    }
                }
            }

            if (wordMatches.Count == 0)
            {
                Console.WriteLine($"No word pairs found!");
            }
            else
            {
                Console.WriteLine($"{wordMatches.Count} word pairs found!");
            }

            if (wordAndReverse.Count == 0)
            {
                Console.WriteLine($"No mirror words!");
            }
            else
            {
                Console.WriteLine($"The mirror words are:");
                Console.WriteLine(string.Join(", ", wordAndReverse.Select(x => $"{x.Key} <=> {x.Value}")));
            }
        }
    }
}
