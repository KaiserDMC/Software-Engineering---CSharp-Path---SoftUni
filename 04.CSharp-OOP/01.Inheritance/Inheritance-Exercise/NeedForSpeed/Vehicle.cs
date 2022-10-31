using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Vehicle
    {
        private int horsePower;
        private double fuel;
        private const double defaultFuelConsumption = 1.25;
        public virtual double FuelConsumption => defaultFuelConsumption;

        public Vehicle(int horsePower, double fuel)
        {
            this.Fuel = fuel;
            this.HorsePower = horsePower;
        }

        public double Fuel
        {
            get { return fuel; }
            set { fuel = value; }
        }

        public int HorsePower
        {
            get { return horsePower; }
            set { horsePower = value; }
        }

        public virtual void Drive(double kilometers)
        {
            if (Fuel >= FuelConsumption * kilometers)
            {
                Fuel -= FuelConsumption * kilometers;
            }
        }
    }
}
