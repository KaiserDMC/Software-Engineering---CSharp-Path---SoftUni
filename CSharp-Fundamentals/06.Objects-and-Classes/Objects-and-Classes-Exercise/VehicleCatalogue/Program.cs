using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Principal;

namespace VehicleCatalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputString = Console.ReadLine();

            VehicleCatalogue vehicleCatalogue = new VehicleCatalogue();

            while (inputString != "End")
            {
                string[] commandTokens = inputString.Split(" ").ToArray();
                Vehicle vehicle = new Vehicle(commandTokens[0], commandTokens[1], commandTokens[2], int.Parse(commandTokens[3]));

                vehicleCatalogue.Vehicles.Add(vehicle);

                inputString = Console.ReadLine();
            }

            string anotherInputString = Console.ReadLine();

            while (anotherInputString != "Close the Catalogue")
            {
                Vehicle vehicle = vehicleCatalogue.Vehicles.Find(v => v.Model == anotherInputString);

                vehicle.ToString();

                anotherInputString = Console.ReadLine();
            }

            List<Vehicle> truckList = vehicleCatalogue.Vehicles.Where(v => v.Type == "truck").ToList();
            List<Vehicle> carList = vehicleCatalogue.Vehicles.Where(v => v.Type == "car").ToList();

            double averageHPTrucks = 0;
            double averageHPCars = 0;

            foreach (Vehicle truck in truckList)
            {
                averageHPTrucks += truck.HorsePower;
            }

            averageHPTrucks /= truckList.Count;

            foreach (Vehicle car in carList)
            {
                averageHPCars += car.HorsePower;
            }

            averageHPCars /= carList.Count;

            if (carList.Count > 0)
            {
                Console.WriteLine($"Cars have average horsepower of: {averageHPCars:f2}.");
            }
            else
            {
                Console.WriteLine("Cars have average horsepower of: 0.00.");
            }

            if (truckList.Count > 0)
            {
                Console.WriteLine($"Trucks have average horsepower of: {averageHPTrucks:f2}.");
            }
            else
            {
                Console.WriteLine("Trucks have average horsepower of: 0.00.");
            }
        }

        class Vehicle
        {
            public Vehicle(string type, string model, string color, int horsePower)
            {
                this.Type = type;
                this.Model = model;
                this.Color = color;
                this.HorsePower = horsePower;
            }

            public string Type { get; set; }
            public string Model { get; set; }
            public string Color { get; set; }
            public int HorsePower { get; set; }

            public void ToString()
            {
                Console.WriteLine($"Type: {(this.Type).Substring(0, 1).ToUpper() + (this.Type).Substring(1)}");
                Console.WriteLine($"Model: {this.Model}");
                Console.WriteLine($"Color: {this.Color}");
                Console.WriteLine($"Horsepower: {this.HorsePower}");
            }
        }

        class VehicleCatalogue
        {
            public VehicleCatalogue()
            {
                this.Vehicles = new List<Vehicle>();
            }

            public List<Vehicle> Vehicles { get; set; }
        }
    }
}
