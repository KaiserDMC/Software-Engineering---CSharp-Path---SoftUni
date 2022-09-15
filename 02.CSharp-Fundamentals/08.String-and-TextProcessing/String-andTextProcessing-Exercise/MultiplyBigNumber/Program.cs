using System;
using System.Linq;
using System.Text;

namespace MultiplyBigNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstNumber = Console.ReadLine();
            int secondNumber = int.Parse(Console.ReadLine());

            int remainder = 0;

            StringBuilder stringOfNumber = new StringBuilder();

            for (int i = firstNumber.Length - 1; i >= 0; i--)
            {
                int sum = (int.Parse(firstNumber[i].ToString()) * secondNumber) + remainder;

                stringOfNumber.Append(sum % 10);

                remainder = sum / 10;
            }

            if (remainder != 0)
            {
                stringOfNumber.Append(remainder);
            }

            if (secondNumber == 0)
            {
                Console.WriteLine($"{0}");
            }
            else
            {
                Console.WriteLine(string.Join("", stringOfNumber.ToString().Reverse()));
            }
        }
    }
}
