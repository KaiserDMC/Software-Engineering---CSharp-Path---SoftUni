using System;
using System.Collections.Generic;
using System.Linq;

namespace SchoolTeams
{
    public class Program
    {
        private static string[] _girls;
        private static string[] _boys;
        private static string[] _combinationGirls;
        private static string[] _combinationBoys;
        private static List<string[]> _finalGirlCombinations = new List<string[]>();
        private static List<string[]> _finalBoyCombinations = new List<string[]>();
        
        public static void Main(string[] args)
        {
            _girls = Console.ReadLine().Split(", ");
            _boys = Console.ReadLine().Split(", ");

            _combinationGirls = new string[3];
            GirlCombinations(0, 0, _finalGirlCombinations);

            _combinationBoys = new string[2];
            BoyCombinations(0, 0, _finalBoyCombinations);

            PrintCombinations(_finalGirlCombinations, _finalBoyCombinations);
        }

        private static void PrintCombinations(List<string[]> finalGirls, List<string[]> finalBoys)
        {
            foreach (var girls in _finalGirlCombinations)
            {
                foreach (var boys in _finalBoyCombinations)
                {
                    Console.WriteLine(
                        $"{string.Join(", ", girls)}, {string.Join(", ", boys)}");
                }
            }
        }

        private static void GirlCombinations(int index, int start, List<string[]> finalCombinations)
        {
            if (index >= _combinationGirls.Length)
            {
                finalCombinations.Add(_combinationGirls.ToArray());
                return;
            }

            for (int i = start; i < _girls.Length; i++)
            {
                _combinationGirls[index] = _girls[i];
                GirlCombinations(index + 1, i + 1, finalCombinations);
            }
        }

        private static void BoyCombinations(int index, int start, List<string[]> finalCombinations)
        {
            if (index >= _combinationBoys.Length)
            {
                finalCombinations.Add(_combinationBoys.ToArray());
                return;
            }

            for (int i = start; i < _boys.Length; i++)
            {
                _combinationBoys[index] = _boys[i];
                BoyCombinations(index + 1, i + 1, finalCombinations);
            }
        }
    }
}