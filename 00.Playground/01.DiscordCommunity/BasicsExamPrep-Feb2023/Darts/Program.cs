using System;

namespace Darts
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string nameOfPlayer = Console.ReadLine();
            int initialScore = 301;

            int points = 0;
            int numberOfShots = 0;
            int missedShots = 0;

            string field = String.Empty;

            while ((field = Console.ReadLine()) != "Retire")
            {
                points = int.Parse(Console.ReadLine());

                switch (field)
                {
                    case "Single":

                        if (points <= initialScore)
                        {
                            initialScore -= points;
                            numberOfShots++;
                        }
                        else
                        {
                            missedShots++;
                        }
                        
                        break;
                    case "Double":

                        points *= 2;
                        // points = points * 2;

                        if (points <= initialScore)
                        {
                            initialScore -= points;
                            numberOfShots++;
                        }
                        else
                        {
                            missedShots++;
                        }

                        break;
                    case "Triple":

                        points *= 3;
                        // points = points * 3;

                        if (points <= initialScore)
                        {
                            initialScore -= points;
                            numberOfShots++;
                        }
                        else
                        {
                            missedShots++;
                        }

                        break;
                }

                if (initialScore == 0)
                {
                    break;
                }
            }

            if (field == "Retire")
            {
                Console.WriteLine($"{nameOfPlayer} retired after {missedShots} unsuccessful shots.");
            }

            if (initialScore == 0)
            {
                Console.WriteLine($"{nameOfPlayer} won the leg with {numberOfShots} shots.");
            }
        }
    }
}
