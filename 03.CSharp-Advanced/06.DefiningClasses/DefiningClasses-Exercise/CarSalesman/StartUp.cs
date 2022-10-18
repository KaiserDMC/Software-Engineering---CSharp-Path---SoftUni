using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            List<Engine> engines = new List<Engine>();

            int inputsN = int.Parse(Console.ReadLine());

            for (int i = 0; i < inputsN; i++)
            {
                string[] engineInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                Engine currentEngine = new Engine(engineInfo[0], int.Parse(engineInfo[1]));

                int lengthInfo = engineInfo.Length;

                switch (lengthInfo)
                {
                    case 3:
                        string token = engineInfo[2];
                        bool isInteger = int.TryParse(token, out _);

                        if (isInteger)
                        {
                            currentEngine.Displacement = int.Parse(engineInfo[2]);
                        }
                        else
                        {
                            currentEngine.Efficiency = engineInfo[2];
                        }

                        break;
                    case 4:
                        currentEngine.Displacement = int.Parse(engineInfo[2]);
                        currentEngine.Efficiency = engineInfo[3];

                        break;
                }

                engines.Add(currentEngine);
            }

            int inputsM = int.Parse(Console.ReadLine());

            for (int i = 0; i < inputsM; i++)
            {
                string[] carInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                int currentEngineIndexndex = engines.FindIndex(e => e.Model == carInfo[1]);
                Engine currentEngine = engines[currentEngineIndexndex];

                Car currentCar = new Car(carInfo[0], currentEngine);

                int lengthInfo = carInfo.Length;

                switch (lengthInfo)
                {
                    case 3:
                        string token = carInfo[2];
                        bool isInteger = int.TryParse(token, out _);

                        if (isInteger)
                        {
                            currentCar.Weight = int.Parse(carInfo[2]);
                        }
                        else
                        {
                            currentCar.Color = carInfo[2];
                        }

                        break;
                    case 4:
                        currentCar.Weight = int.Parse(carInfo[2]);
                        currentCar.Color = carInfo[3];

                        break;
                }

                cars.Add(currentCar);
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}