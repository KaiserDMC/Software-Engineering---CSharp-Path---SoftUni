using System;
using System.Collections.Generic;
using System.Linq;

namespace SpeedRacing
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfCars = int.Parse(Console.ReadLine());

            CarCollection carCollection = new CarCollection();

            for (int i = 0; i < numberOfCars; i++)
            {
                string[] inputStrings = Console.ReadLine().Split(" ").ToArray();

                Car car = new Car
                {
                    Model = inputStrings[0],
                    FuelAmount = double.Parse(inputStrings[1]),
                    FuelConsumption = double.Parse(inputStrings[2]),
                    TravelledDistance = 0
                };

                carCollection.Cars.Add(car);
            }

            string whileCondition = Console.ReadLine();

            while (whileCondition != "End")
            {
                string[] driveCommandStrings = whileCondition.Split(" ").ToArray();

                string modelToChange = driveCommandStrings[1];
                int distanceToTravel = int.Parse(driveCommandStrings[2]);

                int indexToChange = carCollection.Cars.FindIndex(i => i.Model == modelToChange);
                carCollection.Cars[indexToChange].IsPossibleDrive(distanceToTravel);

                whileCondition = Console.ReadLine();
            }

            foreach (Car car in carCollection.Cars)
            {
                Console.WriteLine(car.ToString());
            }
        }
    }

    class Car
    {
        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumption { get; set; }
        public int TravelledDistance { get; set; }

        public void IsPossibleDrive(int distanceToTravel)
        {
            double fuelNeeded = this.FuelConsumption * distanceToTravel;

            if (fuelNeeded > this.FuelAmount)
            {
                Console.WriteLine($"Insufficient fuel for the drive");
            }
            else
            {
                this.FuelAmount -= fuelNeeded;
                this.TravelledDistance += distanceToTravel;
            }
        }

        public override string ToString()
        {
            string temp = $"{this.Model} {this.FuelAmount:f2} {this.TravelledDistance}";
            return temp;
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
