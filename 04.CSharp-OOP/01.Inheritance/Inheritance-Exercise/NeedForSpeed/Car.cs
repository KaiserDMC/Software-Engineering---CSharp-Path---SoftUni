using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Car : Vehicle
    {
        private const double defaultFuelConsumption = 3;
        public override double FuelConsumption => defaultFuelConsumption;

        public Car(int horsePower, double fuel) : base(horsePower, fuel)
        {
            
        }
    }
}
