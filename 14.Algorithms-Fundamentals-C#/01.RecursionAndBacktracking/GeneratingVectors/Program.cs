using System;

namespace GeneratingVectors
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] vector = new int[n];

            Generate(0, vector);
        }

        private static void Generate(int i, int[] vector)
        {
            if (i >= vector.Length)
            {
                Console.WriteLine(string.Join("", vector));
                return;
            }

            for (int j = 0; j < 2; j++)
            {
                vector[i] = j;
                Generate(i + 1, vector);
            }
        }
    }
}