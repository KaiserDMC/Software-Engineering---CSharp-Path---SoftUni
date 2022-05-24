using System;

namespace Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            string ticketType = Console.ReadLine();
            int rows = int.Parse(Console.ReadLine());
            int columns = int.Parse(Console.ReadLine());

            double ticketPrice = 0;

            switch (ticketType)
            {
                case "Premiere":
                    ticketPrice = 12;
                    break;
                case "Normal":
                    ticketPrice = 7.5;
                    break;
                case "Discount":
                    ticketPrice = 5;
                    break;
            }

            double profit = rows * columns * ticketPrice;
            Console.WriteLine($"{profit:f2} leva");
        }
    }
}
