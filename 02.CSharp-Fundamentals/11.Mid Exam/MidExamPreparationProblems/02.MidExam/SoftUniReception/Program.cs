using System;

namespace SoftUniReception
{
    class Program
    {
        static void Main(string[] args)
        {
            int employeeOne = int.Parse(Console.ReadLine());
            int employeeTwo = int.Parse(Console.ReadLine());
            int employeeThree = int.Parse(Console.ReadLine());
            int studentCount = int.Parse(Console.ReadLine());

            int sumOfStudentsPerHour = employeeOne + employeeTwo + employeeThree;
            int hourCounter = 0;

            while (studentCount > 0)
            {
                studentCount -= sumOfStudentsPerHour;
                hourCounter++;

                if (hourCounter % 4 == 0)
                {
                    hourCounter++;
                }
            }

            Console.WriteLine($"Time needed: {hourCounter}h.");
        }
    }
}
