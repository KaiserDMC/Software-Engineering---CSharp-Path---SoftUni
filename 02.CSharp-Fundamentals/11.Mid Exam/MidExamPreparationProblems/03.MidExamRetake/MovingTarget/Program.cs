using System;
using System.Collections.Generic;
using System.Linq;

namespace MovingTarget
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> targetList = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
            string inputString = Console.ReadLine();

            while (inputString != "End")
            {
                string[] commandSeparation = inputString.Split(" ");
                string commandName = commandSeparation[0];
                int targetIndex;

                switch (commandName)
                {
                    case "Shoot":
                        targetIndex = int.Parse(commandSeparation[1]);
                        int shootingPower = int.Parse(commandSeparation[2]);

                        if (targetIndex >= 0 && targetIndex < targetList.Count)
                        {
                            targetList[targetIndex] -= shootingPower;

                            if (targetList[targetIndex] <= 0)
                            {
                                targetList.RemoveAt(targetIndex);
                            }
                        }
                        break;
                    case "Add":
                        targetIndex = int.Parse(commandSeparation[1]);
                        int targetValue = int.Parse(commandSeparation[2]);

                        if (targetIndex >= 0 && targetIndex < targetList.Count)
                        {
                            targetList.Insert(targetIndex, targetValue);
                        }
                        else
                        {
                            Console.WriteLine($"Invalid placement!");
                        }
                        break;
                    case "Strike":
                        targetIndex = int.Parse(commandSeparation[1]);
                        int radius = int.Parse(commandSeparation[2]);
                        if ((targetIndex < 0 || targetIndex > targetList.Count - 1) || (targetIndex + radius < 0 || targetIndex + radius > targetList.Count - 1) || (targetIndex - radius < 0 || targetIndex - radius > targetList.Count - 1))
                        {
                            Console.WriteLine($"Strike missed!");
                            break;
                        }
                        else
                        {
                            targetList.RemoveAt(targetIndex);
                            for (int i = 0; i < radius; i++)
                            {
                                targetList.RemoveAt(targetIndex);
                                targetList.RemoveAt(targetIndex - 1);
                            }
                        }
                        break;
                }

                inputString = Console.ReadLine();
            }

            Console.WriteLine(string.Join("|", targetList));
        }
    }
}
