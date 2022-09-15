using System;

namespace SpecialNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            bool special = false;

            for (int i = 1111; i <= 9999; i++)
            {
                string specialNumber = i.ToString();

                for (int j = 0; j < specialNumber.Length; j++)
                {
                    int divider = int.Parse(specialNumber[j].ToString());

                    if (divider == 0)
                    {
                        special = false;
                        break;
                    }

                    if (number % divider == 0)
                    {
                        special = true;
                    }
                    else
                    {
                        special = false;
                        break;
                    }
                }

                if (special)
                {
                    Console.Write($"{specialNumber} ");
                }
            }
        }
    }
}
