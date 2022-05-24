using System;

namespace ExamPreparation
{
    class Program
    {
        static void Main(string[] args)
        {
            int allowedBadGrades = int.Parse(Console.ReadLine());
            string input = string.Empty;
            int counterBadGrades = 0;
            int allTasks = 0;
            double averagGrade = 0;
            bool stopped = false;

            do
            {

                string taskName = Console.ReadLine();

                if (taskName != "Enough")
                {
                    allTasks++;
                    input = taskName;
                }
                else
                {
                    stopped = true;
                    break;
                }

                int taskGrade = int.Parse(Console.ReadLine());

                if (taskGrade <= 4)
                {
                    counterBadGrades++;
                }

                if (counterBadGrades == allowedBadGrades)
                {
                    Console.WriteLine($"You need a break, {counterBadGrades} poor grades.");
                    break;
                }

                averagGrade += taskGrade;

            } while (counterBadGrades < allowedBadGrades);

            averagGrade /= allTasks;

            if (stopped)
            {
                Console.WriteLine($"Average score: {averagGrade:f2}");
                Console.WriteLine($"Number of problems: {allTasks}");
                Console.WriteLine($"Last problem: {input}");
            }
        }
    }
}
