using System;

namespace Salary
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int salary = int.Parse(Console.ReadLine());

            int salaryPenalty = 0;


            for (int i = 1; i <= n; i++)
            {
                string websites = Console.ReadLine();
                switch (websites)
                {
                    case "Facebook":
                        salaryPenalty += 150;
                        break;
                    case "Instagram":
                        salaryPenalty += 100;
                        break;
                    case "Reddit":
                        salaryPenalty += 50;
                        break;
                }

                if (salaryPenalty >= salary)
                {
                    Console.WriteLine("You have lost your salary.");
                    break;
                }
            }

            int difference = salary - salaryPenalty;
            if (salaryPenalty < salary)
            {
                Console.WriteLine(difference);
            }
        }
    }
}
