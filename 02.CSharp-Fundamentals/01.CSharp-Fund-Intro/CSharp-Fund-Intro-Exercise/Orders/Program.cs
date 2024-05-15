using System;

namespace Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int counter = 0;
            double sum = 0;
            double[] price = new double[n];

            while (counter < n)
            {
                double pricePerCapsule = double.Parse(Console.ReadLine());
                int days = int.Parse(Console.ReadLine());
                int capsule = int.Parse(Console.ReadLine());

                price[counter] = ((days * capsule) * pricePerCapsule);
                sum += price[counter];
                counter++;
            }

            for (int i = 0; i < counter; i++)
            {
                Console.WriteLine($"The price for the coffee is: ${price[i]:f2}");
            }

            Console.WriteLine($"Total: ${sum:f2}");
        }
    }
}
