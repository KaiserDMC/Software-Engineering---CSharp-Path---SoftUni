using System;

namespace AreaOfFigures
{
    class Program
    {
        static void Main(string[] args)
        {
            string figure = Console.ReadLine();
            double area = 0;

            if (figure == "square")
            {
                double a = double.Parse(Console.ReadLine());
                area = Math.Pow(a, 2);                
            }
            else if (figure == "rectangle")
            {
                double a = double.Parse(Console.ReadLine());
                double b = double.Parse(Console.ReadLine());
                area = a * b;
            }
            else if (figure == "circle")
            {
                double r = double.Parse(Console.ReadLine());
                area = Math.Pow(r, 2) * Math.PI;                
            }
            else if (figure == "triangle")
            {
                double a = double.Parse(Console.ReadLine());
                double h = double.Parse(Console.ReadLine());
                area = a * h / 2;                
            }

            Console.WriteLine($"{area:f3}");
        }
    }
}
