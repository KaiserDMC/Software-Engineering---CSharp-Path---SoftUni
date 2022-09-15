using System;

namespace StudentInformation
{
    class Program
    {
        static void Main(string[] args)
        {
            string studentName = Console.ReadLine();
            int studentAge = int.Parse(Console.ReadLine());
            double averageGrade = double.Parse(Console.ReadLine());

            Console.WriteLine($"Name: {studentName}, Age: {studentAge}, Grade: {averageGrade:f2}");
        }
    }
}
