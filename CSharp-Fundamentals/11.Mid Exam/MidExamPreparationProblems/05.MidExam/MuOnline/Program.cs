using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace MuOnline
{
    class Program
    {
        static void Main(string[] args)
        {
            int initialHealth = 100;
            int initialBitcoins = 0;
            List<string> roomsList = Console.ReadLine().Split("|").ToList();
            bool playerIsDead = false;
            int roomCounter = 0;

            for (int i = 0; i < roomsList.Count; i++)
            {
                string[] commandString = roomsList[i].Split(" ").ToArray();
                string commandName = commandString[0];
                int actionNumber = int.Parse(commandString[1]);
                roomCounter++;

                switch (commandName)
                {
                    case "potion":
                        if (initialHealth + actionNumber > 100)
                        {
                            Console.WriteLine($"You healed for {100 - initialHealth} hp.");
                            initialHealth = 100;
                        }
                        else
                        {
                            initialHealth += actionNumber;
                            Console.WriteLine($"You healed for {actionNumber} hp.");
                        }

                        Console.WriteLine($"Current health: {initialHealth} hp.");
                        break;
                    case "chest":
                        Console.WriteLine($"You found {actionNumber} bitcoins.");
                        initialBitcoins += actionNumber;
                        break;
                    default:
                        initialHealth -= actionNumber;
                        if (initialHealth <= 0)
                        {
                            Console.WriteLine($"You died! Killed by {commandName}.");
                            playerIsDead = true;
                        }
                        else
                        {
                            Console.WriteLine($"You slayed {commandName}.");
                        }
                        break;
                }

                if (playerIsDead)
                {
                    Console.WriteLine($"Best room: {roomCounter}");
                    break;
                }
            }

            if (!playerIsDead)
            {
                Console.WriteLine($"You've made it!");
                Console.WriteLine($"Bitcoins: {initialBitcoins}");
                Console.WriteLine($"Health: {initialHealth}");
            }
        }
    }
}
