using System;

namespace SmallestOfThreeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOne = int.Parse(Console.ReadLine());
            int numberTwo = int.Parse(Console.ReadLine());
            int numberThree = int.Parse(Console.ReadLine());

            int result = MinNumber(numberOne, numberTwo, numberThree);

            Console.WriteLine(result);
        }

        static int MinNumber(int numberOne, int numberTwo, int numberThree)
        {
            int firstMin = Math.Min(numberOne, numberTwo);
            int finalMin = Math.Min(firstMin, numberThree);

            return finalMin;
        }
    }
}
