using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUniExamResults
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> usersLangPoints =
                new Dictionary<string, Dictionary<string, int>>();

            Dictionary<string, int> languageSubmissions = new Dictionary<string, int>();

            List<string> bannedUsersList = new List<string>();

            string input = Console.ReadLine();

            while (input != "exam finished")
            {
                string[] tokens = input.Split("-").ToArray();

                string username = tokens[0];
                string language = tokens[1];

                if (language == "banned")
                {
                    bannedUsersList.Add(username);
                    input = Console.ReadLine();
                    continue;
                }

                int points = int.Parse(tokens[2]);

                if (!usersLangPoints.ContainsKey(username))
                {
                    usersLangPoints.Add(username, new Dictionary<string, int>());
                }

                if (!usersLangPoints[username].ContainsKey(language))
                {
                    usersLangPoints[username].Add(language, points);
                }
                else
                {
                    usersLangPoints[username][language] = Math.Max(points, usersLangPoints[username][language]);
                }

                if (!languageSubmissions.ContainsKey(language))
                {
                    languageSubmissions.Add(language, 0);
                }

                languageSubmissions[language]++;

                input = Console.ReadLine();
            }

            Console.WriteLine($"Results:");

            foreach (var users in usersLangPoints.OrderByDescending(u => u.Value.FirstOrDefault().Value).ThenBy(x => x.Key))
            {
                if (!bannedUsersList.Contains(users.Key))
                {
                    Console.WriteLine($"{users.Key} | {string.Join("", users.Value.Select(u => $"{u.Value}"))}");
                }
            }

            Console.WriteLine($"Submissions:");

            foreach (var lang in languageSubmissions.OrderByDescending(l => l.Value).ThenBy(l => l.Key))
            {
                Console.WriteLine($"{lang.Key} - {lang.Value}");
            }
        }
    }
}
