using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int numberOfInputs = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < numberOfInputs; i++)
            {
                Car currentCar = new Car();

                string[] carData = Console.ReadLine().Split(" ").ToArray();

                currentCar.Model = carData[0];
                currentCar.FuelAmount = double.Parse(carData[1]);
                currentCar.FuelConsumptionPerKilometer = double.Parse(carData[2]);
                currentCar.TravelledDistance = 0;

                cars.Add(currentCar);
            }

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "End")
                {
                    break;
                }

                string[] commandInput = command.Split(" ").ToArray();

                switch (commandInput[0])
                {
                    case "Drive":
                        string currentModel = commandInput[1];
                        double currentKilometers = double.Parse(commandInput[2]);

                        Car grabCar = cars.Find(c => c.Model == currentModel);

                        grabCar.Drive(currentKilometers);

                        break;
                }
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TravelledDistance}");
            }
        }
    }
}