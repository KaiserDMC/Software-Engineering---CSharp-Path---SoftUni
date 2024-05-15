using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text.RegularExpressions;

namespace EmojiDetector
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputString = Console.ReadLine();

            string regexPattern = @"(?<surround>[:\*])\k<surround>(?<emoji>[A-Z][a-z]{2,})\k<surround>\k<surround>";

            BigInteger coolTreshold = BigInteger.One;

            for (int i = 0; i < inputString.Length; i++)
            {
                char currentChar = inputString[i];

                if (char.IsDigit(currentChar))
                {
                    coolTreshold *= int.Parse(currentChar.ToString());
                }
            }

            MatchCollection emojiCollection = Regex.Matches(inputString, regexPattern);

            List<string> coolEmojiList = new List<string>();

            foreach (Match emoji in emojiCollection)
            {
                int emojiNumber = 0;

                string emojiAsString = emoji.Groups["emoji"].Value;

                for (int i = 0; i < emojiAsString.Length; i++)
                {
                    if (char.IsLetter(emojiAsString[i]))
                    {
                        emojiNumber += emojiAsString[i];
                    }
                }

                if (emojiNumber >= coolTreshold)
                {
                    coolEmojiList.Add(emoji.ToString());
                }
            }

            Console.WriteLine($"Cool threshold: {coolTreshold}");
            Console.WriteLine($"{emojiCollection.Count} emojis found in the text. The cool ones are:");
            Console.Write(string.Join(Environment.NewLine, coolEmojiList));
        }
    }
}
