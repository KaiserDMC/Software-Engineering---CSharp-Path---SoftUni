using System;

namespace Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOne = int.Parse(Console.ReadLine());
            int numberTwo = int.Parse(Console.ReadLine());
            char operation = char.Parse(Console.ReadLine());

            double result = 0;
            string isEven = "odd";

            if (operation == '+' || operation == '-' || operation == '*')
            {
                switch (operation)
                {
                    case '+':
                        result = numberOne + numberTwo;
                        break;
                    case '-':
                        result = numberOne - numberTwo;
                        break;
                    case '*':
                        result = numberOne * numberTwo;
                        break;
                }

                if (result % 2 == 0)
                {
                    isEven = "even";
                }

                Console.WriteLine($"{numberOne} {operation} {numberTwo} = {result} - {isEven}");
            }
            else if (operation == '/')
            {
                if (numberTwo == 0)
                {
                    Console.WriteLine($"Cannot divide {numberOne} by zero");
                }
                else
                {
                    result = (double)numberOne / (double)numberTwo;
                    Console.WriteLine($"{numberOne} / {numberTwo} = {result:f2}");
                }
            }
            else if (operation == '%')
            {
                if (numberTwo == 0)
                {
                    Console.WriteLine($"Cannot divide {numberOne} by zero");
                }
                else
                {
                    result = numberOne % numberTwo;
                    Console.WriteLine($"{numberOne} % {numberTwo} = {result}");
                }

            }
        }
    }
}
