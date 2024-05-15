using System;

namespace LongerLine
{
    class Program
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());
            double x1_1 = double.Parse(Console.ReadLine());
            double y1_1 = double.Parse(Console.ReadLine());
            double x2_1 = double.Parse(Console.ReadLine());
            double y2_1 = double.Parse(Console.ReadLine());

            LongestLine(x1, y1, x2, y2, x1_1, y1_1, x2_1, y2_1);
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

        static void LongestLine(double x1, double y1, double x2, double y2, double x1_1, double y1_1, double x2_1, double y2_1)
        {
            double basePointX = 0;
            double basePointY = 0;

            double distanceLine1 = ((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));
            double distanceLine2 = ((x1_1 - x2_1) * (x1_1 - x2_1) + (y1_1 - y2_1) * (y1_1 - y2_1));

            if (distanceLine1 >= distanceLine2)
            {
                double distancePoint1 = DistancePointOne(x1, y1, basePointX, basePointY);
                double distancePoint2 = DistancePointTwo(x2, y2, basePointX, basePointY);

                if (distancePoint1 <= distancePoint2)
                {
                    Console.WriteLine($"({x1}, {y1})({x2}, {y2})");
                }
                else
                {
                    Console.WriteLine($"({x2}, {y2})({x1}, {y1})");
                }
            }
            else
            {
                double distancePoint1 = DistancePointOne(x1_1, y1_1, basePointX, basePointY);
                double distancePoint2 = DistancePointTwo(x2_1, y2_1, basePointX, basePointY);

                if (distancePoint1 <= distancePoint2)
                {
                    Console.WriteLine($"({x1_1}, {y1_1})({x2_1}, {y2_1})");
                }
                else
                {
                    Console.WriteLine($"({x2_1}, {y2_1})({x1_1}, {y1_1})");
                }
            }
        }
    }
}
