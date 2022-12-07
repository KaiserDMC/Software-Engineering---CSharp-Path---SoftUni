using System;
using System.Collections.Generic;
using System.Text;
using Formula1.Models.Contracts;
using Formula1.Utilities;

namespace Formula1.Models.Races
{
    public class Race : IRace
    {
        private string raceName;
        private int numberOfLaps;
        private List<IPilot> pilots;

        public Race(string raceName, int numberOfLaps)
        {
            this.RaceName = raceName;
            this.NumberOfLaps = numberOfLaps;
            this.TookPlace = false;
        }


        public string RaceName
        {
            get => raceName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidRaceName, value);
                }

                raceName = value;
            }
        }

        public int NumberOfLaps
        {
            get => numberOfLaps;
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidLapNumbers, value.ToString());
                }

                numberOfLaps = value;
            }
        }

        public bool TookPlace { get; set; }
        public ICollection<IPilot> Pilots => this.pilots.AsReadOnly();

        public void AddPilot(IPilot pilot)
        {
            this.pilots.Add(pilot);
        }

        public string RaceInfo()
        {
            string tookPlace = TookPlace ? "Yes" : "No";

            StringBuilder text = new StringBuilder();

            text.AppendLine($"The {RaceName} race has:");
            text.AppendLine($"Participants: {Pilots.Count}");
            text.AppendLine($"Number of laps: {NumberOfLaps}");
            text.Append($"Took place: {tookPlace}");

            return text.ToString().Trim();
        }
    }
}