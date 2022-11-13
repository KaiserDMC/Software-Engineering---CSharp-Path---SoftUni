using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Models.Interfaces;

namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double SUMMER_CONSUMPTION_INCREASE = 1.6;
        public Truck(double fuelQuantity, double fuelConsumption) : base(fuelQuantity, fuelConsumption+ SUMMER_CONSUMPTION_INCREASE)
        {
        }

        public override void Refuel(double amountFuel)
        {
            base.Refuel(amountFuel * 0.95);
        }
    }
}
