using System;

namespace PrintAndSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOne = int.Parse(Console.ReadLine());
            int numberTwo = int.Parse(Console.ReadLine());

            int sum = 0;

            for (int i = numberOne; i <= numberTwo; i++)
            {
                Console.Write(i + " ");
                sum += i;
            }
            Console.WriteLine();
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
