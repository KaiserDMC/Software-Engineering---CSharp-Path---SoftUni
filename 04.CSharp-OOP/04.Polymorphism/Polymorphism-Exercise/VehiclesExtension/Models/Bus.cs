using System;
using System.Collections.Generic;
using System.Text;
using VehiclesExtension.Models.Interfaces;

namespace VehiclesExtension.Models
{
    public class Bus : Vehicle
    {
        private const double NOT_EMPTY_INCREASE = 1.4;

        public Bus(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity) : base(fuelQuantity, fuelConsumptionPerKm, tankCapacity)
        {
        }

        public override void Drive(double distance)
        {
            base.FuelConsumption += NOT_EMPTY_INCREASE;
            base.Drive(distance);
            base.FuelConsumption -= NOT_EMPTY_INCREASE;
        }

        public void DriveEmpty(double distance)
        {
            base.Drive(distance);
        }
    }
}
