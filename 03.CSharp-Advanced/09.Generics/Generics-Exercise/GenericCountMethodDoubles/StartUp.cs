using CommonClasses;
using System;

namespace GenericCountMethodDoubles
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            Box<double> box = new Box<double>();

            int number = int.Parse(Console.ReadLine());

            for (int i = 0; i < number; i++)
            {
                double currNumber = double.Parse(Console.ReadLine());

                box.Items.Add(currNumber);
            }

            double compareToNumber = double.Parse(Console.ReadLine());

            double counter = box.Count(compareToNumber);

            Console.WriteLine(counter);
        }
    }
}