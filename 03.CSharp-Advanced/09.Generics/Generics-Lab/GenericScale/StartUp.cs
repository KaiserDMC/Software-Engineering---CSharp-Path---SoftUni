using System;

namespace GenericScale
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            EqualityScale<int> numbers = new EqualityScale<int>(6, 5);

            Console.WriteLine(numbers.AreEqual());
        }
    }
}