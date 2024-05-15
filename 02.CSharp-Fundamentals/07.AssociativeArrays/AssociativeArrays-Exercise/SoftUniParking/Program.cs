using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace SoftUniParking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> carPlatesByOwnersDictionary = new Dictionary<string, string>();

            int numberOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] commandInput = Console.ReadLine().Split(" ").ToArray();
                string commandName = commandInput[0];

                switch (commandName)
                {
                    case "register":
                        string userName = commandInput[1];
                        string licensePlate = commandInput[2];

                        if (carPlatesByOwnersDictionary.ContainsKey(userName))
                        {
                            Console.WriteLine($"ERROR: already registered with plate number {carPlatesByOwnersDictionary[userName]}");
                        }
                        else
                        {
                            carPlatesByOwnersDictionary.Add(userName, licensePlate);
                            Console.WriteLine($"{userName} registered {licensePlate} successfully");
                        }

                        break;
                    case "unregister":
                        userName = commandInput[1];

                        if (!carPlatesByOwnersDictionary.ContainsKey(userName))
                        {
                            Console.WriteLine($"ERROR: user {userName} not found");
                        }
                        else
                        {
                            carPlatesByOwnersDictionary.Remove(userName);
                            Console.WriteLine($"{userName} unregistered successfully");
                        }

                        break;
                }
            }

            foreach (var VARIABLE in carPlatesByOwnersDictionary)
            {
                Console.WriteLine($"{VARIABLE.Key} => {VARIABLE.Value}");
            }
        }
    }
}
