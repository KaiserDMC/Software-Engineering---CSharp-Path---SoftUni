using System;
using System.Collections.Generic;
using System.Linq;

namespace BonusScoringSystemWithLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfStudents = int.Parse(Console.ReadLine());
            int numberOfLectures = int.Parse(Console.ReadLine());
            int additionalBonus = int.Parse(Console.ReadLine());

            double[] attendance = new double[numberOfStudents];
            List<double> maxBonusPointsList = new List<double>();
            double maxPts = 0;
            for (int i = 0; i < numberOfStudents; i++)
            {
                attendance[i] = int.Parse(Console.ReadLine());
                maxPts = (double)(attendance[i] / numberOfLectures) * (5 + additionalBonus);
                maxBonusPointsList.Add(maxPts);
            }



            if (numberOfLectures != 0 && attendance.Length > 0)
            {
                var maxPoints = maxBonusPointsList.OrderByDescending(x => x).Take(1);
                double maxAttendance = attendance[maxBonusPointsList.IndexOf(maxPoints.ElementAt(0))];

                Console.WriteLine($"Max Bonus: {Math.Ceiling(maxPoints.ElementAt(0))}.");
                Console.WriteLine($"The student has attended {maxAttendance} lectures.");
            }
            else
            {
                Console.WriteLine($"Max Bonus: {0}.");
                Console.WriteLine($"The student has attended {0} lectures.");
            }
        }
    }
}