using System;
using System.Collections.Generic;
using System.Linq;

namespace CardsGame
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> deckPlayerOne = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
            List<int> deckPlayerTwo = Console.ReadLine().Split(" ").Select(int.Parse).ToList();

            int maxDeckLength = Math.Max(deckPlayerOne.Count, deckPlayerTwo.Count);
            bool isOneZero = false;
            bool isTwoZero = false;

            for (int i = 0; i < maxDeckLength; i++)
            {
                if (deckPlayerOne.Count <= 0)
                {
                    isOneZero = true;
                    break;
                }

                if (deckPlayerTwo.Count <= 0)
                {
                    isTwoZero = true;
                    break;
                }

                bool playerOneStronger = deckPlayerOne[i] > deckPlayerTwo[i];
                int tempCard = 0;

                if (playerOneStronger)
                {
                    int currCard = deckPlayerTwo[i];
                    tempCard = currCard;
                    deckPlayerTwo.Remove(currCard);
                    deckPlayerOne.Add(tempCard);
                    deckPlayerOne.Insert(deckPlayerOne.Count - 1, deckPlayerOne[i]);
                    deckPlayerOne.Remove(deckPlayerOne[i]);
                }
                else
                {
                    if (deckPlayerOne[i] == deckPlayerTwo[i])
                    {
                        deckPlayerOne.Remove(deckPlayerOne[i]);
                        deckPlayerTwo.Remove(deckPlayerTwo[i]);
                    }
                    else
                    {
                        int currCard = deckPlayerOne[i];
                        tempCard = currCard;
                        deckPlayerOne.Remove(currCard);
                        deckPlayerTwo.Add(tempCard);
                        deckPlayerTwo.Insert(deckPlayerTwo.Count - 1, deckPlayerTwo[i]);
                        deckPlayerTwo.Remove(deckPlayerTwo[i]);
                    }
                }

                i = -1;
            }

            if (isOneZero)
            {
                Console.WriteLine($"Second player wins! Sum: {deckPlayerTwo.Sum()}");
            }

            if (isTwoZero)
            {
                Console.WriteLine($"First player wins! Sum: {deckPlayerOne.Sum()}");
            }
        }
    }
}
