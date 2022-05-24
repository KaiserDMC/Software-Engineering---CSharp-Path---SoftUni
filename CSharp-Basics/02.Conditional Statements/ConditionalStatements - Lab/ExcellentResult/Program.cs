using System;

namespace ExcellentResult
{
    class Program
    {
        static void Main(string[] args)
        {
            double grade = double.Parse(Console.ReadLine());

            bool isExcellent = grade >= 5.5;

            if(!isExcellent)
            {

            }
            else
            {
                Console.WriteLine("Excellent!");
            }
        }
    }
}
