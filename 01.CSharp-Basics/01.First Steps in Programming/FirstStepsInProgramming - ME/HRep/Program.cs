using System;

namespace HRep
{
    class Program
    {
        static void Main(string[] args)
        {
            double x = double.Parse(Console.ReadLine());
            double y = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());

            //House wall dimentions 
            double frontWall = Math.Pow(x, 2) - (1.2 * 2);
            double backWall = Math.Pow(x, 2);
            double sideWall = (x * y) - (Math.Pow(1.5, 2));

            double totalWall = frontWall + backWall + (2 * sideWall);

            //House roof dimentions
            double roofTriangle = x * h / 2;
            double roofSquare = x * y;

            double totalRoof = roofTriangle * 2 + roofSquare * 2;

            //Paint calculations
            double greenPaint = 3.4;
            double redPaint = 4.3;
            double wallPaint = totalWall / greenPaint;
            double roofPaint = totalRoof / redPaint;

            Console.WriteLine($"{wallPaint:f2}");
            Console.WriteLine($"{roofPaint:f2}");
        }
    }
}
