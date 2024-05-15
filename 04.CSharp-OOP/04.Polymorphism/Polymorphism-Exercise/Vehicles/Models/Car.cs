using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Models.Interfaces;

namespace Vehicles.Models
{
    public class Car : Vehicle
    {
        private const double SUMMER_CONSUMPTION_INCREASE = 0.9;
        public Car(double fuelQuantity, double fuelConsumption) : base(fuelQuantity, fuelConsumption + SUMMER_CONSUMPTION_INCREASE)
        {
        }
    }
}
