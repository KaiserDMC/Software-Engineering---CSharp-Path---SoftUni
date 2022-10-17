using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int numberInputs = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < numberInputs; i++)
            {
                string[] stringTokens = Console.ReadLine().Split(" ").ToArray();

                Car currentCar = new Car();

                currentCar.Model = stringTokens[0];

                Engine engine = new Engine(int.Parse(stringTokens[1]), int.Parse(stringTokens[2]));
                currentCar.Engine = engine;

                Cargo cargo = new Cargo(int.Parse(stringTokens[3]), stringTokens[4]);
                currentCar.Cargo = cargo;

                var tires = new Tire[4];

                int index = 5;
                for (int j = 0; j < 4; j++)
                {
                    double pressure = double.Parse(stringTokens[index]);
                    index++;
                    int age = int.Parse(stringTokens[index]);
                    index++;

                    tires[j] = new Tire(age, pressure);
                }

                currentCar.Tires = tires;

                cars.Add(currentCar);
            }

            string cargoCommand = Console.ReadLine();
            List<Car> carsToPrint = new List<Car>();

            switch (cargoCommand)
            {
                case "fragile":
                    foreach (var cTemp in cars.Where(c =>
                                 c.Cargo.Type == "fragile" && c.Tires.Any(t => t.Pressure < 1.0)))
                    {
                        carsToPrint.Add(cTemp);
                    }

                    break;
                case "flammable":
                    foreach (var cTemp in cars.Where(c =>
                                 c.Cargo.Type == "flammable" && c.Engine.Power > 250))
                    {
                        carsToPrint.Add(cTemp);
                    }

                    break;
            }

            foreach (var car in carsToPrint)
            {
                Console.WriteLine($"{car.Model}");
            }
        }
    }
}