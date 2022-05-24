using System;

namespace ChallengeWedding
{
    class Program
    {
        static void Main(string[] args)
        {
            int amountMale = int.Parse(Console.ReadLine());
            int amountFemale = int.Parse(Console.ReadLine());
            int maxTables = int.Parse(Console.ReadLine());

            int count = 0;
            bool noMoreTables = false;

            for (int i = 1; i <= amountMale; i++)
            {
                for (int j = 1; j <= amountFemale; j++)
                {
                    count++;

                    if (count > maxTables)
                    {
                        noMoreTables = true;
                        break;
                    }

                    Console.Write($"({i} <-> {j}) ");
                }

                if (noMoreTables)
                {
                    break;
                }
            }
        }
    }
}
