using System;
using System.Collections.Generic;
using System.Linq;

namespace TilesMaster
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> whiteTiles = new Stack<int>();
            Queue<int> greyTiles = new Queue<int>();

            Dictionary<string, int> areaByLocation = new Dictionary<string, int>()
            {
                { "Sink", 40 },
                { "Oven", 50 },
                { "Countertop", 60 },
                { "Wall", 70 }
            };

            Dictionary<string, int> usedTilesByArea = new Dictionary<string, int>();

            int[] inputWhiteTiles = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] inputGreyTiles = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int i = 0; i < inputWhiteTiles.Length; i++)
            {
                whiteTiles.Push(inputWhiteTiles[i]);
            }

            for (int i = 0; i < inputGreyTiles.Length; i++)
            {
                greyTiles.Enqueue(inputGreyTiles[i]);
            }

            while (true)
            {
                if (greyTiles.Count == 0 || whiteTiles.Count == 0)
                {
                    break;
                }

                int currentWhiteTile = whiteTiles.Pop();
                int currentGreyTile = greyTiles.Dequeue();

                int areaNew = 0;

                if (currentWhiteTile == currentGreyTile)
                {
                    bool areaMatches = false;
                    areaNew = currentWhiteTile + currentGreyTile;

                    foreach (var area in areaByLocation)
                    {
                        if (areaNew == area.Value)
                        {
                            if (!usedTilesByArea.ContainsKey(area.Key))
                            {
                                usedTilesByArea.Add(area.Key, 0);
                            }

                            usedTilesByArea[area.Key]++;
                            areaMatches = true;
                        }
                    }

                    if (!areaMatches)
                    {
                        if (!usedTilesByArea.ContainsKey("Floor"))
                        {
                            usedTilesByArea.Add("Floor", 0);
                        }

                        usedTilesByArea["Floor"]++;
                    }
                }
                else
                {
                    currentWhiteTile /= 2;
                    whiteTiles.Push(currentWhiteTile);

                    greyTiles.Enqueue(currentGreyTile);
                }
            }

            if (whiteTiles.Count == 0)
            {
                Console.WriteLine($"White tiles left: none");
            }
            else
            {
                Console.Write($"White tiles left: ");
                Console.WriteLine(string.Join(", ", whiteTiles));
            }

            if (greyTiles.Count == 0)
            {
                Console.WriteLine($"Grey tiles left: none");
            }
            else
            {
                Console.Write($"Grey tiles left: ");
                Console.WriteLine(string.Join(", ", greyTiles));
            }

            foreach (var tiles in usedTilesByArea.OrderByDescending(t => t.Value).ThenBy(a => a.Key))
            {
                Console.WriteLine($"{tiles.Key}: {tiles.Value}");
            }
        }
    }
}