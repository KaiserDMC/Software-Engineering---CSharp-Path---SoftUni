using System;
using System.Linq;

namespace ActivationKeys
{
    class Program
    {
        static void Main(string[] args)
        {
            string activationKey = Console.ReadLine();

            while (true)
            {
                string[] commandStrings = Console.ReadLine().Split(">>>").ToArray();

                if (commandStrings[0] == "Generate")
                {
                    break;
                }

                string commandName = commandStrings[0];

                switch (commandName)
                {
                    case "Contains":
                        string subStringToCheck = commandStrings[1];

                        if (activationKey.Contains(subStringToCheck))
                        {
                            Console.WriteLine($"{activationKey} contains {subStringToCheck}");
                        }
                        else
                        {
                            Console.WriteLine($"Substring not found!");
                        }

                        break;
                    case "Flip":
                        string upperLower = commandStrings[1];
                        int startIndex = int.Parse(commandStrings[2]);
                        int endIndex = int.Parse(commandStrings[3]);

                        activationKey = Flip(activationKey, upperLower, startIndex, endIndex);

                        Console.WriteLine(activationKey);

                        break;
                    case "Slice":
                        startIndex = int.Parse(commandStrings[1]);
                        endIndex = int.Parse(commandStrings[2]);

                        activationKey = activationKey.Remove(startIndex, endIndex - startIndex);

                        Console.WriteLine(activationKey);

                        break;
                }
            }

            Console.WriteLine($"Your activation key is: {activationKey}");
        }

        static string Flip(string activationKey, string upperLower, int startIndex, int endIndex)
        {
            int tempNumber = 0;
            string tempString = activationKey.Substring(startIndex, endIndex - startIndex);

            if (upperLower == "Upper")
            {
                tempNumber = -1;
            }

            if (tempNumber != 0)
            {
                tempString = tempString.ToUpper();
            }
            else
            {
                tempString = tempString.ToLower();
            }

            activationKey = activationKey.Remove(startIndex, endIndex - startIndex);
            activationKey = activationKey.Insert(startIndex, tempString);

            return activationKey;
        }
    }
}
