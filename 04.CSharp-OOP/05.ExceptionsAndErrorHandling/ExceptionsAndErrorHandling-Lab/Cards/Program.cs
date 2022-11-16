using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Cards
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] cardInputs = Console.ReadLine().Split(", ").ToArray();

            List<Card> cards = new List<Card>();

            for (int i = 0; i < cardInputs.Length; i++)
            {
                string currentFace = cardInputs[i].Split().First();
                string currentSuit = cardInputs[i].Split().Last();

                try
                {
                    cards.Add(CreateCard(currentFace, currentSuit));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            Console.WriteLine(string.Join(" ", cards));
        }

        public static Card CreateCard(string face, string suit)
        {
            Card card = new Card(face, suit);

            return new Card(face, suit);
        }
    }

    class Card
    {
        private string face;
        private string suit;

        private string regexMatch = @"\b([JQKA[0-9]|10)\b";

        private Dictionary<string, string> suitsList = new Dictionary<string, string>()
        {
            {"S", "\u2660"},
            {"H", "\u2665"},
            {"D", "\u2666"},
            {"C", "\u2663"}
        };

        public Card(string face, string suit)
        {
            this.Face = face;
            this.Suit = suit;
        }

        public string Suit
        {
            get { return suit; }
            private set
            {
                if (!suitsList.ContainsKey(value))
                {
                    throw new ArgumentException($"Invalid card!");
                }
                suit = suitsList[value];
            }
        }
        public string Face
        {
            get { return face; }
            private set
            {
                Match match = Regex.Match(value, regexMatch);

                if (!match.Success)
                {
                    throw new ArgumentException($"Invalid card!");
                }

                face = value;
            }
        }

        public override string ToString()
        {
            return $"[{this.Face}{this.Suit}]";
        }
    }
}
