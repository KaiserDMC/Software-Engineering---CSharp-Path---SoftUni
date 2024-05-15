using System;
using System.Text;

namespace DefiningClasses
{
    public class Engine
    {
        private string model;
        private int power;
        private int displacement;
        private string efficiency;

        public Engine()
        {
            this.Model = "n/a";
            this.Power = 0;
            this.Displacement = int.MinValue;
            this.Efficiency = "n/a";
        }

        public Engine(string model, int power) : this()
        {
            this.Model = model;
            this.Power = power;
        }

        public Engine(string model, int power, int displacement) : this(model, power)
        {
            this.Displacement = displacement;
        }

        public Engine(string model, int power, int displacement, string efficiency) : this(model, power, displacement)
        {
            this.Efficiency = efficiency;
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public int Power
        {
            get { return power; }
            set { power = value; }
        }

        public int Displacement
        {
            get { return displacement; }
            set { displacement = value; }
        }

        public string Efficiency
        {
            get { return efficiency; }
            set { efficiency = value; }
        }

        public override string ToString()
        {
            StringBuilder text = new StringBuilder();

            string displacement = this.displacement == int.MinValue ? "n/a" : this.displacement.ToString();

            text.AppendLine($"  {this.Model}:");
            text.AppendLine($"    Power: {this.Power}");
            text.AppendLine($"    Displacement: {displacement}");
            text.AppendLine($"    Efficiency: {this.Efficiency}");

            return text.ToString();
        }
    }
}