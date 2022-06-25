using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;

namespace ManOWar
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> pirateShipStatus = Console.ReadLine().Split(">").Select(int.Parse).ToList();
            List<int> warShipStatus = Console.ReadLine().Split(">").Select(int.Parse).ToList();
            int maximumHealthCapacity = int.Parse(Console.ReadLine());
            string inputString = Console.ReadLine();
            bool warShipSunken = false;
            bool pirateShipSunken = false;

            while (inputString != "Retire")
            {
                string[] commandString = inputString.Split(" ").ToArray();
                string commandName = commandString[0];

                switch (commandName)
                {
                    case "Fire":
                        int indexToAttack = int.Parse(commandString[1]);
                        int damage = int.Parse(commandString[2]);
                        bool isSectionValid = IsSectionValidWarShip(warShipStatus, indexToAttack);

                        if (isSectionValid)
                        {
                            warShipStatus[indexToAttack] -= damage;

                            if (warShipStatus[indexToAttack] <= 0)
                            {
                                Console.WriteLine($"You won! The enemy ship has sunken.");
                                warShipSunken = true;
                            }
                        }
                        break;
                    case "Defend":
                        int startIndex = int.Parse(commandString[1]);
                        int endIndex = int.Parse(commandString[2]);
                        damage = int.Parse(commandString[3]);
                        isSectionValid = IsSectionValidPirateShip(pirateShipStatus, startIndex, endIndex);

                        if (isSectionValid)
                        {
                            for (int i = startIndex; i <= endIndex; i++)
                            {
                                pirateShipStatus[i] -= damage;

                                if (pirateShipStatus[i] <= 0)
                                {
                                    pirateShipSunken = true;
                                    break;
                                }
                            }
                        }
                        break;
                    case "Repair":
                        int indexToRepair = int.Parse(commandString[1]);
                        int health = int.Parse(commandString[2]);
                        isSectionValid = IsSectionValidPirateShip(pirateShipStatus, indexToRepair);

                        if (isSectionValid)
                        {
                            if (health + pirateShipStatus[indexToRepair] > maximumHealthCapacity)
                            {
                                pirateShipStatus[indexToRepair] = maximumHealthCapacity;
                            }
                            else
                            {
                                pirateShipStatus[indexToRepair] += health;
                            }
                        }
                        break;
                    case "Status":
                        int countRepairSections = 0;

                        for (int i = 0; i < pirateShipStatus.Count; i++)
                        {
                            double needToRepair = 0.2 * maximumHealthCapacity;
                            if (pirateShipStatus[i] < needToRepair)
                            {
                                countRepairSections++;
                            }
                        }

                        Console.WriteLine($"{countRepairSections} sections need repair.");
                        break;
                }

                if (warShipSunken)
                {
                    break;
                }

                if (pirateShipSunken)
                {
                    Console.WriteLine($"You lost! The pirate ship has sunken.");
                    break;
                }

                inputString = Console.ReadLine();
            }

            if (!pirateShipSunken && !warShipSunken)
            {
                double sumSectionsPirateShip = pirateShipStatus.Sum();
                double sumSectionsWarShip = warShipStatus.Sum();

                Console.WriteLine($"Pirate ship status: {sumSectionsPirateShip}");
                Console.WriteLine($"Warship status: {sumSectionsWarShip}");
            }
        }

        static bool IsSectionValidWarShip(List<int> warShipStatus, int indexToAttack)
        {
            bool isSectionValid = false;

            if (indexToAttack >= 0 && indexToAttack < warShipStatus.Count)
            {
                isSectionValid = true;
            }

            return isSectionValid;
        }

        static bool IsSectionValidPirateShip(List<int> pirateShipStatus, int startIndex, int endIndex)
        {
            bool isSectionValid = false;

            if ((startIndex >= 0 && startIndex < pirateShipStatus.Count) && (endIndex >= 0 && endIndex < pirateShipStatus.Count) && (startIndex <= endIndex))
            {
                isSectionValid = true;
            }

            return isSectionValid;
        }

        static bool IsSectionValidPirateShip(List<int> pirateShipStatus, int indexToRepair)
        {
            bool isSectionValid = false;

            if (indexToRepair >= 0 && indexToRepair < pirateShipStatus.Count)
            {
                isSectionValid = true;
            }

            return isSectionValid;
        }
    }
}
