using System;
using System.Linq;

namespace PermutationsWithoutRepetitions
{
    public class Program
    {
        private static string[] _elements;
        private static string[] _permutations;
        private static bool[] _usedElements;

        public static void Main(string[] args)
        {
            _elements = Console.ReadLine().Split(" ").ToArray();

            _permutations = new string[_elements.Length];
            _usedElements = new bool[_elements.Length];

            Permute(0);
        }

        private static void Permute(int index)
        {
            if (index >= _elements.Length)
            {
                Console.WriteLine(string.Join(" ", _permutations));
                return;
            }

            for (int i = 0; i < _elements.Length; i++)
            {
                if (!_usedElements[i])
                {
                    _usedElements[i] = true;
                    _permutations[i] = _elements[index];
                    Permute(index + 1);
                    _usedElements[i] = false;
                }
            }
        }
    }
}