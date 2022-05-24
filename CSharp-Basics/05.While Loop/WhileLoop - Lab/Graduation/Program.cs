using System;

namespace Graduation
{
    class Program
    {
        static void Main(string[] args)
        {
            string studentName = Console.ReadLine();

            double averageGrade = 0;
            int counterGrade = 0;
            int counterFail = 0;

            do
            {
                ++counterGrade;
                double grade = double.Parse(Console.ReadLine());

                if (grade < 4)
                {
                    counterFail++;
                }

                if (counterFail > 1)
                {
                    Console.WriteLine($"{studentName} has been excluded at {counterGrade - 1} grade");
                    break;
                }
                else
                {
                    averageGrade += grade;
                }
            } while (counterGrade < 12);

            averageGrade /= counterGrade;

            if (counterFail > 1)
            {

            }
            else
            {
                Console.WriteLine($"{studentName} graduated. Average grade: {averageGrade:f2}");
            }

        }
    }
}
