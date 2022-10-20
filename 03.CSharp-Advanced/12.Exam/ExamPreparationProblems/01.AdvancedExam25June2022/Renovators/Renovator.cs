using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renovators
{
    public class Renovator
    {
        private string name;
        private string type;
        private double rate;
        private int days;
        private bool hired;

        public Renovator(string name, string type, double rate, int days)
        {
            this.Name = name;
            this.Type = type;
            this.Rate = rate;
            this.Days = days;
            this.Hired = false;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        public double Rate
        {
            get { return rate; }
            set { rate = value; }
        }

        public int Days
        {
            get { return days; }
            set { days = value; }
        }

        public bool Hired
        {
            get { return hired; }
            set { hired = value; }
        }

        public override string ToString()
        {
            StringBuilder text = new StringBuilder();

            text.AppendLine($"-Renovator: {this.Name}");
            text.AppendLine($"--Specialty: {this.Type}");
            text.Append($"--Rate per day: {this.Rate} BGN");

            return text.ToString();
        }
    }
}