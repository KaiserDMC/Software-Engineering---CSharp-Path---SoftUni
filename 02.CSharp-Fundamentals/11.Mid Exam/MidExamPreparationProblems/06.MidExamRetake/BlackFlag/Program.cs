using System;

namespace BlackFlag
{
    class Program
    {
        static void Main(string[] args)
        {
            int daysPirating = int.Parse(Console.ReadLine());
            double plunderForOneDay = double.Parse(Console.ReadLine());
            double expectedPlunderAtEnd = double.Parse(Console.ReadLine());

            double sumPlunder = 0;

            for (int i = 1; i <= daysPirating; i++)
            {
                sumPlunder += plunderForOneDay;

                if (i % 3 == 0)
                {
                    sumPlunder += 0.5 * plunderForOneDay;
                }

                if (i % 5 == 0)
                {
                    sumPlunder -= 0.3 * sumPlunder;
                }
            }

            if (sumPlunder >= expectedPlunderAtEnd)
            {
                Console.WriteLine($"Ahoy! {sumPlunder:f2} plunder gained.");
            }
            else
            {
                Console.WriteLine($"Collected only {(sumPlunder / expectedPlunderAtEnd) * 100:f2}% of the plunder.");
            }
        }
    }
}
