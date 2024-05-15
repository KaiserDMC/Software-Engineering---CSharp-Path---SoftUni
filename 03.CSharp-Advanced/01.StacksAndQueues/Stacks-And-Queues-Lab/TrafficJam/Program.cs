using System;
using System.Collections.Generic;

namespace TrafficJam
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxNumberToPass = int.Parse(Console.ReadLine());

            Queue<string> carQueue = new Queue<string>();

            string command = Console.ReadLine();
            int counterPassed = 0;

            while (command != "end")
            {
                if (command != "green")
                {
                    carQueue.Enqueue(command);
                }
                else
                {
                    if (carQueue.Count >= maxNumberToPass)
                    {
                        for (int i = 0; i < maxNumberToPass; i++)
                        {
                            Console.WriteLine($"{carQueue.Dequeue()} passed!");
                            counterPassed++;
                        }
                    }
                    else
                    {
                        int currentQueueCount = carQueue.Count;
                        for (int i = 0; i < currentQueueCount; i++)
                        {
                            Console.WriteLine($"{carQueue.Dequeue()} passed!");
                            counterPassed++;
                        }
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"{counterPassed} cars passed the crossroads.");
        }
    }
}
