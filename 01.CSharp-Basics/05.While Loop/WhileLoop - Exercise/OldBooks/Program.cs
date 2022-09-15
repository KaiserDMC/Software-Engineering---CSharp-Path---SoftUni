using System;

namespace OldBooks
{
    class Program
    {
        static void Main(string[] args)
        {
            string favouriteBook = Console.ReadLine();
            int counterBooks = 0;
            bool bookFound = false;

            do
            {
                string randomBook = Console.ReadLine();
                if (randomBook == favouriteBook)
                {
                    bookFound = true;
                    break;
                }
                else if (randomBook == "No More Books")
                {
                    break;
                }
                else
                {
                    counterBooks++;
                    continue;
                }

            } while (true);

            if (bookFound)
            {
                Console.WriteLine($"You checked {counterBooks} books and found it.");
            }
            else
            {
                Console.WriteLine($"The book you search is not here!");
                Console.WriteLine($"You checked {counterBooks} books.");
            }
        }
    }
}
