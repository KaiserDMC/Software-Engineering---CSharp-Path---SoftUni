using System;
using System.Collections.Generic;
using System.Linq;

namespace Students
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<Student> studentsList = new List<Student>();

            while (input != "end")
            {
                string[] inputSeparation = input.Split(" ").ToArray();

                string firstName = inputSeparation[0];
                string lastName = inputSeparation[1];
                int age = int.Parse(inputSeparation[2]);
                string city = inputSeparation[3];

                Student student = new Student();

                student.FirstName = firstName;
                student.LastName = lastName;
                student.Age = age;
                student.HomeTown = city;

                studentsList.Add(student);

                input = Console.ReadLine();
            }

            string homeTown = Console.ReadLine();

            foreach (Student student in studentsList)
            {
                if (homeTown == student.HomeTown)
                {
                    Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
                }
            }
        }
    }

    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string HomeTown { get; set; }
    }
}
