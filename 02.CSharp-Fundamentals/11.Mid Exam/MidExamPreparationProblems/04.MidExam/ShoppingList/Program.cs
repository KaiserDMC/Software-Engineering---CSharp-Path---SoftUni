using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> initialList = Console.ReadLine().Split("!").ToList();
            string inputString = Console.ReadLine();

            while (inputString != "Go Shopping!")
            {
                string[] commandString = inputString.Split(" ").ToArray();
                string commandName = commandString[0];

                switch (commandName)
                {
                    case "Urgent":
                        string productName = commandString[1];
                        bool itemExists = initialList.Contains(productName);
                        if (!itemExists)
                        {
                            initialList.Insert(0, productName);
                        }
                        break;
                    case "Unnecessary":
                        productName = commandString[1];
                        itemExists = initialList.Contains(productName);
                        if (itemExists)
                        {
                            int indexOfItem = initialList.IndexOf(productName);
                            initialList.RemoveAt(indexOfItem);
                        }
                        break;
                    case "Correct":
                        productName = commandString[1];
                        string newProductName = commandString[2];
                        itemExists = initialList.Contains(productName);
                        if (itemExists)
                        {
                            int indexOfItem = initialList.IndexOf(productName);
                            initialList.RemoveAt(indexOfItem);
                            initialList.Insert(indexOfItem, newProductName);
                        }
                        break;
                    case "Rearrange":
                        productName = commandString[1];
                        itemExists = initialList.Contains(productName);
                        if (itemExists)
                        {
                            int indexOfItem = initialList.IndexOf(productName);
                            initialList.RemoveAt(indexOfItem);
                            initialList.Add(productName);
                        }
                        break;
                }

                inputString = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ", initialList));
        }
    }
}
