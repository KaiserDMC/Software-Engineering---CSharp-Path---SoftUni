using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace LettersChangeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputSequence = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            double sum = 0;
            double totalSum = 0;

            List<char> englishAlphabetChars = new List<char>
            {
                'A', 'B', 'C','D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'
            };

            foreach (string sequence in inputSequence)
            {
                char firstLetter = sequence[0];
                char lastLetter = sequence[sequence.Length - 1];
                double currentNumber = double.Parse(sequence.Substring(1, sequence.Length - 2));

                if (char.IsUpper(firstLetter))
                {
                    double indexOfLetter = englishAlphabetChars.IndexOf(firstLetter);

                    sum = currentNumber / (indexOfLetter + 1);
                }
                else
                {
                    double indexOfLetter = englishAlphabetChars.IndexOf(char.ToUpper(firstLetter));

                    sum = currentNumber * (indexOfLetter + 1);
                }

                if (char.IsUpper(lastLetter))
                {
                    double indexOfLetter = englishAlphabetChars.IndexOf(lastLetter);

                    sum -= indexOfLetter + 1;
                }
                else
                {
                    double indexOfLetter = englishAlphabetChars.IndexOf(char.ToUpper(lastLetter));

                    sum += indexOfLetter + 1;
                }


                totalSum += sum;
                sum = 0;
            }

            Console.WriteLine($"{totalSum:f2}");
        }
    }
}
