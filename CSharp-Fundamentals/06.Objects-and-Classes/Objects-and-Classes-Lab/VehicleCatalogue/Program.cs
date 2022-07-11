using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;

namespace VehicleCatalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputString = Console.ReadLine();
            CatalogVehicle catalogVehicle = new CatalogVehicle();

            while (inputString != "end")
            {
                string[] splitInputString = inputString.Split("/").ToArray();

                string type = splitInputString[0];
                string brand = splitInputString[1];
                string model = splitInputString[2];
                int hpOrWeight = int.Parse(splitInputString[3]);

                if (type == "Car")
                {
                    Car car = new Car();

                    car.Brand = brand;
                    car.Model = model;
                    car.HorsePower = hpOrWeight;

                    catalogVehicle.Cars.Add(car);
                }
                else
                {
                    Truck truck = new Truck();
                    truck.Brand = brand;
                    truck.Model = model;
                    truck.Weight = hpOrWeight;

                    catalogVehicle.Trucks.Add(truck);

                }

                inputString = Console.ReadLine();
            }


            if (catalogVehicle.Cars.Count > 0)
            {
                List<Car> orderedCars = catalogVehicle.Cars.OrderBy(c => c.Brand).ToList();

                Console.WriteLine($"Cars:");

                foreach (var car in orderedCars)
                {
                    Console.WriteLine($"{car.Brand}: {car.Model} - {car.HorsePower}hp");
                }
            }

            if (catalogVehicle.Trucks.Count > 0)
            {
                List<Truck> orderedTrucks = catalogVehicle.Trucks.OrderBy(c => c.Brand).ToList();

                Console.WriteLine("Trucks:");

                foreach (var truck in orderedTrucks)
                {
                    Console.WriteLine($"{truck.Brand}: {truck.Model} - {truck.Weight}kg");
                }
            }
        }
    }

    class Truck
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Weight { get; set; }
    }

    class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int HorsePower { get; set; }
    }

    class CatalogVehicle
    {
        public CatalogVehicle()
        {
            this.Cars = new List<Car>();
            this.Trucks = new List<Truck>();
        }

        public List<Car> Cars { get; set; }
        public List<Truck> Trucks { get; set; }
    }
}
