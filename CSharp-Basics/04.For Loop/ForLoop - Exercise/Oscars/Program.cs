using System;

namespace Oscars
{
    class Program
    {
        static void Main(string[] args)
        {
            string actorName = Console.ReadLine();
            double academyPoints = double.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());

            double totalJudgeScore = 0;

            for (int i = 1; i <= n; i++)
            {
                string judgeName = Console.ReadLine();
                double judgePoints = double.Parse(Console.ReadLine());

                totalJudgeScore = judgeName.Length * judgePoints / 2;
                academyPoints += totalJudgeScore;

                if (academyPoints >= 1250.5)
                {
                    Console.WriteLine($"Congratulations, {actorName} got a nominee for leading role with {academyPoints:f1}!");
                    break;
                }
            }

            if (academyPoints < 1250.5)
            {
                Console.WriteLine($"Sorry, {actorName} you need {1250.5 - academyPoints:f1} more!");
            }
        }
    }
}
