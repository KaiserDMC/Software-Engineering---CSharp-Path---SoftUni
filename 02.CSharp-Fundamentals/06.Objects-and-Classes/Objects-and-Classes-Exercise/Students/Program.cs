using System;
using System.Collections.Generic;
using System.Linq;

namespace Students
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfStudents = int.Parse(Console.ReadLine());

            StudentCollection studentCollection = new StudentCollection();

            for (int i = 0; i < numberOfStudents; i++)
            {
                string[] commandTokens = Console.ReadLine().Split(" ").ToArray();
                Student student = new Student(commandTokens[0], commandTokens[1], double.Parse(commandTokens[2]));

                studentCollection.Students.Add(student);
            }

            List<Student> orderedStudents = studentCollection.Students.OrderByDescending(s => s.Grade).ToList();

            foreach (Student student in orderedStudents)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName}: {student.Grade:f2}");
            }
        }

        class Student
        {
            public Student(string firstName, string lastName, double grade)
            {
                this.FirstName = firstName;
                this.LastName = lastName;
                this.Grade = grade;
            }

            public string FirstName { get; set; }
            public string LastName { get; set; }
            public double Grade { get; set; }
        }

        class StudentCollection
        {
            public StudentCollection()
            {
                this.Students = new List<Student>();
            }

            public List<Student> Students { get; set; }
        }
    }
}
