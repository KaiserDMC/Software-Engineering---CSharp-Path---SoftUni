using System;
using System.Collections.Generic;
using System.Linq;

namespace Judge
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> usernameByContest =
                new Dictionary<string, Dictionary<string, int>>();

            Dictionary<string, Dictionary<string, int>> contestsByUsername =
                new Dictionary<string, Dictionary<string, int>>();

            while (true)
            {
                string[] usernameInputs = Console.ReadLine().Split(" -> ").ToArray();

                if (usernameInputs[0] == "no more time")
                {
                    break;
                }

                string userName = usernameInputs[0];
                string contestName = usernameInputs[1];
                int userPoints = int.Parse(usernameInputs[2]);

                if (!contestsByUsername.ContainsKey(contestName))
                {
                    contestsByUsername.Add(contestName, new Dictionary<string, int>());
                }

                if (contestsByUsername.ContainsKey(contestName) && !contestsByUsername[contestName].ContainsKey(userName))
                {
                    contestsByUsername[contestName].Add(userName, userPoints);
                }

                if (!usernameByContest.ContainsKey(userName))
                {
                    usernameByContest.Add(userName, new Dictionary<string, int>());
                    usernameByContest[userName].Add(contestName, userPoints);
                }

                if (usernameByContest.ContainsKey(userName) &&
                    !usernameByContest[userName].ContainsKey(contestName))
                {
                    usernameByContest[userName].Add(contestName, userPoints);
                }

                if (contestsByUsername[contestName][userName] < userPoints)
                {
                    usernameByContest[userName][contestName] = userPoints;
                    contestsByUsername[contestName][userName] = userPoints;
                }
            }

            foreach (var contest in contestsByUsername)
            {
                int numberOfContests = 1;
                Console.WriteLine($"{contest.Key}: {contest.Value.Count} participants");
                Console.WriteLine(string.Join(Environment.NewLine, contest.Value.OrderByDescending(x => x.Value).ThenBy(y => y.Key).Select(y => $"{numberOfContests++}. {y.Key} <::> {y.Value}")));
            }

            Console.WriteLine($"Individual standings:");

            int numberOfParticipants = 1;
            Console.WriteLine(string.Join(Environment.NewLine, usernameByContest.OrderByDescending(x => x.Value.Values.Sum()).ThenBy(y => y.Key).Select(y => $"{numberOfParticipants++}. {y.Key} -> {y.Value.Values.Sum()}")));
        }
    }
}
