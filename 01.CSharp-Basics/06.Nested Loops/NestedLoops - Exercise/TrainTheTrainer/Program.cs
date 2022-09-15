using System;

namespace TrainTheTrainer
{
    class Program
    {
        static void Main(string[] args)
        {
            int judges = int.Parse(Console.ReadLine());
            string presentationName = Console.ReadLine();

            double sumAverages = 0;
            int taskCounter = 0;

            do
            {
                double averageGrade = 0;

                for (int i = 0; i < judges; i++)
                {
                    double grade = double.Parse(Console.ReadLine());

                    averageGrade += grade;
                }

                averageGrade /= judges;
                sumAverages += averageGrade;

                Console.WriteLine($"{presentationName} - {averageGrade:F2}.");

                presentationName = Console.ReadLine();
                taskCounter++;

            } while (presentationName != "Finish");

            if (presentationName == "Finish")
            {
                Console.WriteLine($"Student's final assessment is {(sumAverages / taskCounter):F2}.");
            }
        }
    }
}
