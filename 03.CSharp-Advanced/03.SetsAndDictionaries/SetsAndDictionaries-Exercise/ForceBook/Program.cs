using System;
using System.Collections.Generic;
using System.Linq;

namespace ForceBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> usersByForce = new Dictionary<string, List<string>>();

            string input = Console.ReadLine();

            while (input != "Lumpawaroo")
            {
                bool splitCheck = input.Contains(" | ");

                string[] tokens = input.Split(new string[] { " | ", " -> " }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                string forceSide = splitCheck ? tokens[0] : tokens[1];
                string forceUser = splitCheck ? tokens[1] : tokens[0];

                if (splitCheck)
                {
                    if (!usersByForce.Any(x => x.Value.Contains(forceUser)))
                    {
                        if (!usersByForce.ContainsKey(forceSide))
                        {
                            usersByForce.Add(forceSide, new List<string>());
                        }

                        usersByForce[forceSide].Add(forceUser);
                    }
                }
                else
                {
                    string oldForce = String.Empty;

                    if (usersByForce.Any(x => x.Value.Contains(forceUser)))
                    {
                        oldForce = usersByForce.Where(x => x.Value.Contains(forceUser)).First().Key;

                        usersByForce[oldForce].Remove(forceUser);
                    }

                    if (!usersByForce.Any(x => x.Value.Contains(forceUser)))
                    {
                        if (!usersByForce.ContainsKey(forceSide))
                        {
                            usersByForce.Add(forceSide, new List<string>());
                        }

                        usersByForce[forceSide].Add(forceUser);
                    }

                    Console.WriteLine($"{forceUser} joins the {forceSide} side!");
                }

                input = Console.ReadLine();
            }

            foreach (var user in usersByForce.OrderByDescending(u => u.Value.Count).ThenBy(u => u.Key))
            {
                if (user.Value.Count > 0)
                {
                    Console.WriteLine($"Side: {user.Key}, Members: {user.Value.Count}");

                    user.Value.Sort();

                    //Console.WriteLine("! " + string.Join("\n! ", user.Value));

                    foreach (var person in user.Value)
                    {
                        Console.WriteLine($"! {person}");
                    }
                }
            }
        }
    }
}
