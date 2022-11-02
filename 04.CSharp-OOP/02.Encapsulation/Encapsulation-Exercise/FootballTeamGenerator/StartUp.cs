using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();


            while (true)
            {
                string[] input = Console.ReadLine().Split(";").ToArray();

                if (input[0] == "END")
                {
                    break;
                }

                try
                {

                    string command = input[0];

                    switch (command)
                    {
                        case "Team":
                            teams.Add(new Team(input[1]));

                            break;
                        case "Add":
                            string teamName = input[1];
                            string playerName = input[2];

                            if (ValidTeam(teams, teamName))
                            {
                                Team currentTeam = teams.Find(t => t.Name == teamName);
                                Player currentPlayer = new Player(playerName, int.Parse(input[3]),
                                    int.Parse(input[4]), int.Parse(input[5]), int.Parse(input[6]), int.Parse(input[7]));

                                currentTeam.AddPlayer(currentPlayer);
                            }
                            else
                            {
                                throw new ArgumentException($"Team {teamName} does not exist.");
                            }

                            break;
                        case "Remove":
                            teamName = input[1];
                            playerName = input[2];

                            if (ValidTeam(teams, teamName))
                            {
                                Team removeFromTeam = teams.Find(t => t.Name == teamName);
                                removeFromTeam.RemovePlayer(playerName);
                            }
                            else
                            {
                                throw new ArgumentException($"Team {teamName} does not exist.");
                            }

                            break;
                        case "Rating":
                            teamName = input[1];

                            if (ValidTeam(teams, teamName))
                            {
                                Team ratingTeam = teams.Find(t => t.Name == teamName);
                                Console.WriteLine($"{ratingTeam.Name} - {ratingTeam.TeamRating}");
                            }
                            else
                            {
                                throw new ArgumentException($"Team {teamName} does not exist.");
                            }

                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public static bool ValidTeam(List<Team> teams, string teamName)
        {
            bool valid = false;
            if (teams.Any(t => t.Name == teamName))
            {
                valid = true;
            }

            return valid;
        }
    }
}
