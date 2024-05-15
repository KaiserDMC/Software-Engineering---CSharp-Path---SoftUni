using System;
using System.Linq;

namespace CombinationsWithRepetition
{
    public class Program
    {
        private static string[] _elements;
        private static string[] _combinations;

        public static void Main(string[] args)
        {
            _elements = Console.ReadLine().Split(" ").ToArray();
            int k = int.Parse(Console.ReadLine());

            _combinations = new string[k];

            Combination(0, 0);
        }

        private static void Combination(int index, int start)
        {
            if (index >= _combinations.Length)
            {
                Console.WriteLine(string.Join(" ", _combinations));
                return;
            }

            for (int i = start; i < _elements.Length; i++)
            {
                _combinations[index] = _elements[i];
                Combination(index + 1, i);
            }
        }
    }
}