using System;

namespace MultiplyTable
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input
            int inputNumber = int.Parse(Console.ReadLine());

            //Calculations
            int thirdDigit = inputNumber % 10;
            int secondDigit = (inputNumber / 10) % 10;
            int firstDigit = (inputNumber / 100);

            for (int i = 1; i <= thirdDigit; i++)
            {
                for (int j = 1; j <= secondDigit; j++)
                {
                    for (int k = 1; k <= firstDigit; k++)
                    {
                        int multiplicationResult = i * j * k;
                        Console.WriteLine($"{i} * {j} * {k} = {multiplicationResult};");
                    }
                }
            }
        }
    }
}
