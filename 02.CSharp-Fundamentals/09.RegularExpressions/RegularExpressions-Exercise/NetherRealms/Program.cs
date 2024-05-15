using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace NetherRealms
{
    class Program
    {
        static void Main(string[] args)
        {
            string demonName = Console.ReadLine();
            string regexInput = @"[,\s]+";
            string[] demonNames = Regex.Split(demonName, regexInput);

            string health = @"[^\d\+\-\*\/\.]";
            string dmg = @"([-+]?\d+(\.\d+)?)";
            string multiplier = @"[\/*]";

            List<string> demonList = new List<string>();

            for (int i = 0; i < demonNames.Length; i++)
            {
                demonList.Add(demonNames[i]);
            }

            demonList = demonList.OrderBy(x => x).ToList();

            DemonCollection demonCollection = new DemonCollection();

            for (int i = 0; i < demonList.Count; i++)
            {
                int h = 0;
                double d = 0;

                MatchCollection demonHealth = Regex.Matches(demonList[i], health);
                MatchCollection demonDmg = Regex.Matches(demonList[i], dmg);
                MatchCollection multiplierDmg = Regex.Matches(demonList[i], multiplier);

                foreach (Match item in demonHealth)
                {
                    h += (int)item.Value[0];
                }

                foreach (Match item in demonDmg)
                {
                    double a = double.Parse(item.Value);
                    d += a;
                }

                foreach (Match multOrDiv in multiplierDmg)
                {
                    if (multOrDiv.ToString().Equals("*"))
                    {
                        d *= 2;

                    }
                    else if (multOrDiv.ToString().Equals("/"))
                    {
                        d /= 2;
                    }
                }

                Demon demon = new Demon
                {
                    Health = h,
                    Damage = d
                };

                demonCollection.Demons.Add(demonList[i], demon);
            }

            foreach (var demon in demonCollection.Demons)
            {
                Console.Write($"{demon.Key} - ");
                Console.Write($"{demon.Value.Health} health, {demon.Value.Damage:f2} damage");

                Console.WriteLine();
            }
        }
    }

    class Demon
    {
        public int Health { get; set; }
        public double Damage { get; set; }
    }

    class DemonCollection
    {
        public DemonCollection()
        {
            Demons = new Dictionary<string, Demon>();
        }

        public Dictionary<string, Demon> Demons { get; set; }
    }
}
