using System;

namespace NumberPyramid
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int counter = 1;

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write(counter + " ");
                    counter++;

                    if (counter > n)
                    {
                        break;
                    }
                }
                Console.WriteLine();

                if (counter > n)
                {
                    break;
                }
            }
        }
    }
}
