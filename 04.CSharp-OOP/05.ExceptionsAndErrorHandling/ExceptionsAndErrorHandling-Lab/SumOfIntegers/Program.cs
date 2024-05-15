using System;
using System.Collections.Generic;
using System.Linq;

namespace SumOfIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] userInputs = Console.ReadLine().Split(" ").ToArray();

            List<int> validNumbers = new List<int>();

            for (int i = 0; i < userInputs.Length; i++)
            {
                try
                {
                    validNumbers.Add(ValidInteger(userInputs[i]));
                }
                catch (FormatException fe)
                {
                    Console.WriteLine(fe.Message);
                }
                catch (OverflowException oe)
                {
                    Console.WriteLine(oe.Message);
                }
                finally
                {
                    Console.WriteLine($"Element '{userInputs[i]}' processed - current sum: {validNumbers.Sum()}");
                }
            }

            Console.WriteLine($"The total sum of all integers is: {validNumbers.Sum()}");
        }

        public static int ValidInteger(string number)
        {
            int currentNumber;
            try
            {
                currentNumber = int.Parse(number);
            }
            catch (FormatException)
            {
                throw new FormatException($"The element '{number}' is in wrong format!");
            }
            catch (OverflowException)
            {
                throw new OverflowException($"The element '{number}' is out of range!");
            }

            return currentNumber;
        }
    }
}
