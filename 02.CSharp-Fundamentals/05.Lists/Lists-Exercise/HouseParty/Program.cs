using System;
using System.Collections.Generic;
using System.Linq;

namespace HouseParty
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfCommands = int.Parse(Console.ReadLine());
            List<string> partyList = new List<string>();

            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] command = Console.ReadLine().Split(" ").ToArray();
                string name = command[0];

                if (command[2] == "not")
                {
                    bool isOnTheList = partyList.Any(item => item == name);

                    if (isOnTheList)
                    {
                        partyList.Remove(name);
                    }
                    else
                    {
                        Console.WriteLine($"{name} is not in the list!");
                    }
                }
                else
                {
                    bool isOnTheList = partyList.Any(item => item == name);

                    if (!isOnTheList)
                    {
                        partyList.Add(name);
                    }
                    else
                    {
                        Console.WriteLine($"{name} is already in the list!");
                    }
                }
            }

            foreach (string guestName in partyList)
            {
                Console.WriteLine(guestName);
            }
        }
    }
}
