using System;
using System.Collections.Generic;
using System.Linq;

namespace TeamworkProjects
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfTeams = int.Parse(Console.ReadLine());

            TeamCollection teamCollection = new TeamCollection();

            for (int i = 0; i < numberOfTeams; i++)
            {
                string[] commandSplit = Console.ReadLine().Split("-").ToArray();
                string teamCreator = commandSplit[0];
                string teamName = commandSplit[1];

                if (DoesTeamExist(teamName, teamCollection.Teams))
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                }
                else if (DoesCreatorExist(teamCreator, teamCollection.Teams))
                {
                    Console.WriteLine($"{teamCreator} cannot create another team!");
                }
                else
                {
                    Console.WriteLine($"Team {teamName} has been created by {teamCreator}!");
                    Team team = new Team(teamName, teamCreator);
                    team.Users = new List<string>();
                    teamCollection.Teams.Add(team);
                }
            }

            string inputJoin = Console.ReadLine();

            while (inputJoin != "end of assignment")
            {
                string[] userToJoin = inputJoin.Split("->").ToArray();
                string userName = userToJoin[0];
                string wantedTeam = userToJoin[1];

                if (!DoesTeamExist(wantedTeam, teamCollection.Teams))
                {
                    Console.WriteLine($"Team {wantedTeam} does not exist!");
                }
                else if (IsUserInTeam(userName, teamCollection.Teams) || DoesCreatorExist(userName, teamCollection.Teams))
                {
                    Console.WriteLine($"Member {userName} cannot join team {wantedTeam}!");
                }
                else
                {
                    Team team = teamCollection.Teams.Find(team => team.TeamName == wantedTeam);

                    if (team.Creator != userName)
                    {
                        team.Users.Add(userName);
                    }
                }

                inputJoin = Console.ReadLine();
            }

            List<Team> teamsToDisband = teamCollection.Teams.Where(t => t.Users.Count < 1).ToList();
            teamsToDisband = teamsToDisband.OrderBy(t => t.TeamName).ToList();

            List<Team> orderedTeam = teamCollection.Teams.Where(t => t.Users.Count > 0).ToList();
            orderedTeam = orderedTeam.OrderByDescending(t => t.Users.Count).ThenBy(t => t.TeamName).ToList();

            foreach (Team team in orderedTeam)
            {
                Console.WriteLine($"{team.TeamName}");
                Console.WriteLine($"- {team.Creator}");

                foreach (string user in team.Users.OrderBy(x => x))
                {
                    Console.WriteLine($"-- {user}");
                }
            }

            Console.WriteLine("Teams to disband:");

            foreach (Team team in teamsToDisband)
            {
                Console.WriteLine($"{team.TeamName}");
            }
        }

        static bool DoesTeamExist(string teamName, List<Team> teams)
        {
            bool teamExists = false;

            foreach (Team team in teams)
            {
                if (team.TeamName == teamName)
                {
                    teamExists = true;
                }
            }

            return teamExists;
        }

        static bool DoesCreatorExist(string creator, List<Team> teams)
        {
            bool creatorExists = false;

            foreach (Team team in teams)
            {
                if (team.Creator == creator)
                {
                    creatorExists = true;
                }
            }

            return creatorExists;
        }

        static bool IsUserInTeam(string userName, List<Team> teams)
        {
            bool userJoined = false;

            foreach (Team team in teams)
            {
                if (team.Users != null && team.Users.Contains(userName))
                {
                    userJoined = true;
                }
            }

            return userJoined;
        }

        class Team
        {
            public Team(string teamName, string creator)
            {
                this.TeamName = teamName;
                this.Creator = creator;
            }

            public string TeamName { get; set; }
            public string Creator { get; set; }
            public List<string> Users { get; set; }
        }

        class TeamCollection
        {
            public TeamCollection()
            {
                this.Teams = new List<Team>();
            }

            public List<Team> Teams { get; set; }
        }
    }
}
