using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Tire[]> tireCollection = new List<Tire[]>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "No more tires")
                {
                    break;
                }

                string[] tireData = input.Split(" ").ToArray();

                var tires = new Tire[4];

                int index = 0;
                for (int i = 0; i < 4; i++)
                {
                    int year = int.Parse(tireData[index]);
                    index++;
                    double pressure = double.Parse(tireData[index]);
                    index++;

                    tires[i] = new Tire(year, pressure);
                }

                tireCollection.Add(tires);
            }

            List<Engine> engineCollection = new List<Engine>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Engines done")
                {
                    break;
                }

                string[] engineData = input.Split(" ").ToArray();

                int hp = int.Parse(engineData[0]);
                double cubic = double.Parse(engineData[1]);

                Engine engine = new Engine(hp, cubic);

                engineCollection.Add(engine);
            }

            List<Car> carCollection = new List<Car>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Show special")
                {
                    break;
                }

                string[] carData = input.Split(" ").ToArray();

                string make = carData[0];
                string model = carData[1];
                int year = int.Parse(carData[2]);
                double fuelQuantity = double.Parse(carData[3]);
                double fuelConsumption = double.Parse(carData[4]);
                int engineIndex = int.Parse(carData[5]);
                int tiresIndex = int.Parse(carData[6]);

                Car car = new Car(make, model, year, fuelQuantity, fuelConsumption, engineCollection[engineIndex],
                    tireCollection[tiresIndex]);

                carCollection.Add(car);
            }

            List<Car> finalCarCollection = new List<Car>();

            finalCarCollection = carCollection.FindAll(c =>
                c.Year >= 2017 && c.Engine.HorsePower > 330 && c.Tires.Select(t => t.Pressure).Sum() >= 9 &&
                c.Tires.Select(t => t.Pressure).Sum() <= 10).ToList();

            foreach (var finalCar in finalCarCollection)
            {
                finalCar.Drive(20);

                Console.WriteLine($"Make: {finalCar.Make}");
                Console.WriteLine($"Model: {finalCar.Model}");
                Console.WriteLine($"Year: {finalCar.Year}");
                Console.WriteLine($"HorsePowers: {finalCar.Engine.HorsePower}");
                Console.WriteLine($"FuelQuantity: {finalCar.FuelQuantity}");
            }
        }
    }
}