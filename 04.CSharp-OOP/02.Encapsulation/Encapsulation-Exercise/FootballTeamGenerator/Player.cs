using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeamGenerator
{
    public class Player
    {
        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Name = name;
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
        }

        public int Shooting
        {
            get { return shooting; }
            set
            {
                if (ValidateStats("Shooting", value))
                {
                    shooting = value;
                }
            }
        }
        public int Passing
        {
            get { return passing; }
            set
            {
                if (ValidateStats("Passing", value))
                {
                    passing = value;
                }
            }
        }
        public int Dribble
        {
            get { return dribble; }
            set
            {
                if (ValidateStats("Dribble", value))
                {
                    dribble = value;
                }
            }
        }
        public int Sprint
        {
            get { return sprint; }
            set
            {
                if (ValidateStats("Sprint", value))
                {
                    sprint = value;
                }
            }
        }
        public int Endurance
        {
            get { return endurance; }
            set
            {
                if (ValidateStats("Endurance", value))
                {
                    endurance = value;
                }
            }
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

        public int PlayerSkill
        {
            get
            {
                int averagePlayerSkill = (int)Math.Round((double)(Endurance + Sprint + Dribble + Passing + Shooting) / 5.0);

                return averagePlayerSkill;
            }
        }

        private bool ValidateStats(string stats, int statsValue)
        {
            bool valid = false;
            switch (stats)
            {
                case "Endurance":
                case "Sprint":
                case "Dribble":
                case "Passing":
                case "Shooting":
                    if (statsValue < 0 || statsValue > 100)
                    {
                        throw new ArgumentException($"{stats} should be between 0 and 100.");
                    }
                    else
                    {
                        valid = true;
                    }
                    break;
            }

            return valid;
        }
    }
}
