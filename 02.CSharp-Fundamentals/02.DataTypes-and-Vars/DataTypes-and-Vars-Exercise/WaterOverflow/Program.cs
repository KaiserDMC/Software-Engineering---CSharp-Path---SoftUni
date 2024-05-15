using System;

namespace WaterOverflow
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            int tankCapacity = 255;
            int currentCapacity = 0;

            for (int i = 0; i < input; i++)
            {
                int litres = int.Parse(Console.ReadLine());

                currentCapacity += litres;

                if (tankCapacity < currentCapacity)
                {
                    Console.WriteLine($"Insufficient capacity!");
                    currentCapacity -= litres;
                }
            }

            Console.WriteLine(currentCapacity);
        }
    }
}
