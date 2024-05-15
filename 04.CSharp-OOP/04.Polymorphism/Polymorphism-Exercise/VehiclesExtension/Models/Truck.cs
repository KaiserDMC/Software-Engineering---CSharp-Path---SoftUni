using VehiclesExtension.Models.Interfaces;

namespace VehiclesExtension.Models
{
    public class Truck : Vehicle
    {
        private const double SUMMER_CONSUMPTION_INCREASE = 1.6;

        public Truck(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity) : base(fuelQuantity, fuelConsumptionPerKm + SUMMER_CONSUMPTION_INCREASE, tankCapacity)
        {
        }

        public override void Refuel(double amountFuel)
        {
            if (this.FuelQuantity + amountFuel * 0.95 > this.TankCapacity)
            {
                base.Refuel(amountFuel);
            }
            else
            {
                base.Refuel(amountFuel * 0.95);
            }
        }
    }
}
