using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.IO.Interfaces;

namespace Vehicles.Models.Interfaces
{
    public class Vehicle
    {
        private double fuelQuantity;
        private double fuelConsumptionPerKM;

        public Vehicle(double fuelQuantity, double fuelConsumption)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public double FuelConsumption
        {
            get { return fuelConsumptionPerKM; }
            set { fuelConsumptionPerKM = value; }
        }
        public double FuelQuantity
        {
            get { return fuelQuantity; }
            set { fuelQuantity = value; }
        }

        public virtual void Drive(double distance)
        {
            double tempFuel = this.FuelQuantity - distance * this.FuelConsumption;

            if (tempFuel >= 0)
            {
                this.FuelQuantity = tempFuel;

                Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
            }
            else
            {
                Console.WriteLine($"{this.GetType().Name} needs refueling");
            }
        }

        public virtual void Refuel(double amountFuel)
        {
            FuelQuantity += amountFuel;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {FuelQuantity:f2}";
        }
    }
}
