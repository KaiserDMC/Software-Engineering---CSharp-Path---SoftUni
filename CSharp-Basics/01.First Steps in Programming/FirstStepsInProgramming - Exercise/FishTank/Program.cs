using System;

namespace FishTank
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            double percentage = double.Parse(Console.ReadLine());

            int volume = length * width * height;
            double volumeInLitres = (double)volume / 1000;
            double totalLitres = volumeInLitres * (1 - percentage / 100);

            Console.WriteLine(totalLitres);
        }
    }
}
