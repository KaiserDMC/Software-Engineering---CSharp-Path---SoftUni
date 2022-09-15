using System;

namespace WeddingSeats
{
    class Program
    {
        static void Main(string[] args)
        {
            char lastSector = char.Parse(Console.ReadLine());
            int rowsFirstSector = int.Parse(Console.ReadLine());
            int seatsOddRow = int.Parse(Console.ReadLine());

            int counter = 0;

            for (int i = 'A'; i <= lastSector; i++)
            {
                for (int row = 1; row <= rowsFirstSector; row++)
                {
                    if (row % 2 == 0)
                    {
                        for (int k = 1; k <= seatsOddRow + 2; k++)
                        {
                            Console.WriteLine($"{(char)i}{row}{(char)(96 + k)}");
                            counter++;
                        }
                    }
                    else
                    {
                        for (int k = 1; k <= seatsOddRow; k++)
                        {
                            Console.WriteLine($"{(char)i}{row}{(char)(96 + k)}");
                            counter++;
                        }
                    }
                }

                rowsFirstSector += 1;
            }

            Console.WriteLine(counter);
        }
    }
}
