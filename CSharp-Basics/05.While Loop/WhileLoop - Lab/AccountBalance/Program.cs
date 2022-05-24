using System;

namespace AccountBalance
{
    class Program
    {
        static void Main(string[] args)
        {
            string programEnd = Console.ReadLine();
            double money = 0;
            double number = 0;
            do
            {
                if (double.Parse(programEnd) < 0)
                {
                    Console.WriteLine("Invalid operation!");
                    break;
                }
                else
                {
                    number = double.Parse(programEnd);
                    money += number;
                    Console.WriteLine($"Increase: {number:f2}");
                    programEnd = Console.ReadLine();
                }
            } while (programEnd != "NoMoreMoney");

            Console.WriteLine($"Total: {money:f2}");
        }
    }
}
