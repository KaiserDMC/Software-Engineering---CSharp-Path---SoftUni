using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace FriendListMaintenance
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> initialFriendsList = Console.ReadLine().Split(", ").ToList();
            string inputString = Console.ReadLine();
            int counterBlacklisted = 0;
            int counterLost = 0;

            while (inputString != "Report")
            {
                string[] commandString = inputString.Split(" ").ToArray();
                string commandName = commandString[0];

                switch (commandName)
                {
                    case "Blacklist":
                        string currentName = commandString[1];
                        bool isNamePresent = NameExistsInList(initialFriendsList, currentName);

                        if (isNamePresent)
                        {
                            Console.WriteLine($"{currentName} was blacklisted.");
                            counterBlacklisted++;
                            initialFriendsList[initialFriendsList.IndexOf(currentName)] = "Blacklisted";
                        }
                        else
                        {
                            Console.WriteLine($"{currentName} was not found.");
                        }
                        break;
                    case "Error":
                        int currentIndex = int.Parse(commandString[1]);
                        bool isIndexValid = IsIndexValid(initialFriendsList, currentIndex);

                        if (isIndexValid)
                        {
                            if (initialFriendsList[currentIndex] != "Blacklisted" && initialFriendsList[currentIndex] != "Lost")
                            {
                                string tempCurrentName = initialFriendsList[currentIndex];
                                initialFriendsList[currentIndex] = "Lost";
                                Console.WriteLine($"{tempCurrentName} was lost due to an error.");
                                counterLost++;
                            }
                        }
                        break;
                    case "Change":
                        currentIndex = int.Parse(commandString[1]);
                        string newCurrentName = commandString[2];
                        isIndexValid = IsIndexValid(initialFriendsList, currentIndex);

                        if (isIndexValid)
                        {
                            string tempName = initialFriendsList[currentIndex];
                            initialFriendsList[currentIndex] = newCurrentName;
                            Console.WriteLine($"{tempName} changed his username to {newCurrentName}.");
                        }
                        break;
                }

                inputString = Console.ReadLine();
            }

            Console.WriteLine($"Blacklisted names: {counterBlacklisted}");
            Console.WriteLine($"Lost names: {counterLost}");
            Console.WriteLine(string.Join(" ", initialFriendsList));
        }

        static bool NameExistsInList(List<string> initialFriendsList, string currentName)
        {
            bool isNamePresentInList = false;

            if (initialFriendsList.Contains(currentName))
            {
                isNamePresentInList = true;
            }

            return isNamePresentInList;
        }

        static bool IsIndexValid(List<string> initialFriendsList, int currentIndex)
        {
            bool isIndexValid = false;

            if (currentIndex >= 0 && currentIndex < initialFriendsList.Count)
            {
                isIndexValid = true;
            }

            return isIndexValid;
        }
    }
}
