using System;

namespace CenterPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            double basePointX = 0;
            double basePointY = 0;
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());

            double distance1 = DistancePointOne(x1, y1, basePointX, basePointY);
            double distance2 = DistancePointTwo(x2, y2, basePointX, basePointY);

            if (distance1 <= distance2)
            {
                Console.WriteLine($"({x1}, {y1})");
            }
            else
            {
                Console.WriteLine($"({x2}, {y2})");
            }
        }

        static double DistancePointOne(double x1, double y1, double basePointX, double basePointY)
        {
            double distance1 = ((basePointX - x1) * (basePointX - x1) + (basePointY - y1) * (basePointY - y1));

            return distance1;
        }

        static double DistancePointTwo(double x2, double y2, double basePointX, double basePointY)
        {
            double distance2 = ((basePointX - x2) * (basePointX - x2) + (basePointY - y2) * (basePointY - y2));

            return distance2;
        }
    }
}
