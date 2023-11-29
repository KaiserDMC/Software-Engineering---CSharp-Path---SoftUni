using System;
using System.Linq;
using System.Text;

namespace SumOfCoins
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] coins = Console.ReadLine().Split(", ").Select(int.Parse).OrderByDescending(x => x).ToArray();
            int targetSum = int.Parse(Console.ReadLine());
            
            TakeCoins(coins, targetSum);
        }

        private static void TakeCoins(int[] coins, int targetSum)
        {
            int counter = 0;
            int index = 0;
            StringBuilder sb = new StringBuilder();
            
            while (targetSum > 0)
            {
                if (index >= coins.Length)
                {
                    Console.WriteLine("Error");
                    return;
                }

                int currentCoin = coins[index];
                int coinsToTake = targetSum / currentCoin;
                
                if (coinsToTake > 0)
                {
                    sb.AppendLine($"{coinsToTake} coin(s) with value {currentCoin}");
                    counter += coinsToTake;
                    targetSum -= coinsToTake * currentCoin;
                }

                index++;
            }
            
            Console.WriteLine($"Number of coins to take: {counter}");
            Console.WriteLine(sb.ToString().Trim());
        }
    }
}