using System;
using System.Linq;

namespace WorldTour
{
    class Program
    {
        static void Main(string[] args)
        {
            string initialStops = Console.ReadLine();

            while (true)
            {
                string[] commandManipulation = Console.ReadLine().Split(":").ToArray();

                if (commandManipulation[0] == "Travel")
                {
                    break;
                }

                string commandName = commandManipulation[0];

                switch (commandName)
                {
                    case "Add Stop":
                        int indexToCheck = int.Parse(commandManipulation[1]);
                        string stop = commandManipulation[2];

                        if (IsIndexValid(initialStops, indexToCheck))
                        {
                            initialStops = initialStops.Insert(indexToCheck, stop);
                        }

                        Console.WriteLine(initialStops);

                        break;
                    case "Remove Stop":
                        int startIndex = int.Parse(commandManipulation[1]);
                        int stopindex = int.Parse(commandManipulation[2]);

                        if (IsIndexValid(initialStops, startIndex) && IsIndexValid(initialStops, stopindex))
                        {
                            initialStops = initialStops.Remove(startIndex, stopindex + 1 - startIndex);
                        }

                        Console.WriteLine(initialStops);

                        break;
                    case "Switch":
                        string oldStop = commandManipulation[1];
                        stop = commandManipulation[2];

                        initialStops = IsOldStringPresent(initialStops, oldStop, stop);

                        Console.WriteLine(initialStops);

                        break;
                }
            }

            Console.WriteLine($"Ready for world tour! Planned stops: {initialStops}");
        }


        static bool IsIndexValid(string initialStops, int indexToCheck)
        {
            bool validIndex = false;

            if (indexToCheck >= 0 && indexToCheck < initialStops.Length)
            {
                validIndex = true;
            }

            return validIndex;
        }

        static string IsOldStringPresent(string initialStops, string oldStop, string stop)
        {
            string replacedStop = String.Empty;

            if (initialStops.Contains(oldStop))
            {
                replacedStop = initialStops.Replace(oldStop, stop);
            }
            else
            {
                replacedStop = initialStops;
            }

            return replacedStop;
        }
    }
}
