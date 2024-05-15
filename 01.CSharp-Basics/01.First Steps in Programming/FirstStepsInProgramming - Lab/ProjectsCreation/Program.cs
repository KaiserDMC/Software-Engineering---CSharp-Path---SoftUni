using System;

namespace ProjectsCreation
{
    class Program
    {
        static void Main(string[] args)
        {
            string nameArchitect = Console.ReadLine();
            int projectNumber = int.Parse(Console.ReadLine());
            int time = projectNumber * 3;
            if (projectNumber > 100)
            {
                Console.WriteLine("The amount of projects cannot exceed 100!");
            }
            else
            {
                Console.WriteLine($"The architect {nameArchitect} will need {time} hours to complete {projectNumber} project/s.");
            }
        }
    }
}