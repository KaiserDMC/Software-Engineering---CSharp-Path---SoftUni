using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace PermutationsWithRepetitions
{
    public class Program
    {
        private static string[] _elements;

        public static void Main(string[] args)
        {
            _elements = Console.ReadLine().Split(" ");

            Permute(0);
        }

        private static void Permute(int index)
        {
            if (index >= _elements.Length)
            {
                Console.WriteLine(string.Join(" ", _elements));
                return;
            }

            Permute(index + 1);

            var tempSet = new HashSet<string>() { _elements[index] };

            for (int i = index + 1; i < _elements.Length; i++)
            {
                if (!tempSet.Contains(_elements[i]))
                {
                    Swap(index, i);
                    Permute(index + 1);
                    Swap(index, i);

                    tempSet.Add(_elements[i]);
                }
            }
        }

        private static void Swap(int index, int i)
        {
            var temp = _elements[index];
            _elements[index] = _elements[i];
            _elements[i] = temp;
        }
    }
}