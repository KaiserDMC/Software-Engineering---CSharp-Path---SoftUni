using System;

namespace FloatingEquality
{
    class Program
    {
        static void Main(string[] args)
        {
            double numberA = double.Parse(Console.ReadLine());
            double numberB = double.Parse(Console.ReadLine());
            double eps = 0.000001;

            bool equal = false;

            double difference = Math.Abs(Math.Abs(numberA) - Math.Abs(numberB));

            if (eps >= difference)
            {
                equal = true;
            }

            if (!equal)
            {
                Console.WriteLine($"{equal.ToString()}");
            }
            else
            {
                Console.WriteLine($"{equal.ToString()}");
            }
        }
    }
}
