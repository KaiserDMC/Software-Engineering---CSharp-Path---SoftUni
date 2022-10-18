using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUniParking
{
    public class Parking
    {
        private List<Car> cars;
        private int capacity;

        public Parking(int capacity)
        {
            this.Cars = new List<Car>();
            this.Capacity = capacity;
        }

        public List<Car> Cars
        {
            get { return cars; }
            set { cars = value; }
        }

        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }

        public int Count
        {
            get { return cars.Count; }
        }

        public string AddCar(Car car)
        {
            if (this.Cars.Any(c => c.RegistrationNumber == car.RegistrationNumber))
            {
                return $"Car with that registration number, already exists!";
            }
            else if (capacity <= this.Cars.Count)
            {
                return $"Parking is full!";
            }
            else
            {
                this.Cars.Add(car);
                return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
            }
        }

        public string RemoveCar(string RegistrationNumber)
        {
            if (!this.Cars.Any(c => c.RegistrationNumber == RegistrationNumber))
            {
                return $"Car with that registration number, doesn't exist!";
            }
            else
            {
                int indexOfCar = this.Cars.FindIndex(c => c.RegistrationNumber == RegistrationNumber);
                this.Cars.RemoveAt(indexOfCar);
                return $"Successfully removed {RegistrationNumber}";
            }
        }

        public Car GetCar(string RegistrationNumber)
        {
            return this.Cars.Find(c => c.RegistrationNumber == RegistrationNumber);
        }

        public void RemoveSetOfRegistrationNumber(List<string> RegistrationNumbers)
        {
            foreach (var regNumber in RegistrationNumbers)
            {
                RemoveCar(regNumber);
            }
        }
    }
}