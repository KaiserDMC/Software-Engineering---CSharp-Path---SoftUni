using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfCars = int.Parse(Console.ReadLine());
            CarCollector carCollector = new CarCollector();

            for (int i = 0; i < numberOfCars; i++)
            {
                string[] inputStrings = Console.ReadLine().Split(" ").ToArray();

                Car car = new Car
                {
                    Model = inputStrings[0],
                    Engine = new Engine(int.Parse(inputStrings[1]), int.Parse(inputStrings[2])),
                    Cargo = new Cargo(int.Parse(inputStrings[3]), inputStrings[4])
                };

                carCollector.Cars.Add(car);
            }

            string command = Console.ReadLine();
            List<Car> printCars = new List<Car>();

            if (command == "fragile")
            {
                List<Car> fragileCargoCars = carCollector.Cars.Where(c => c.Cargo.CargoType == "fragile" && c.Cargo.CargoWeight < 1000).ToList();
                printCars.AddRange(fragileCargoCars);
            }
            else if (command == "flamable")
            {
                List<Car> flammableCargoCars = carCollector.Cars
                    .Where(c => c.Cargo.CargoType == "flamable" && c.Engine.EnginePower > 250).ToList();
                printCars.AddRange(flammableCargoCars);
            }

            foreach (Car car in printCars)
            {
                Console.WriteLine($"{car.Model}");
            }
        }
    }

    class Car
    {
        public string Model { get; set; }
        public Cargo Cargo { get; set; }
        public Engine Engine { get; set; }
    }

    class CarCollector
    {
        public CarCollector()
        {
            this.Cars = new List<Car>();
        }

        public List<Car> Cars { get; set; }

    }

    class Cargo
    {
        public Cargo(int weight, string type)
        {
            this.CargoWeight = weight;
            this.CargoType = type;
        }

        public int CargoWeight { get; set; }
        public string CargoType { get; set; }
    }

    class Engine
    {
        public Engine(int speed, int power)
        {
            this.EngineSpeed = speed;
            this.EnginePower = power;
        }

        public int EngineSpeed { get; set; }
        public int EnginePower { get; set; }

    }
}
