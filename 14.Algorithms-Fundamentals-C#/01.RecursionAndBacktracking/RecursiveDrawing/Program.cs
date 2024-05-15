using System;

namespace RecursiveDrawing
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Drawing(n);
        }

        private static void Drawing(int count)
        {
            if (count <= 0)
            {
                return;
            }

            //Pre-Action
            Console.WriteLine(new string('*', count));
            // Recursive call
            Drawing(count - 1);
            // Post-Action
            Console.WriteLine(new string('#', count));
        }
    }
}