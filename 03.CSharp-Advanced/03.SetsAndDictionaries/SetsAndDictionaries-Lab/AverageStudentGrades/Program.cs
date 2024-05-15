using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.Linq;

namespace AverageStudentGrades
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<decimal>> studentGrades = new Dictionary<string, List<decimal>>();

            int inputCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < inputCount; i++)
            {
                string[] currentGrade = Console.ReadLine().Split(" ").ToArray();

                string studentName = currentGrade[0];
                decimal grade = decimal.Parse(currentGrade[1]);

                if (!studentGrades.ContainsKey(studentName))
                {
                    studentGrades.Add(studentName,new List<decimal>());
                }

                studentGrades[studentName].Add(grade);
            }

            foreach (var student in studentGrades)
            {
                Console.Write($"{student.Key} -> ");
                student.Value.ForEach(x => Console.Write($"{x:f2} "));
                Console.WriteLine($"(avg: {student.Value.Average():f2})");
            }
        }
    }
}
