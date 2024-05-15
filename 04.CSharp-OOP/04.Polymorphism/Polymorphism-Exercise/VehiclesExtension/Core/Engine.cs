using System.Linq;
using VehiclesExtension.Core;
using VehiclesExtension.IO.Interfaces;
using VehiclesExtension.Models;

namespace VehiclesExtension.Core
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
            string[] busParams = this.reader.ReadLine().Split(" ").ToArray();

            int numberOfCommands = int.Parse(this.reader.ReadLine());

            Car car = new Car(double.Parse(carParams[1]), double.Parse(carParams[2]), double.Parse(carParams[3]));
            Truck truck = new Truck(double.Parse(truckParams[1]), double.Parse(truckParams[2]), double.Parse(truckParams[3]));
            Bus bus = new Bus(double.Parse(busParams[1]), double.Parse(busParams[2]), double.Parse(busParams[3]));

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
                        else if (commandStrings[1] == "Bus")
                        {
                            bus.Drive(double.Parse(commandStrings[2]));
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
                        else if (commandStrings[1] == "Bus")
                        {
                            bus.Refuel(double.Parse(commandStrings[2]));
                        }

                        break;

                    case "DriveEmpty":
                        if (commandStrings[1] == "Bus")
                        {
                            bus.DriveEmpty(double.Parse(commandStrings[2]));
                        }

                        break;
                }
            }

            this.writer.WriteLine(car.ToString());
            this.writer.WriteLine(truck.ToString());
            this.writer.WriteLine(bus.ToString());
        }
    }
}
