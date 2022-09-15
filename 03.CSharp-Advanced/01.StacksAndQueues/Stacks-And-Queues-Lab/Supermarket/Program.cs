using System;
using System.Collections.Generic;

namespace Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Queue<string> customerQueue = new Queue<string>();

            while (input != "End")
            {
                if (input != "Paid")
                {
                    customerQueue.Enqueue(input);
                }
                else
                {
                    while (customerQueue.Count > 0)
                    {
                        Console.WriteLine(customerQueue.Dequeue());
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"{customerQueue.Count} people remaining.");
        }
    }
}
