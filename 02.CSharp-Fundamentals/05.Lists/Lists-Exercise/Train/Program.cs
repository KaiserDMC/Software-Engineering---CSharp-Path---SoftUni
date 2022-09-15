using System;
using System.Collections.Generic;
using System.Linq;

namespace Train
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numberOfPassengersInWagon = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
            int wagonCapacity = int.Parse(Console.ReadLine());
            string[] input = Console.ReadLine().Split(" ").ToArray();

            while (input[0] != "end")
            {
                string[] command = input;

                if (command[0] == "Add")
                {
                    int newPassengerWagon = int.Parse(command[1]);
                    numberOfPassengersInWagon.Add(newPassengerWagon);
                }
                else
                {
                    int numberPassengersToFit = int.Parse(command[0]);
                    int differenceInPassengers = 0;

                    for (int i = 0; i < numberOfPassengersInWagon.Count; i++)
                    {
                        differenceInPassengers = wagonCapacity - numberOfPassengersInWagon[i];

                        if (numberPassengersToFit <= differenceInPassengers)
                        {
                            numberOfPassengersInWagon[i] += numberPassengersToFit;
                            break;
                        }
                    }
                }

                input = Console.ReadLine().Split(" ").ToArray();
            }

            Console.WriteLine(string.Join(" ", numberOfPassengersInWagon));
        }
    }
}
