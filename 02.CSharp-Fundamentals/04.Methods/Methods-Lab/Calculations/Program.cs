using System;

namespace Calculations
{
    class Program
    {
        static void Main(string[] args)
        {
            string typeOfCalculation = Console.ReadLine();
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());

            switch (typeOfCalculation)
            {
                case "add":
                    PrintAddition(firstNumber, secondNumber);
                    break;
                case "multiply":
                    PrintMultiplication(firstNumber, secondNumber);
                    break;
                case "substract":
                    PrintSubstrction(firstNumber, secondNumber);
                    break;
                case "divide":
                    PrintDivision(firstNumber, secondNumber);
                    break;
            }
        }

        static void PrintDivision(int firstNumber, int secondNumber)
        {
            int divide = firstNumber / secondNumber;
            Console.WriteLine(divide);
        }

        static void PrintSubstrction(int firstNumber, int secondNumber)
        {
            int substract = firstNumber - secondNumber;
            Console.WriteLine(substract);
        }

        static void PrintMultiplication(int firstNumber, int secondNumber)
        {
            int multiply = firstNumber * secondNumber;
            Console.WriteLine(multiply);
        }

        static void PrintAddition(int firstNumber, int secondNumber)
        {
            int sum = firstNumber + secondNumber;
            Console.WriteLine(sum);
        }
    }
}