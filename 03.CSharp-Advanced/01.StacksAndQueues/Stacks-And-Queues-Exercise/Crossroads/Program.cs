using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenLightDuration = int.Parse(Console.ReadLine());
            int freeWindowDuration = int.Parse(Console.ReadLine());

            string input = Console.ReadLine();
            Queue<string> carQueue = new Queue<string>();
            int passedCarsCounter = 0;

            while (input != "END")
            {
                if (input != "green")
                {
                    carQueue.Enqueue(input);
                }
                else
                {
                    int greenSeconds = greenLightDuration;
                    int yellowSeconds = freeWindowDuration;
                    int counter = carQueue.Count;

                    for (int i = 0; i < counter; i++)
                    {
                        string currentCar = carQueue.Peek();

                        if (currentCar.Length <= greenSeconds && carQueue.Any())
                        {
                            greenSeconds -= currentCar.Length;
                            passedCarsCounter++;
                            carQueue.Dequeue();
                        }
                        else if (currentCar.Length > greenSeconds && carQueue.Any())
                        {
                            int secondsWithYellow = greenSeconds + yellowSeconds;

                            if (greenSeconds <= 0)
                            {
                                continue;
                            }
                            else if (currentCar.Length <= secondsWithYellow)
                            {
                                passedCarsCounter++;
                                greenSeconds = 0;
                                yellowSeconds = 0;
                                carQueue.Dequeue();
                            }
                            else if (currentCar.Length > secondsWithYellow)
                            {
                                Console.WriteLine($"A crash happened!");
                                Console.WriteLine($"{currentCar} was hit at {currentCar[secondsWithYellow]}.");

                                return;
                            }
                        }
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{passedCarsCounter} total cars passed the crossroads.");
        }
    }
}
