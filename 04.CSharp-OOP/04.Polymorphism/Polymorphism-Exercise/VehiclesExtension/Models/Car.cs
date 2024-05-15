using VehiclesExtension.Models.Interfaces;

namespace VehiclesExtension.Models
{
    public class Car : Vehicle
    {
        private const double SUMMER_CONSUMPTION_INCREASE = 0.9;

        public Car(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity) : base(fuelQuantity, fuelConsumptionPerKm + SUMMER_CONSUMPTION_INCREASE, tankCapacity)
        {
        }
    }
}
