using System;
using System.Collections.Generic;
using System.Linq;

namespace BonusScoringSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfStudents = int.Parse(Console.ReadLine());
            int numberOfLectures = int.Parse(Console.ReadLine());
            int additionalBonus = int.Parse(Console.ReadLine());

            int[] attendance = new int[numberOfStudents];

            for (int i = 0; i < numberOfStudents; i++)
            {
                attendance[i] = int.Parse(Console.ReadLine());
            }

            int bestLecture = 0;
            if (attendance.Length > 0)
            {
                bestLecture = attendance.Max();
            }

            double maxPoints = 0;
            if (numberOfLectures != 0)
            {
                maxPoints = ((double)bestLecture / (double)numberOfLectures) * (5 + additionalBonus);
                maxPoints = Math.Ceiling(maxPoints);
            }

            Console.WriteLine($"Max Bonus: {maxPoints}.");
            Console.WriteLine($"The student has attended {bestLecture} lectures.");
        }
    }
}
