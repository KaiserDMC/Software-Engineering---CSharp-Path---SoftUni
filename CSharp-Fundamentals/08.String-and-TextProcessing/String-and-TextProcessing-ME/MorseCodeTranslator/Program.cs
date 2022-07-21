using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MorseCodeTranslator
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<char, string> morseCodeAlphabet = new Dictionary<char, string>
            {
                {'A', ".-"},
                {'B', "-..."},
                {'C', "-.-."},
                {'D', "-.."},
                {'E', "." },
                {'F', "..-." },
                {'G', "--." },
                {'H', "...." },
                {'I', ".." },
                {'J', ".---" },
                {'K', "-.-" },
                {'L', ".-.." },
                {'M', "--" },
                {'N', "-." },
                {'O', "---" },
                {'P', ".--." },
                {'Q', "--.-" },
                {'R', ".-." },
                {'S', "..." },
                {'T', "-" },
                {'U', "..-" },
                {'V', "...-" },
                {'W', ".--" },
                {'X', "-..-" },
                {'Y', "-.--" },
                {'Z', "--.." }
            };

            string[] morseCodeInput = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries).ToArray();

            StringBuilder decypheredMessage = new StringBuilder();

            for (int i = 0; i < morseCodeInput.Length; i++)
            {
                string[] currentMorseLetter = morseCodeInput[i].Split();

                foreach (string letter in currentMorseLetter)
                {
                    if (morseCodeAlphabet.ContainsValue(letter))
                    {
                        decypheredMessage.Append(morseCodeAlphabet.FirstOrDefault(x => x.Value == letter).Key);
                    }
                }

                decypheredMessage.Append(' ');
            }

            Console.WriteLine(decypheredMessage.ToString());
        }
    }
}
