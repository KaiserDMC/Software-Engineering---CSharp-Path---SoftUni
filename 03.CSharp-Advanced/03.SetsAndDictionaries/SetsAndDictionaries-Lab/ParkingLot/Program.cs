using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace ParkingLot
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> carsInParkingLot = new HashSet<string>();

            while (true)
            {
                string[] inputStrings = Console.ReadLine().Split(", ").ToArray();

                if (inputStrings[0] == "END")
                {
                    break;
                }

                string direction = inputStrings[0];
                string carPlate = inputStrings[1];

                if (direction == "IN")
                {
                    carsInParkingLot.Add(carPlate);
                }
                else if (direction == "OUT")
                {
                    carsInParkingLot.Remove(carPlate);
                }
            }

            if (carsInParkingLot.Count > 0)
            {
                foreach (var car in carsInParkingLot)
                {
                    Console.WriteLine(car);
                }
            }
            else
            {
                Console.WriteLine($"Parking Lot is Empty");
            }
        }
    }
}
