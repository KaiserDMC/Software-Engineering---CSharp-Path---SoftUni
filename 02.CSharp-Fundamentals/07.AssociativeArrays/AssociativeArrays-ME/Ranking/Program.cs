using System;
using System.Collections.Generic;
using System.Linq;

namespace Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> passwordsByContest = new Dictionary<string, string>();
            SortedDictionary<string, Dictionary<string, int>> pointsByUser = new SortedDictionary<string, Dictionary<string, int>>();

            while (true)
            {
                string[] inputPasswords = Console.ReadLine().Split(":").ToArray();

                if (inputPasswords[0] == "end of contests")
                {
                    break;
                }

                string contestName = inputPasswords[0];
                string contestPassword = inputPasswords[1];

                passwordsByContest.Add(contestName, contestPassword);
            }

            while (true)
            {
                string[] inputUserAndPoints = Console.ReadLine().Split("=>").ToArray();

                if (inputUserAndPoints[0] == "end of submissions")
                {
                    break;
                }

                string contestName = inputUserAndPoints[0];
                string contestPassword = inputUserAndPoints[1];
                string userName = inputUserAndPoints[2];
                int userPoints = int.Parse(inputUserAndPoints[3]);

                if ((pointsByUser.ContainsKey(userName) && pointsByUser[userName].ContainsKey(contestName)))
                {
                    if (pointsByUser[userName][contestName] < userPoints)
                    {
                        pointsByUser[userName][contestName] = userPoints;
                    }
                }
                else if (pointsByUser.ContainsKey(userName))
                {
                    if (passwordsByContest[contestName] == contestPassword)
                    {
                        pointsByUser[userName].Add(contestName, userPoints);
                    }
                }
                else
                {
                    if (passwordsByContest.ContainsKey(contestName))
                    {
                        if (passwordsByContest[contestName] == contestPassword)
                        {
                            pointsByUser.Add(userName, new Dictionary<string, int>());
                            pointsByUser[userName].Add(contestName, userPoints);
                        }
                    }
                }
            }

            string bestUser = string.Empty;
            int bestSumPoints = 0;

            foreach (var userName in pointsByUser)
            {
                if (userName.Value.Values.Sum() > bestSumPoints)
                {
                    bestSumPoints = userName.Value.Values.Sum();
                    bestUser = userName.Key;
                }
            }

            Console.WriteLine($"Best candidate is {bestUser} with total {bestSumPoints} points.");
            Console.WriteLine("Ranking: ");

            foreach (var user in pointsByUser)
            {
                Console.WriteLine($"{user.Key}");
                Console.WriteLine(string.Join(Environment.NewLine, user.Value.OrderByDescending(p => p.Value).Select(y => $"#  {y.Key} -> {y.Value}")));
            }
        }
    }
}
