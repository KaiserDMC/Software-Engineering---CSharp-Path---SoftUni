using System;

namespace Train
{
    class Program
    {
        static void Main(string[] args)
        {
            int wagons = int.Parse(Console.ReadLine());
            int sum = 0;
            int[] passengersInWagon = new int[wagons];

            for (int i = 0; i < wagons; i++)
            {
                passengersInWagon[i] = int.Parse(Console.ReadLine());
                sum += passengersInWagon[i];
            }

            foreach (int passengers in passengersInWagon)
            {
                Console.Write($"{passengers} ");
            }

            Console.WriteLine();
            Console.WriteLine(sum);
        }
    }
}
