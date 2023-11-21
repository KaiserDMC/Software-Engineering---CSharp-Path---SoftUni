using System;
using System.Linq;

namespace ReverseArray
{
    public class Program
    {
        private static string[] _inputArray;

        public static void Main(string[] args)
        {
            _inputArray = Console.ReadLine().Split(' ').ToArray();

            Reverse(_inputArray, 0);
        }

        private static void Reverse(string[] array, int index)
        {
            if (index == _inputArray.Length / 2)
            {
                Console.WriteLine(string.Join(" ", array));
                return;
            }

            string temp = _inputArray[index];
            array[index] = _inputArray[_inputArray.Length - 1 - index];
            array[_inputArray.Length - 1 - index] = temp;

            Reverse(array, index + 1);
        }
    }
}