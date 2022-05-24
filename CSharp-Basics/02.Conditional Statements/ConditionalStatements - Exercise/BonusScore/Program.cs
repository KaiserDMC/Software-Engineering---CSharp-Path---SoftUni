using System;

namespace BonusScore
{
    class Program
    {
        static void Main(string[] args)
        {
            int initialScore = int.Parse(Console.ReadLine());
            double bonusPoints = 0.0;
            double extraBonusPoints = 0.0;

            if (initialScore <= 100)
            {
                bonusPoints = 5;
            }
            else if (initialScore > 1000)
            {
                bonusPoints = initialScore * 0.1;
            }
            else
            {
                bonusPoints = initialScore * 0.2;
            }

            if (initialScore % 2 == 0)
            {
                extraBonusPoints = bonusPoints + 1;
            }
            else if (initialScore % 10 == 5)
            {
                extraBonusPoints = bonusPoints + 2;
            }
            else
            {
                extraBonusPoints = bonusPoints;
            }

            double totalScore = initialScore + extraBonusPoints;

            Console.WriteLine(extraBonusPoints);
            Console.WriteLine(totalScore);

        }
    }
}
