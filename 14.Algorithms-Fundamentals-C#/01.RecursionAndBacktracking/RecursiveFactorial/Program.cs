using System;

namespace RecursiveFactorial
{
    public class Program
    {
        static void Main(string[] args)
        {
            int x = int.Parse(Console.ReadLine());

            Console.WriteLine(Factorial(x));
        }

        private static int Factorial(int n)
        {
            if (n <= 1)
            {
                return 1;
            }

            return n * Factorial(n - 1);
        }
    }
}