using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerArchitecture
{
    public class CPU
    {
        private string brand;
        private int cores;
        private double frequency;

        public CPU(string brand, int cores, double frequency)
        {
            this.Brand = brand;
            this.Cores = cores;
            this.Frequency = frequency;
        }

        public string Brand
        {
            get { return brand; }
            set { brand = value; }
        }
        
        public int Cores
        {
            get { return cores; }
            set { cores = value; }
        }
        
        public double Frequency
        {
            get { return frequency; }
            set { frequency = value; }
        }

        public override string ToString()
        {
            StringBuilder text = new StringBuilder();

            text.AppendLine($"{this.Brand} CPU:");
            text.AppendLine($"Cores: {this.Cores}");
            text.Append($"Frequency: {this.Frequency:f1} GHz");
            
            return text.ToString().TrimEnd();
        }
    }
}