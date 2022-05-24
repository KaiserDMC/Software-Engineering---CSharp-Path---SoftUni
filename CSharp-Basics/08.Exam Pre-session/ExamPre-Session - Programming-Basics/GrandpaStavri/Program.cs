using System;

namespace GrandpaStavri
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input and Calculations
            int daysBrewing = int.Parse(Console.ReadLine());

            double totalAmountRakija = 0;
            double totalDegreesRakija = 0;

            for (int i = 0; i < daysBrewing; i++)
            {
                double amountRakija = double.Parse(Console.ReadLine());
                double degreesRakija = double.Parse(Console.ReadLine());

                totalAmountRakija += amountRakija;
                totalDegreesRakija += degreesRakija * amountRakija;
            }

            totalDegreesRakija = totalDegreesRakija / totalAmountRakija;

            //Output
            Console.WriteLine($"Liter: {totalAmountRakija:F2}");
            Console.WriteLine($"Degrees: {totalDegreesRakija:F2}");

            if (totalDegreesRakija < 38)
            {
                Console.WriteLine($"Not good, you should baking!");
            }
            else if (totalDegreesRakija >= 38 && totalDegreesRakija <= 42)
            {
                Console.WriteLine($"Super!");
            }
            else if (totalDegreesRakija > 42)
            {
                Console.WriteLine($"Dilution with distilled water!");
            }
        }
    }
}
