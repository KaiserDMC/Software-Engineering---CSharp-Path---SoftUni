using System;
using System.Collections.Generic;
using System.Linq;

namespace Inventory
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> inventoryList = Console.ReadLine().Split(", ").ToList();
            string inputString = Console.ReadLine();

            while (inputString != "Craft!")
            {
                string[] commandString = inputString.Split(" - ").ToArray();
                string commandName = commandString[0];

                switch (commandName)
                {
                    case "Collect":
                        string item = commandString[1];
                        bool isItemPresent = ItemExists(inventoryList, item);
                        if (!isItemPresent)
                        {
                            inventoryList.Add(item);
                        }
                        break;
                    case "Drop":
                        item = commandString[1];
                        isItemPresent = ItemExists(inventoryList, item);
                        if (isItemPresent)
                        {
                            inventoryList.Remove(item);
                        }
                        break;
                    case "Combine Items":
                        string[] bothItems = commandString[1].Split(":").ToArray();
                        string oldItem = bothItems[0];
                        string newItem = bothItems[1];
                        isItemPresent = ItemExists(inventoryList, oldItem);
                        if (isItemPresent)
                        {
                            int indexOfOldItem = inventoryList.IndexOf(oldItem);
                            inventoryList.Insert(indexOfOldItem + 1, newItem);
                        }
                        break;
                    case "Renew":
                        item = commandString[1];
                        isItemPresent = ItemExists(inventoryList, item);
                        if (isItemPresent)
                        {
                            int indexOfOldItem = inventoryList.IndexOf(item);
                            inventoryList.RemoveAt(indexOfOldItem);
                            inventoryList.Add(item);
                        }
                        break;
                }

                inputString = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ", inventoryList));
        }

        static bool ItemExists(List<string> inventoryList, string item)
        {
            bool isItemPresent = false;

            if (inventoryList.Contains(item))
            {
                isItemPresent = true;
            }

            return isItemPresent;
        }
    }
}
