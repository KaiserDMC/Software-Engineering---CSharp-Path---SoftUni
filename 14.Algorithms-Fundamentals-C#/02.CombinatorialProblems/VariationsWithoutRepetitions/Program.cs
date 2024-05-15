using System;
using System.Linq;

namespace VariationsWithoutRepetitions
{
    public class Program
    {
        private static string[] _elements;
        private static string[] _variations;
        private static bool[] _usedElements;

        public static void Main(string[] args)
        {
            _elements = Console.ReadLine().Split(" ").ToArray();
            int k = int.Parse(Console.ReadLine());

            _variations = new string[k];
            _usedElements = new bool[_elements.Length];

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
                if (!_usedElements[i])
                {
                    _usedElements[i] = true;
                    _variations[index] = _elements[i];
                    Variation(index + 1);
                    _usedElements[i] = false;
                }
            }
        }
    }
}