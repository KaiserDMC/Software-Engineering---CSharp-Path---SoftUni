using System;

namespace Travelling
{
    class Program
    {
        static void Main(string[] args)
        {
            string destination = Console.ReadLine();

            while (destination != "End")
            {
                double minimumBudget = double.Parse(Console.ReadLine());
                double leftToSave = 0;

                double sumSaved = double.Parse(Console.ReadLine());

                leftToSave += sumSaved;

                while (leftToSave < minimumBudget)
                {
                    sumSaved = double.Parse(Console.ReadLine());
                    leftToSave += sumSaved;
                }

                if (leftToSave >= minimumBudget)
                {
                    Console.WriteLine($"Going to {destination}!");
                }

                destination = Console.ReadLine();
            }
        }
    }
}
