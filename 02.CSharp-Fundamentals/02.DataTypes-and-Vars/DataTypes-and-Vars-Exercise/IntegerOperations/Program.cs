using System;

namespace IntegerOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOne = int.Parse(Console.ReadLine());
            int numberTwo = int.Parse(Console.ReadLine());
            int numberThree = int.Parse(Console.ReadLine());
            int numberFour = int.Parse(Console.ReadLine());

            int sum = numberOne + numberTwo;
            int division = sum / numberThree;
            int multiply = division * numberFour;
            int result = multiply;

            Console.WriteLine(result);
        }
    }
}
