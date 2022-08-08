using System;
using System.Linq;

namespace StringGame
{
    class Program
    {
        static void Main(string[] args)
        {
            string initialString = Console.ReadLine();

            string manipulatedString = initialString;

            while (true)
            {
                string[] commandStrings = Console.ReadLine().Split(" ").ToArray();

                if (commandStrings[0] == "Done")
                {
                    break;
                }

                string commandName = commandStrings[0];

                switch (commandName)
                {
                    case "Change":
                        string singleChar = commandStrings[1];
                        string replacement = commandStrings[2];

                        manipulatedString = manipulatedString.Replace(singleChar, replacement);

                        Console.WriteLine(manipulatedString);

                        break;
                    case "Includes":
                        string subString = commandStrings[1];

                        if (manipulatedString.Contains(subString))
                        {
                            Console.WriteLine($"True");
                        }
                        else
                        {
                            Console.WriteLine($"False");
                        }

                        break;
                    case "End":
                        bool endIsNear = false;
                        subString = commandStrings[1];

                        if (manipulatedString.EndsWith(subString))
                        {
                            endIsNear = true;
                        }

                        if (endIsNear)
                        {
                            Console.WriteLine($"True");
                        }
                        else
                        {
                            Console.WriteLine($"False");
                        }

                        break;
                    case "Uppercase":
                        manipulatedString = manipulatedString.ToUpper();

                        Console.WriteLine(manipulatedString);

                        break;
                    case "FindIndex":
                        singleChar = commandStrings[1];

                        int indexOfChar = manipulatedString.IndexOf(singleChar);

                        Console.WriteLine(indexOfChar);

                        break;
                    case "Cut":
                        int startIndex = int.Parse(commandStrings[1]);
                        int count = int.Parse(commandStrings[2]);

                        manipulatedString = manipulatedString.Substring(startIndex, count);

                        Console.WriteLine(manipulatedString);

                        break;
                }
            }
        }
    }
}
