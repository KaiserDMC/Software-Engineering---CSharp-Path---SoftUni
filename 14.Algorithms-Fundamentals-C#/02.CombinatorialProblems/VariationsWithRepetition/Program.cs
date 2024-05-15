using System;
using System.Linq;

namespace VariationsWithRepetition
{
    public class Program
    {
        private static string[] _elements;
        private static string[] _variations;

        public static void Main(string[] args)
        {
            _elements = Console.ReadLine().Split(" ").ToArray();
            int k = int.Parse(Console.ReadLine());

            _variations = new string[k];

            Variation(0);
        }

        private static void Variation(int index)
        {
            if (index >= _variations.Length)
            {
                Console.WriteLine(string.Join(" ", _variations));
                return;
            }

            for (int i = 0; i < _elements.Length; i++)
            {
                _variations[index] = _elements[i];
                Variation(index + 1);
            }
        }
    }
}