using System;
using System.Linq;
using System.Collections.Generic;

namespace MultiplyEvensByOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();
            List<int> evenDigits = new List<int>();
            List<int> oddDigits = new List<int>();
            bool negative = false;

            for (int i = 0; i < number.Length; i++)
            {
                if (number[i] == (char)45)
                {
                    negative = true;
                }

                if (negative)
                {
                    i++;
                    if (number[i] % 2 == 0)
                    {
                        evenDigits.Add(number[i] - 48);
                    }
                    else
                    {
                        oddDigits.Add(number[i] - 48);
                    }
                }
                else
                {
                    if (number[i] % 2 == 0)
                    {
                        evenDigits.Add(number[i] - 48);
                    }
                    else
                    {
                        oddDigits.Add(number[i] - 48);
                    }
                }

                negative = false;
            }

            int sumEven = GetSumOfEvenDigits(evenDigits);
            int sumOdd = GetSumOfOddDigits(oddDigits);

            int result = GetMultipleOfEvenAndOdds(sumEven, sumOdd);
            Console.WriteLine(result);
        }

        static int GetMultipleOfEvenAndOdds(int sumEven, int sumOdd)
        {
            return sumEven * sumOdd;
        }

        static int GetSumOfEvenDigits(List<int> evenDigits)
        {
            List<int> digits = evenDigits.ToList();
            int sumEven = digits.Sum();

            return sumEven;

        }

        static int GetSumOfOddDigits(List<int> oddDigits)
        {
            List<int> digits = oddDigits.ToList();
            int sumOdd = digits.Sum();

            return sumOdd;
        }
    }
}
