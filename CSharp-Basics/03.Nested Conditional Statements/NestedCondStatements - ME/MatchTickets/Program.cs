using System;

namespace MatchTickets
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string category = Console.ReadLine();
            int fans = int.Parse(Console.ReadLine());

            double ticketPrice = 0;
            double transport = 0;

            if (fans >= 1 && fans <= 4)
            {
                transport = budget * 0.75;
            }
            else if (fans >= 5 && fans <= 9)
            {
                transport = budget * 0.6;
            }
            else if (fans >= 10 && fans <= 24)
            {
                transport = budget * 0.5;
            }
            else if (fans >= 25 && fans <= 49)
            {
                transport = budget * 0.4;
            }
            else if (fans >= 50)
            {
                transport = budget * 0.25;
            }

            switch (category)
            {
                case "VIP":
                    ticketPrice = 499.99;
                    break;
                case "Normal":
                    ticketPrice = 249.99;
                    break;
            }

            double combinedTickets = fans * ticketPrice;
            double fullTrip = combinedTickets + transport;

            double difference = fullTrip - budget;
            bool enough = difference > 0;

            if (!enough)
            {
                Console.WriteLine($"Yes! You have {Math.Abs(difference):f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {Math.Abs(difference):f2} leva.");
            }

        }
    }
}
