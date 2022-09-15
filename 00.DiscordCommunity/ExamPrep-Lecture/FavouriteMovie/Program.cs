using System;

namespace FavouriteMovie
{
    class Program
    {
        static void Main(string[] args)
        {
            string movieName = Console.ReadLine();
            int movieCounter = 1;

            int moviePoints = 0;
            int maxMoviePoints = int.MinValue;
            string bestMovie = String.Empty;

            while (movieName != "STOP")
            {
                for (int i = 0; i < movieName.Length; i++)
                {
                    char currentLetter = movieName[i];
                    moviePoints += currentLetter;

                    if (char.IsUpper(currentLetter))
                    {
                        moviePoints -= movieName.Length;
                    }
                    else if (char.IsLower(currentLetter))
                    {
                        moviePoints -= 2 * movieName.Length;
                    }
                }

                if (moviePoints > maxMoviePoints)
                {
                    maxMoviePoints = moviePoints;
                    bestMovie = movieName;
                }

                moviePoints = 0;

                if (movieCounter >= 7)
                {
                    Console.WriteLine($"The limit is reached.");
                    break;
                }

                movieName = Console.ReadLine();
                movieCounter++;
            }

            Console.WriteLine($"The best movie for you is {bestMovie} with {maxMoviePoints} ASCII sum.");
        }
    }
}
