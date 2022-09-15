using System;

namespace PipesInPool
{
    class Program
    {
        static void Main(string[] args)
        {
            int volume = int.Parse(Console.ReadLine());
            int pipeOne = int.Parse(Console.ReadLine());
            int pipeTwo = int.Parse(Console.ReadLine());
            double hours = double.Parse(Console.ReadLine());

            double workPipeOne = pipeOne * hours;
            double workPipeTwo = pipeTwo * hours;
            double totalFlow = workPipeOne + workPipeTwo;

            if (volume >= totalFlow)
            {
                double totalPercentage = totalFlow / volume * 100;
                double totalFirstPipe = workPipeOne / totalFlow * 100;
                double totalSecondPipe = workPipeTwo / totalFlow * 100;

                Console.WriteLine($"The pool is {totalPercentage:f2}% full. Pipe 1: {totalFirstPipe:f2}%. Pipe 2: {totalSecondPipe:f2}%.") ;
            }
            else
            {
                double totalOverflow = totalFlow - volume;

                Console.WriteLine($"For {hours:f2} hours the pool overflows with {totalOverflow:f2} liters.");
            }
        }
    }
}
