using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace StarEnigma
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfMessages = int.Parse(Console.ReadLine());

            List<string> attackedPlanets = new List<string>();
            List<string> destroyedPlanets = new List<string>();

            string regexForKeyCode = @"(?<keycode>[STARstar])";

            for (int i = 0; i < numberOfMessages; i++)
            {
                string encryptedMessage = Console.ReadLine();

                MatchCollection individualLetters = Regex.Matches(encryptedMessage, regexForKeyCode);

                int keyCode = individualLetters.Count;

                char[] decryptedMessage = encryptedMessage.ToCharArray();

                for (int j = 0; j < decryptedMessage.Length; j++)
                {
                    int currentChar = decryptedMessage[j];
                    currentChar -= keyCode;
                    decryptedMessage[j] = (char)currentChar;
                }

                string deryptMessage = string.Join("", decryptedMessage);

                string regexPattern =
                    @"@(?<planet>[A-Za-z]+)[^@\-!:>]*:(?<population>[\d]+)[^@\-!:>]*!(?<attackType>[AD])[^@\-!:>]*![^@\-!:>]*-[^@\-!:>]*>(?<soldierCount>[\d]+)";

                Match validAttack = Regex.Match(deryptMessage, regexPattern);

                if (validAttack.Success)
                {
                    string planetName = validAttack.Groups["planet"].Value;
                    int population = int.Parse(validAttack.Groups["population"].Value);
                    char attackType = char.Parse(validAttack.Groups["attackType"].Value);
                    int soldierCount = int.Parse(validAttack.Groups["soldierCount"].Value);

                    if (attackType == 'A')
                    {
                        attackedPlanets.Add(planetName);
                    }
                    else if (attackType == 'D')
                    {
                        destroyedPlanets.Add(planetName);
                    }
                }
            }

            Console.WriteLine($"Attacked planets: {attackedPlanets.Count}");
            foreach (string planet in attackedPlanets.OrderBy(p => p))
            {
                Console.WriteLine($"-> {planet}");
            }

            Console.WriteLine($"Destroyed planets: {destroyedPlanets.Count}");
            foreach (string planet in destroyedPlanets.OrderBy(p => p))
            {
                Console.WriteLine($"-> {planet}");
            }
        }
    }
}
