using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace NetherRealms
{
    class Program
    {
        static void Main(string[] args)
        {
            string demonName = Console.ReadLine();
            string regexInput = @"[,\s]+";
            string[] demonNames = Regex.Split(demonName, regexInput);

            //string[] demonName = Console.ReadLine().Split(new string[] { " ", ", " }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            SortedDictionary<string, Dictionary<int, double>> demonsByHealthAndDmg =
                new SortedDictionary<string, Dictionary<int, double>>();

            string regexPatternHealthDmg = @"(?<demonHealth>[A-Za-z]{1,})(?<demonDmg>[-+]?[0-9]*\.?[0-9]+([eE][-+]?[0-9]+)?)?";

            for (int i = 0; i < demonNames.Length; i++)
            {
                MatchCollection healthAndDmg = Regex.Matches(demonNames[i], regexPatternHealthDmg);

                string lettersInName = string.Empty;
                string separateDmgDigits = String.Empty;

                foreach (Match letterOrDigit in healthAndDmg)
                {
                    foreach (char letter in letterOrDigit.Groups["demonHealth"].Value)
                    {
                        lettersInName += letter;
                    }

                    foreach (char digit in letterOrDigit.Groups["demonDmg"].Value)
                    {
                        separateDmgDigits += digit;

                    }
                    separateDmgDigits += '+';
                }

                int demonHealth = 0;

                for (int j = 0; j < lettersInName.Length; j++)
                {
                    demonHealth += (int)lettersInName[j];
                }

                separateDmgDigits = separateDmgDigits.TrimEnd('+');
                object dmg = null;

                double d = Convert.ToDouble(string.IsNullOrEmpty(separateDmgDigits) ? 0.0 : dmg = new DataTable().Compute(separateDmgDigits, null));

                double damage = d;

                if (damage != 0)
                {
                    string regexForSymbols = @"(?<multiplier>[*]*)(?<divider>[\/]*)";

                    MatchCollection dmgChanges = Regex.Matches(demonNames[i], regexForSymbols);

                    foreach (Match multOrDiv in dmgChanges)
                    {
                        foreach (char sign in multOrDiv.Groups["multiplier"].Value)
                        {
                            if (sign == '*')
                            {
                                damage *= 2;
                            }
                        }

                        foreach (char sign in multOrDiv.Groups["divider"].Value)
                        {
                            if (sign == '/')
                            {
                                damage /= 2;
                            }
                        }
                    }
                }

                demonsByHealthAndDmg.Add(demonNames[i], new Dictionary<int, double>());
                demonsByHealthAndDmg[demonNames[i]].Add(demonHealth, damage);
            }

            foreach (var demon in demonsByHealthAndDmg)
            {
                Console.Write($"{demon.Key} - ");
                Console.Write(string.Join("", demon.Value.Select(d => $"{d.Key} health, {d.Value:f2} damage")));

                Console.WriteLine();
            }
        }
    }
}
