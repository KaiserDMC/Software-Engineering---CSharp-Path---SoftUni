using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Json;

namespace MOBAChallenger
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> playerDatabaseByPositionAndSkill =
                new Dictionary<string, Dictionary<string, int>>();

            while (true)
            {
                string[] playerInputStrings = Console.ReadLine().Split(new string[] { " -> ", " vs " }, StringSplitOptions.None).ToArray();

                if (playerInputStrings[0] == "Season end")
                {
                    break;
                }

                if (playerInputStrings.Length == 3)
                {
                    string playerName = playerInputStrings[0];
                    string playerPosition = playerInputStrings[1];
                    int playerSkill = int.Parse(playerInputStrings[2]);

                    if (!playerDatabaseByPositionAndSkill.ContainsKey(playerName))
                    {
                        playerDatabaseByPositionAndSkill.Add(playerName, new Dictionary<string, int>());
                        playerDatabaseByPositionAndSkill[playerName].Add(playerPosition, playerSkill);
                    }

                    if (!playerDatabaseByPositionAndSkill[playerName].ContainsKey(playerPosition))
                    {
                        playerDatabaseByPositionAndSkill[playerName].Add(playerPosition, playerSkill);
                    }

                    if (playerDatabaseByPositionAndSkill[playerName][playerPosition] < playerSkill)
                    {
                        playerDatabaseByPositionAndSkill[playerName][playerPosition] = playerSkill;
                    }
                }
                else if (playerInputStrings.Length == 2)
                {
                    string playerOne = playerInputStrings[0];
                    string playerTwo = playerInputStrings[1];
                    bool removePlayerOne = false;
                    bool removePlayerTwo = false;

                    if (playerDatabaseByPositionAndSkill.ContainsKey(playerOne) && playerDatabaseByPositionAndSkill.ContainsKey(playerTwo))
                    {
                        foreach (var VARIABLE in playerDatabaseByPositionAndSkill[playerOne])
                        {
                            if (playerDatabaseByPositionAndSkill[playerTwo].ContainsKey(VARIABLE.Key))
                            {
                                if (playerDatabaseByPositionAndSkill[playerOne].Values.Sum() > playerDatabaseByPositionAndSkill[playerTwo].Values.Sum())
                                {
                                    removePlayerTwo = true;
                                }
                                else if (playerDatabaseByPositionAndSkill[playerOne].Values.Sum() < playerDatabaseByPositionAndSkill[playerTwo].Values.Sum())
                                {
                                    removePlayerOne = true;
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }

                        if (removePlayerOne)
                        {
                            playerDatabaseByPositionAndSkill.Remove(playerOne);
                        }
                        else if (removePlayerTwo)
                        {
                            playerDatabaseByPositionAndSkill.Remove(playerTwo);
                        }
                    }
                }
            }

            foreach (var player in playerDatabaseByPositionAndSkill.OrderByDescending(p => p.Value.Values.Sum()).ThenBy(p => p.Key))
            {
                Console.WriteLine($"{player.Key}: {player.Value.Values.Sum()} skill");
                Console.WriteLine(string.Join(Environment.NewLine, player.Value.OrderByDescending(x => x.Value).ThenBy(x => x.Key).Select(x => $"- {x.Key} <::> {x.Value}")));
            }
        }
    }
}
