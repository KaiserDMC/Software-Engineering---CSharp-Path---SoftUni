using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;

namespace Basketball
{
    public class Team
    {
        private string name;
        private int openPositions;
        private char group;
        private List<Player> players;

        public Team(string name, int openPositions, char group)
        {
            this.Name = name;
            this.OpenPositions = openPositions;
            this.Group = group;
            this.Players = new List<Player>();
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int OpenPositions
        {
            get { return openPositions; }
            set { openPositions = value; }
        }

        public char Group
        {
            get { return group; }
            set { group = value; }
        }

        public List<Player> Players
        {
            get { return players; }
            set { players = value; }
        }

        public int Count
        {
            get { return this.Players.Count; }
        }

        public string AddPlayer(Player player)
        {
            if (string.IsNullOrEmpty(player.Name) || string.IsNullOrEmpty(player.Position))
            {
                return $"Invalid player's information.";
            }

            if (this.OpenPositions == 0)
            {
                return $"There are no more open positions.";
            }

            if (player.Rating < 80)
            {
                return $"Invalid player's rating.";
            }

            this.Players.Add(player);
            this.OpenPositions--;

            return $"Successfully added {player.Name} to the team. Remaining open positions: {this.OpenPositions}.";
        }

        public bool RemovePlayer(string name)
        {
            if (Players.Any(p => p.Name == name))
            {
                Player playerToRemove = Players.Find(p => p.Name == name);

                Players.Remove(playerToRemove);
                this.OpenPositions++;
                return true;
            }
            else
            {
                return false;
            }
        }

        public int RemovePlayerByPosition(string position)
        {
            int counter = 0;

            if (this.Players.Any(p => p.Position == position))
            {
                for (int i = 0; i < Count; i++)
                {
                    Player currentPlayer = Players[i];

                    if (currentPlayer.Position == position)
                    {
                        this.Players.Remove(currentPlayer);
                        counter++;
                    }
                }
            }

            this.OpenPositions += counter;

            return counter;
        }

        public Player RetirePlayer(string name)
        {
            if (this.Players.Any(p => p.Name == name))
            {
                Player playerToRetire = this.Players.Find(p => p.Name == name);

                if (playerToRetire != null)
                {
                    playerToRetire.Retired = true;
                    return playerToRetire;
                }
            }

            return null;
        }

        public List<Player> AwardPlayers(int games)
        {
            List<Player> tempList = new List<Player>();
            tempList = Players.Where(p => p.Games >= games).ToList();

            return tempList;
        }

        public string Report()
        {
            StringBuilder text = new StringBuilder();

            text.AppendLine($"Active players competing for Team {this.Name} from Group {this.Group}:");

            foreach (var player in Players.FindAll(p => p.Retired == false))
            {
                text.AppendLine(player.ToString());
            }

            return text.ToString().TrimEnd();
        }
    }
}