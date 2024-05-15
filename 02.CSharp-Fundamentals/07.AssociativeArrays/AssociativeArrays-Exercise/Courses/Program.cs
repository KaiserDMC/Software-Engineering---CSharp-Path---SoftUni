using System;
using System.Collections.Generic;
using System.Linq;

namespace Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> studentsByProgrammingCourses = new Dictionary<string, List<string>>();

            while (true)
            {
                string[] courseAndStudent = Console.ReadLine().Split(" : ").ToArray();

                if (courseAndStudent[0] == "end")
                {
                    break;
                }

                string courseName = courseAndStudent[0];
                string studentName = courseAndStudent[1];

                if (!studentsByProgrammingCourses.ContainsKey(courseName))
                {
                    studentsByProgrammingCourses.Add(courseName, new List<string> { studentName });
                }
                else
                {
                    studentsByProgrammingCourses[courseName].Add(studentName);
                }
            }

            foreach (var VARIABLE in studentsByProgrammingCourses)
            {
                Console.WriteLine($"{VARIABLE.Key}: {VARIABLE.Value.Count}");

                foreach (string name in VARIABLE.Value)
                {
                    Console.WriteLine($"-- {name}");
                }
            }
        }
    }
}
