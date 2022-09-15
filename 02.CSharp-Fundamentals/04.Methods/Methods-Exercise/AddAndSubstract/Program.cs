using System;

namespace AddAndSubstract
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int thirdNumber = int.Parse(Console.ReadLine());

            int sum = SumOfIntegers(firstNumber, secondNumber);
            int result = SubstractOfIntegers(sum, thirdNumber);

            Console.WriteLine(result);
        }

        static int SumOfIntegers(int firstNumber, int secondNumber)
        {
            return firstNumber + secondNumber;
        }

        static int SubstractOfIntegers(int sum, int thirdNumber)
        {
            return sum - thirdNumber;
        }
    }
}
