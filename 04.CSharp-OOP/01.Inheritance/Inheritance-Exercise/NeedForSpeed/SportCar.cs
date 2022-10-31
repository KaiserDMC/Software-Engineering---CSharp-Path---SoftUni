using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class SportCar : Car
    {
        private const double defaultFuelConsumption = 10;
        public override double FuelConsumption => defaultFuelConsumption;

        public SportCar(int horsePower, double fuel) : base(horsePower, fuel)
        {

        }
    }
}
