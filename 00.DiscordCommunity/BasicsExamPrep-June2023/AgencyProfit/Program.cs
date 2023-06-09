using System;

namespace AgencyProfit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string airline = Console.ReadLine();
            int ticketsAdults = int.Parse(Console.ReadLine());
            int ticketsChild = int.Parse(Console.ReadLine());
            double grossPrice = double.Parse(Console.ReadLine());
            double tax = double.Parse(Console.ReadLine());

            double childTicketPrice = (1 - 0.7) * grossPrice;
            childTicketPrice += tax;
            //double childTicketPrice = 0.3 * grossPrice;

            grossPrice += tax;
            //grossPrice = grossPrice + tax;

            double totalTicketPrice = ticketsAdults * grossPrice + ticketsChild * childTicketPrice;

            double profit = 0.2 * totalTicketPrice;

            Console.WriteLine($"The profit of your agency from {airline} tickets is {profit:f2} lv.");
        }
    }
}