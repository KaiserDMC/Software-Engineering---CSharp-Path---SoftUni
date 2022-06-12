using System;

namespace MultiplicationSign
{
    class Program
    {
        static void Main(string[] args)
        {
            int number1 = int.Parse(Console.ReadLine());
            int number2 = int.Parse(Console.ReadLine());
            int number3 = int.Parse(Console.ReadLine());

            bool isNegative = IsNegative(number1, number2, number3);
            bool isZero = IsZero(number1, number2, number3);

            if (isNegative && !isZero)
            {
                Console.WriteLine($"negative");
            }
            else if (isNegative && isZero)
            {
                Console.WriteLine($"zero");
            }
            else if (!isNegative && isZero)
            {
                Console.WriteLine($"zero");
            }
            else
            {
                Console.WriteLine($"positive");
            }
        }

        static bool IsNegative(int number1, int number2, int number3)
        {
            bool isNegative = false;
            int count = 0;

            if (number1 < 0)
            {
                isNegative = true;
                count++;
            }

            if (number2 < 0)
            {
                isNegative = true;
                count++;
            }

            if (number3 < 0)
            {
                isNegative = true;
                count++;
            }

            if (count == 2)
            {
                isNegative = false;
            }

            return isNegative;
        }

        static bool IsZero(int number1, int number2, int number3)
        {
            bool isZero = false;

            if (number1 == 0 || number2 == 0 || number3 == 0)
            {
                isZero = true;
            }

            return isZero;
        }
    }
}
