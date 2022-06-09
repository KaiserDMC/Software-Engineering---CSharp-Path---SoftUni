using System;

namespace MathOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOne = int.Parse(Console.ReadLine());
            string op = Console.ReadLine();
            int numberTwo = int.Parse(Console.ReadLine());
            Console.WriteLine(Calculator(numberOne, op, numberTwo));
        }

        static double Calculator(int numberOne, string op, int numberTwo)
        {
            double result = 0;

            switch (op)
            {
                case "/":
                    result = numberOne / numberTwo;
                    break;
                case "*":
                    result = numberOne * numberTwo;
                    break;
                case "+":
                    result = numberOne + numberTwo;
                    break;
                case "-":
                    result = numberOne - numberTwo;
                    break;
            }

            return result;
        }
    }
}
