using System;

namespace PrintingTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int triangleEnd = int.Parse(Console.ReadLine());

            for (int i = 1; i <= triangleEnd; i++)
            {
                PrintTriangleLine(1, i);
            }

            for (int i = triangleEnd - 1; i >= 1; i--)
            {
                PrintTriangleLine(1, i);
            }
        }

        static void PrintTriangleLine(int triangleStart, int triangleEnd)
        {
            for (int i = triangleStart; i <= triangleEnd; i++)
            {
                Console.Write($"{i} ");

            }
            Console.WriteLine();
        }
    }
}
