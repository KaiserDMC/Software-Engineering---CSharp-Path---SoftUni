using System;
using System.Text;

namespace Basketball
{
    public class Player
    {
        private string name;
        private string position;
        private double rating;
        private int games;
        private bool retired;

        public Player(string name, string position, double rating, int games)
        {
            this.Name = name;
            this.Position = position;
            this.Rating = rating;
            this.Games = games;
            this.Retired = false;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Position
        {
            get { return position; }
            set { position = value; }
        }

        public double Rating
        {
            get { return rating; }
            set { rating = value; }
        }

        public int Games
        {
            get { return games; }
            set { games = value; }
        }

        public bool Retired
        {
            get { return retired; }
            set { retired = value; }
        }

        public override string ToString()
        {
            StringBuilder text = new StringBuilder();

            text.AppendLine($"-Player: {this.Name}");
            text.AppendLine($"--Position: {this.Position}");
            text.AppendLine($"--Rating: {this.Rating}");
            text.Append($"--Games played: {this.Games}");
            
            return text.ToString().TrimEnd();
        }
    }
}