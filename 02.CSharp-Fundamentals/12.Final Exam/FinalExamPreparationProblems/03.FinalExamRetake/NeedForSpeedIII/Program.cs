using System;
using System.Collections.Generic;
using System.Linq;

namespace NeedForSpeedIII
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfCars = int.Parse(Console.ReadLine());

            CarCollection carCollection = new CarCollection();

            for (int i = 0; i < numberOfCars; i++)
            {
                string[] inputCarStrings = Console.ReadLine().Split("|").ToArray();

                Car car = new Car
                {
                    CarName = inputCarStrings[0],
                    Mileage = int.Parse(inputCarStrings[1]),
                    Fuel = int.Parse(inputCarStrings[2])
                };

                carCollection.Cars.Add(car);
            }

            string[] commandInputStrings = Console.ReadLine().Split(" : ").ToArray();

            while (commandInputStrings[0] != "Stop")
            {
                string commandName = commandInputStrings[0];

                switch (commandName)
                {
                    case "Drive":
                        string carToDrive = commandInputStrings[1];
                        int distanceToDrive = int.Parse(commandInputStrings[2]);
                        int fuelUsed = int.Parse(commandInputStrings[3]);

                        int indexOfCar = carCollection.Cars.FindIndex(i => i.CarName == carToDrive);
                        carCollection.Cars[indexOfCar].IsPossibleToDrive(distanceToDrive, fuelUsed);

                        if (carCollection.Cars[indexOfCar].Mileage >= 100000)
                        {
                            carCollection.Cars.Remove(carCollection.Cars[indexOfCar]);
                        }

                        break;
                    case "Refuel":
                        carToDrive = commandInputStrings[1];
                        int fuelRefueled = int.Parse(commandInputStrings[2]);

                        indexOfCar = carCollection.Cars.FindIndex(i => i.CarName == carToDrive);
                        carCollection.Cars[indexOfCar].Refuel(fuelRefueled);

                        break;
                    case "Revert":
                        carToDrive = commandInputStrings[1];
                        int kilometers = int.Parse(commandInputStrings[2]);

                        indexOfCar = carCollection.Cars.FindIndex(i => i.CarName == carToDrive);
                        carCollection.Cars[indexOfCar].RevertMileage(kilometers);

                        break;
                }

                commandInputStrings = Console.ReadLine().Split(" : ").ToArray();
            }

            foreach (Car car in carCollection.Cars)
            {
                Console.WriteLine($"{car.CarName} -> Mileage: {car.Mileage} kms, Fuel in the tank: {car.Fuel} lt.");
            }
        }
    }

    class Car
    {
        public string CarName { get; set; }
        public int Mileage { get; set; }
        public int Fuel { get; set; }

        public void IsPossibleToDrive(int distanceToDrive, int fuelUsed)
        {
            int fuelNeeded = fuelUsed;

            if (this.Fuel >= fuelNeeded)
            {
                this.Mileage += distanceToDrive;
                this.Fuel = this.Fuel - fuelNeeded;

                Console.WriteLine($"{this.CarName} driven for {distanceToDrive} kilometers. {fuelNeeded} liters of fuel consumed.");
            }
            else
            {
                Console.WriteLine($"Not enough fuel to make that ride");
            }

            if (this.Mileage >= 100000)
            {
                Console.WriteLine($"Time to sell the {this.CarName}!");
            }
        }

        public void Refuel(int fuelRefueled)
        {
            int actualRefueled = this.Fuel + fuelRefueled;

            if (actualRefueled > 75)
            {
                fuelRefueled = 75 - this.Fuel;
                this.Fuel = 75;
            }
            else
            {
                this.Fuel = actualRefueled;
            }

            Console.WriteLine($"{this.CarName} refueled with {fuelRefueled} liters");
        }

        public void RevertMileage(int kilometers)
        {
            this.Mileage = this.Mileage - kilometers;

            if (this.Mileage >= 10000)
            {
                Console.WriteLine($"{this.CarName} mileage decreased by {kilometers} kilometers");
            }
            else
            {
                this.Mileage = 10000;
            }
        }

    }

    class CarCollection
    {
        public CarCollection()
        {
            this.Cars = new List<Car>();
        }

        public List<Car> Cars { get; set; }
    }
}
