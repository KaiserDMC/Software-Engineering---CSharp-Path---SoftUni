using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cinema
{
    public class Program
    {
        private static List<string> _friends;
        private static string[] _combinations;
        private static bool[] _fixedPositions;

        public static void Main(string[] args)
        {
            _friends = Console.ReadLine().Split(", ").ToList();
            _combinations = new string[_friends.Count];
            _fixedPositions = new bool[_friends.Count];

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "generate")
                {
                    break;
                }

                string[] tokens = input.Split(" - ").ToArray();
                string name = tokens[0];
                int position = int.Parse(tokens[1]);

                _combinations[position - 1] = name;
                _fixedPositions[position - 1] = true;

                _friends.Remove(name);
            }

            GenerateCombinations(0);
        }

        private static void GenerateCombinations(int index)
        {
            if (index >= _friends.Count)
            {
                PrintResult();

                return;
            }

            GenerateCombinations(index + 1);

            for (int i = index + 1; i < _friends.Count; i++)
            {
                Swap(index, i);
                GenerateCombinations(index + 1);
                Swap(index, i);
            }
        }

        private static void Swap(int first, int second)
        {
            string temp = _friends[first];
            _friends[first] = _friends[second];
            _friends[second] = temp;
        }

        private static void PrintResult()
        {
            int index = 0;
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < _combinations.Length; i++)
            {
                if (_fixedPositions[i])
                {
                    sb.Append($"{_combinations[i]} ");
                }
                else
                {
                    sb.Append($"{_friends[index++]} ");
                }
            }

            Console.WriteLine(sb.ToString().Trim());
        }
    }
}