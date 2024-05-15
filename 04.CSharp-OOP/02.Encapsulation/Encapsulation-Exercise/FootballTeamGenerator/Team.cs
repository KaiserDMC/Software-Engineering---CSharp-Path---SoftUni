using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballTeamGenerator
{
    public class Team
    {
        private string name;
        private List<Player> players;

        public Team(string name)
        {
            this.Name = name;
            players = new List<Player>();
        }
        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"A name should not be empty.");
                }
                name = value;
            }
        }

        public int TeamRating
        {
            get
            {
                int averageTeamRating = 0;

                if (players.Any())
                {
                    foreach (var player in players)
                    {
                        averageTeamRating += player.PlayerSkill;
                    }
                }

                return averageTeamRating;
            }
        }

        public void AddPlayer(Player playerToAdd)
        {
            players.Add(playerToAdd);
        }

        public void RemovePlayer(string playerToRemove)
        {
            if (this.players.Any(p => p.Name == playerToRemove))
            {
                this.players.Remove(this.players.Find(p => p.Name == playerToRemove));
            }
            else
            {
                throw new ArgumentException($"Player {playerToRemove} is not in {this.Name} team.");
            }
        }
    }
}
