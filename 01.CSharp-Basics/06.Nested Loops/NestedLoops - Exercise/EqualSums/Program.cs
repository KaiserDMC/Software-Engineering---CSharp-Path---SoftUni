using System;

namespace EqualSums
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOne = int.Parse(Console.ReadLine());
            int numberTwo = int.Parse(Console.ReadLine());

            int sumOdd;
            int sumEven;

            for (int i = numberOne; i <= numberTwo; i++)
            {
                sumOdd = 0;
                sumEven = 0;

                string number = i.ToString();

                for (int j = 0; j < number.Length; j++)
                {
                    if (j % 2 == 0)
                    {
                        sumEven += number[j];
                    }
                    else
                    {
                        sumOdd += number[j];
                    }
                }

                if (sumEven == sumOdd)
                {
                    Console.Write(number + " ");
                }
            }
        }
    }
}
