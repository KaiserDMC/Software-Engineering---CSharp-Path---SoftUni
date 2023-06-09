using System;

namespace Balls
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int red = 0;
            int orange = 0;
            int yellow = 0;
            int white = 0;
            int black = 0;
            int other = 0;

            //int totalPoints = 0;
            double totalPoints = 0;

            for (int i = 1; i <= n; i++)
            {
                string color = Console.ReadLine();

                switch (color)
                {
                    case "red":
                        red++;
                        //red += 1;
                        //red = red + 1;
                        totalPoints += 5;
                        break;
                    case "orange":
                        orange++;
                        totalPoints += 10;
                        break;
                    case "yellow":
                        yellow++;
                        totalPoints += 15;
                        break;
                    case "white":
                        white++;
                        totalPoints += 20;
                        break;
                    case "black":
                        black++;
                        //totalPoints /= 2;
                        //totalPoints = totalPoints / 2;

                        totalPoints = Math.Floor(totalPoints / 2);
                        break;
                    default:
                        other++;
                        break;
                }
            }

            Console.WriteLine($"Total points: {totalPoints}");
            Console.WriteLine($"Red balls: {red}");
            Console.WriteLine($"Orange balls: {orange}");
            Console.WriteLine($"Yellow balls: {yellow}");
            Console.WriteLine($"White balls: {white}");
            Console.WriteLine($"Other colors picked: {other}");
            Console.WriteLine($"Divides from black balls: {black}");
        }
    }
}