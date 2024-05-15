using System;
using System.Collections.Generic;
using System.Linq;

namespace FromLeftToRight
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            int sum = 0;

            for (int i = 0; i < input; i++)
            {
                string initialNumbers = Console.ReadLine();

                long[] splitNumbers = initialNumbers.Split().Select(long.Parse).ToArray();
                
                if (splitNumbers[0] >= splitNumbers[1])
                {
                    string biggerNumber = splitNumbers[0].ToString();
                    char[] individualDigits = biggerNumber.ToCharArray();

                    if (individualDigits[0] == (char)45)
                    {
                        for (int j = 1; j < biggerNumber.Length; j++)
                        {
                            int digit = Convert.ToInt32(individualDigits[j]) - 48;
                            sum += digit;
                        }
                    }
                    else
                    {
                        for (int j = 0; j < biggerNumber.Length; j++)
                        {
                            int digit = Convert.ToInt32(individualDigits[j]) - 48;
                            sum += digit;
                        }
                    }

                }
                else
                {
                    string biggerNumber = splitNumbers[1].ToString();
                    char[] individualDigits = biggerNumber.ToCharArray();

                    if (individualDigits[0] == (char)45)
                    {
                        for (int j = 1; j < biggerNumber.Length; j++)
                        {
                            int digit = Convert.ToInt32(individualDigits[j]) - 48;
                            sum += digit;
                        }
                    }
                    else
                    {
                        for (int j = 0; j < biggerNumber.Length; j++)
                        {
                            int digit = Convert.ToInt32(individualDigits[j]) - 48;
                            sum += digit;
                        }
                    }
                }

                Console.WriteLine(sum);
                sum = 0;
            }
        }
    }
}
