using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentAcademy
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> studentGradesByNames = new Dictionary<string, List<double>>();

            int numberOfStudents = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfStudents; i++)
            {
                string studentName = Console.ReadLine();
                double studentGrade = double.Parse(Console.ReadLine());

                if (!studentGradesByNames.ContainsKey(studentName))
                {
                    studentGradesByNames.Add(studentName, new List<double> { studentGrade });
                }
                else
                {
                    studentGradesByNames[studentName].Add(studentGrade);
                }
            }

            foreach (var student in studentGradesByNames.Where(s => s.Value.Average() >= 4.5))
            {
                Console.WriteLine($"{student.Key} -> {student.Value.Average():f2}");
            }
        }
    }
}
