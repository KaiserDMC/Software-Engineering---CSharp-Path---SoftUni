using System;
using System.Collections.Generic;
using System.Linq;

namespace ThePianist
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfInitialPieces = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, string>> piecesByComposerAndKey =
                new Dictionary<string, Dictionary<string, string>>();

            for (int i = 0; i < numberOfInitialPieces; i++)
            {
                string[] pieceInformation = Console.ReadLine().Split("|").ToArray();
                string pieceName = pieceInformation[0];
                string pieceComposer = pieceInformation[1];
                string pieceKey = pieceInformation[2];

                piecesByComposerAndKey.Add(pieceName, new Dictionary<string, string>());
                piecesByComposerAndKey[pieceName].Add(pieceComposer, pieceKey);
            }

            while (true)
            {
                string[] alteringCommandStrings = Console.ReadLine().Split("|").ToArray();

                if (alteringCommandStrings[0] == "Stop")
                {
                    break;
                }

                string command = alteringCommandStrings[0];

                switch (command)
                {
                    case "Add":
                        string pieceName = alteringCommandStrings[1];
                        string pieceComposer = alteringCommandStrings[2];
                        string pieceKey = alteringCommandStrings[3];

                        if (!piecesByComposerAndKey.ContainsKey(pieceName))
                        {
                            piecesByComposerAndKey.Add(pieceName, new Dictionary<string, string>());
                            piecesByComposerAndKey[pieceName].Add(pieceComposer, pieceKey);

                            Console.WriteLine($"{pieceName} by {pieceComposer} in {pieceKey} added to the collection!");
                        }
                        else
                        {
                            Console.WriteLine($"{pieceName} is already in the collection!");
                        }

                        break;
                    case "Remove":
                        pieceName = alteringCommandStrings[1];

                        if (!piecesByComposerAndKey.ContainsKey(pieceName))
                        {
                            Console.WriteLine($"Invalid operation! {pieceName} does not exist in the collection.");
                        }
                        else
                        {
                            piecesByComposerAndKey.Remove(pieceName);
                            Console.WriteLine($"Successfully removed {pieceName}!");
                        }

                        break;
                    case "ChangeKey":
                        pieceName = alteringCommandStrings[1];
                        pieceKey = alteringCommandStrings[2];

                        if (!piecesByComposerAndKey.ContainsKey(pieceName))
                        {
                            Console.WriteLine($"Invalid operation! {pieceName} does not exist in the collection.");
                        }
                        else
                        {
                            string tempComposer = piecesByComposerAndKey[pieceName].Keys.First();

                            piecesByComposerAndKey[pieceName][tempComposer] = pieceKey;

                            Console.WriteLine($"Changed the key of {pieceName} to {pieceKey}!");
                        }

                        break;
                }
            }

            foreach (var pieces in piecesByComposerAndKey)
            {
                Console.Write($"{pieces.Key} -> ");
                Console.Write(string.Join("", pieces.Value.Select(x => $"Composer: {x.Key}, Key: {x.Value}")));

                Console.WriteLine();
            }
        }
    }
}
