using System;

namespace Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            int students = int.Parse(Console.ReadLine());

            int topStudentCount = 0;
            int goodStudentCount = 0;
            int lowStudentCount = 0;
            int failStudentCount = 0;
            double average = 0;

            for (int i = 0; i < students; i++)
            {
                double grade = double.Parse(Console.ReadLine());

                if (grade < 3)
                {
                    failStudentCount++;
                }
                else if (grade >= 3 && grade < 4)
                {
                    lowStudentCount++;
                }
                else if (grade >= 4 && grade < 5)
                {
                    goodStudentCount++;
                }
                else if (grade >= 5)
                {
                    topStudentCount++;
                }

                average += grade;
            }

            double topStudentPercentage = (double)topStudentCount / students * 100;
            double goodStudentPercentage = (double)goodStudentCount / students * 100;
            double lowStudentPercentage = (double)lowStudentCount / students * 100;
            double failStudentPercentage = (double)failStudentCount / students * 100;
            double averageGrade = average / students;

            Console.WriteLine($"Top students: {topStudentPercentage:f2}%");
            Console.WriteLine($"Between 4.00 and 4.99: {goodStudentPercentage:f2}%");
            Console.WriteLine($"Between 3.00 and 3.99: {lowStudentPercentage:f2}%");
            Console.WriteLine($"Fail: {failStudentPercentage:f2}%");
            Console.WriteLine($"Average: {averageGrade:f2}");
        }
    }
}
