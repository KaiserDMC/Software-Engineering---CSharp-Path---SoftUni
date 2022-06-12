using System;

namespace TribonacciSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            string result = TribonacciSequence(number);

            Console.WriteLine(result);
        }

        static string TribonacciSequence(int num)
        {
            int[] sequence = new int[num];
            int countStop = 0;
            string finalString = string.Empty;

            if (sequence.Length == 1)
            {
                sequence[0] = 1;
                finalString = sequence[0].ToString();
            }
            else if (sequence.Length == 2)
            {
                sequence[0] = 1;
                sequence[1] = 1;
                finalString = sequence[0].ToString() + " " + sequence[1].ToString();
            }
            else
            {
                for (int i = 0; i < sequence.Length; i++)
                {
                    if (i == 0 || i == 1)
                    {
                        sequence[i] = 1;
                    }

                    if (countStop == 2)
                    {
                        sequence[i] = 2;
                    }

                    if (countStop > 2)
                    {
                        sequence[i] = sequence[i - 1] + sequence[i - 2] + sequence[i - 3];
                    }
                    countStop++;
                }
            }

            finalString = string.Join(" ", sequence);

            return finalString;
        }
    }
}
