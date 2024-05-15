using System;

namespace SumDigits
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            int sum = 0;
            string numberToString = number.ToString();
            char[] individualDigits = numberToString.ToCharArray();

            for (int i = 0; i < numberToString.Length; i++)
            {
                int digit = Convert.ToInt32(individualDigits[i]) - 48;
                sum += digit;
            }

            Console.WriteLine(sum);
        }
    }
}
