using System;

namespace RecursiveFibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            int wantedNumber = int.Parse(Console.ReadLine());
            int[] arrayFibonacci = new int[wantedNumber];

            if (wantedNumber >= 2)
            {
                arrayFibonacci[0] = 1;
                arrayFibonacci[1] = 1;
                int outputNumber = 0;

                for (int i = 2; i < wantedNumber; i++)
                {
                    arrayFibonacci[i] = arrayFibonacci[i - 2] + arrayFibonacci[i - 1];
                    outputNumber = arrayFibonacci[i];
                }

                Console.WriteLine(outputNumber);
            }
            else
            {
                Console.WriteLine(wantedNumber);
            }
        }
    }
}
