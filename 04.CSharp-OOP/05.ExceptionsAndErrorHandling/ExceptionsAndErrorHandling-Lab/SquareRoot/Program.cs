using System;

namespace SquareRoot
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());

            try
            {
                if (input < 0)
                {
                    throw new ArgumentException($"Invalid number.");
                }

                double result = Math.Sqrt(input);
                Console.WriteLine(result);
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
            }
            finally
            {
                Console.WriteLine($"Goodbye.");
            }
        }
    }
}
