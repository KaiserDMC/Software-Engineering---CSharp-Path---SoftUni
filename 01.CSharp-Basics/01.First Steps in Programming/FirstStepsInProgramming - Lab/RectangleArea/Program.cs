using System;

namespace RectangleArea
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());

            int area = a * b;
            Console.WriteLine(area);
        }
    }
}