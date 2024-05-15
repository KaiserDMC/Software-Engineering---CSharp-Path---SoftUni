using System;

namespace DefiningClasses
{
    public class Car
    {
        private string model;
        private double fuelAmount;
        private double fuelConsumptionPerKilometer;
        private double travelledDistance;

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public double FuelAmount
        {
            get { return fuelAmount; }
            set { fuelAmount = value; }
        }

        public double FuelConsumptionPerKilometer
        {
            get { return fuelConsumptionPerKilometer; }
            set { fuelConsumptionPerKilometer = value; }
        }

        public double TravelledDistance
        {
            get { return travelledDistance; }
            set { travelledDistance = value; }
        }

        public void Drive(double kilometers)
        {
            double fuelLeft = fuelAmount - (kilometers * fuelConsumptionPerKilometer);

            if (fuelLeft < 0)
            {
                Console.WriteLine($"Insufficient fuel for the drive");
                return;
            }

            fuelAmount = fuelLeft;
            travelledDistance += kilometers;
        }
    }
}