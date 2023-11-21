using System;

namespace NestedLoops
{
    public class Program
    {
        private static string[] _outputStrings;
        
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            
            _outputStrings = new string[n];
            
            PermuteToNestedLoop(0, _outputStrings);
        }

        private static void PermuteToNestedLoop(int index, string[] vector)
        {
            if (index >= vector.Length)
            {
                Console.WriteLine(string.Join(" ", vector));
                return;
            }
            
            for (int i = 1; i <= vector.Length; i++)
            {
                vector[index] = i.ToString();
                PermuteToNestedLoop(index + 1, vector);
            }
        }
    }
}