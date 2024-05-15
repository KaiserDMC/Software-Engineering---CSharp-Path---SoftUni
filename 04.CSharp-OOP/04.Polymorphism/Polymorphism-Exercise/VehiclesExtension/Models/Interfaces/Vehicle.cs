using System;

namespace VehiclesExtension.Models.Interfaces
{
    public class Vehicle
    {
        private double fuelQuantity;
        private double fuelConsumptionPerKM;
        private double tankCapacity;

        public Vehicle(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity)
        {
            if (fuelQuantity > tankCapacity)
            {
                this.FuelQuantity = 0;
            }
            else
            {
                this.FuelQuantity = fuelQuantity;
            }

            this.FuelConsumption = fuelConsumptionPerKm;
            this.TankCapacity = tankCapacity;
        }

        public double TankCapacity
        {
            get { return tankCapacity; }
            set
            {
                tankCapacity = value;
            }
        }

        public double FuelConsumption
        {
            get { return fuelConsumptionPerKM; }
            set { fuelConsumptionPerKM = value; }
        }
        public double FuelQuantity
        {
            get { return fuelQuantity; }
            set
            {
                fuelQuantity = value;
            }
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
            if (ValidFuelAmount(amountFuel))
            {
                if (amountFuel + FuelQuantity > TankCapacity)
                {
                    Console.WriteLine($"Cannot fit {amountFuel} fuel in the tank");
                }
                else
                {
                    FuelQuantity += amountFuel;
                }
            }
            else
            {
                Console.WriteLine($"Fuel must be a positive number");
            }
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {FuelQuantity:f2}";
        }

        private bool ValidFuelAmount(double amountFuel)
        {
            if (amountFuel <= 0)
            {
                return false;
            }

            return true;
        }
    }
}
