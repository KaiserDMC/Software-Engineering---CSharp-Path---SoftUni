using System;

namespace FactorialDivision
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());

            double firstFactorial = CalculateFirstFactorial(firstNumber);
            double secondFactorial = CalculateSecondFactorial(secondNumber);

            double result = DivideFactorial(firstFactorial, secondFactorial);

            Console.WriteLine($"{result:f2}");
        }

        static double CalculateFirstFactorial(int firstNumber)
        {
            double fact = 1;

            while (firstNumber != 1)
            {
                fact *= firstNumber;
                firstNumber--;
            }

            return fact;
        }

        static double CalculateSecondFactorial(int secondNumber)
        {
            double fact = 1;

            while (secondNumber != 1)
            {
                fact *= secondNumber;
                secondNumber--;
            }

            return fact;
        }

        static double DivideFactorial(double firstFactorial, double secondFactorial)
        {
            return firstFactorial / secondFactorial;
        }
    }
}
