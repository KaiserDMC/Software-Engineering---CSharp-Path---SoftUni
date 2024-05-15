using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vehicles.IO.Interfaces;
using Vehicles.Models;
using Vehicles.Models.Interfaces;

namespace Vehicles.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;

        public Engine()
        {

        }

        public Engine(IReader reader, IWriter writer) : this()
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            string[] carParams = this.reader.ReadLine().Split(" ").ToArray();
            string[] truckParams = this.reader.ReadLine().Split(" ").ToArray();

            int numberOfCommands = int.Parse(this.reader.ReadLine());

            Car car = new Car(double.Parse(carParams[1]), double.Parse(carParams[2]));
            Truck truck = new Truck(double.Parse(truckParams[1]), double.Parse(truckParams[2]));

            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] commandStrings = this.reader.ReadLine().Split(" ").ToArray();

                switch (commandStrings[0])
                {
                    case "Drive":
                        if (commandStrings[1] == "Car")
                        {
                            car.Drive(double.Parse(commandStrings[2]));
                        }
                        else if (commandStrings[1] == "Truck")
                        {
                            truck.Drive(double.Parse(commandStrings[2]));
                        }

                        break;
                    case "Refuel":
                        if (commandStrings[1] == "Car")
                        {
                            car.Refuel(double.Parse(commandStrings[2]));
                        }
                        else if (commandStrings[1] == "Truck")
                        {
                            truck.Refuel(double.Parse(commandStrings[2]));
                        }

                        break;
                }
            }

            this.writer.WriteLine(car.ToString());
            this.writer.WriteLine(truck.ToString());
        }
    }
}
