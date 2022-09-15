using System;
using System.Collections.Generic;
using System.Linq;

namespace ArrayModifier
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> initialArrayList = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
            string inputString = Console.ReadLine();

            while (inputString != "end")
            {
                string[] commandString = inputString.Split(" ");
                string commandName = commandString[0];

                switch (commandName)
                {
                    case "swap":
                        int indexOne = int.Parse(commandString[1]);
                        int indexTwo = int.Parse(commandString[2]);
                        int tempIndexOne = initialArrayList[indexOne];
                        initialArrayList[indexOne] = initialArrayList[indexTwo];
                        initialArrayList[indexTwo] = tempIndexOne;
                        break;
                    case "multiply":
                        indexOne = int.Parse(commandString[1]);
                        indexTwo = int.Parse(commandString[2]);
                        int tempValue = initialArrayList[indexTwo];
                        initialArrayList[indexOne] = tempValue * initialArrayList[indexOne];
                        break;
                    case "decrease":
                        for (int i = 0; i < initialArrayList.Count; i++)
                        {
                            initialArrayList[i]--;
                        }
                        break;
                }

                inputString = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ", initialArrayList));
        }
    }
}
