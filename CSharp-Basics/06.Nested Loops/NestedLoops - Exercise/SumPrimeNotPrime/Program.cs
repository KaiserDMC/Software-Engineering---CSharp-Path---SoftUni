using System;

namespace SumPrimeNotPrime
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            double sumPrime = 0;
            double sumNotPrime = 0;
            int counter = 0;

            while (input != "stop")
            {
                double number = double.Parse(input);

                if (number < 0)
                {
                    Console.WriteLine("Number is negative.");
                    input = Console.ReadLine();
                    continue;
                }

                for (int i = 1; i <= number; i++)
                {
                    if (number % i == 0)
                    {
                        counter++;
                    }
                }

                if (counter == 2)
                {
                    sumPrime += number;
                }
                else if (number == 0)
                {
                    sumPrime += number;
                }
                else
                {
                    sumNotPrime += number;
                }

                counter = 0;
                input = Console.ReadLine();
            }

            Console.WriteLine($"Sum of all prime numbers is: {sumPrime}");
            Console.WriteLine($"Sum of all non prime numbers is: {sumNotPrime}");
        }
    }
}
