using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonDontGo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> distancesToPokemon = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
            int sum = 0;

            while (true)
            {
                int pokemonIndex = int.Parse(Console.ReadLine());
                int valueToCompare = 0;

                if (pokemonIndex < 0)
                {
                    valueToCompare = distancesToPokemon[0];
                    distancesToPokemon.RemoveAt(0);
                    distancesToPokemon.Insert(0, distancesToPokemon[distancesToPokemon.Count - 1]);

                    for (int i = 0; i < distancesToPokemon.Count; i++)
                    {
                        int tempValue = distancesToPokemon[i];

                        if (tempValue <= valueToCompare)
                        {
                            tempValue += valueToCompare;
                            distancesToPokemon[i] = tempValue;
                        }
                        else
                        {
                            tempValue -= valueToCompare;
                            distancesToPokemon[i] = tempValue;
                        }
                    }
                }
                else if (pokemonIndex > distancesToPokemon.Count - 1)
                {
                    valueToCompare = distancesToPokemon[distancesToPokemon.Count - 1];
                    distancesToPokemon.RemoveAt(distancesToPokemon.Count - 1);
                    distancesToPokemon.Add(distancesToPokemon[0]);

                    for (int i = 0; i < distancesToPokemon.Count; i++)
                    {
                        int tempValue = distancesToPokemon[i];

                        if (tempValue <= valueToCompare)
                        {
                            tempValue += valueToCompare;
                            distancesToPokemon[i] = tempValue;
                        }
                        else
                        {
                            tempValue -= valueToCompare;
                            distancesToPokemon[i] = tempValue;
                        }
                    }
                }
                else
                {
                    valueToCompare = distancesToPokemon[pokemonIndex];
                    distancesToPokemon.RemoveAt(pokemonIndex);

                    for (int i = 0; i < distancesToPokemon.Count; i++)
                    {
                        int tempValue = distancesToPokemon[i];

                        if (tempValue <= valueToCompare)
                        {
                            tempValue += valueToCompare;
                            distancesToPokemon[i] = tempValue;
                        }
                        else
                        {
                            tempValue -= valueToCompare;
                            distancesToPokemon[i] = tempValue;
                        }
                    }
                }

                sum += valueToCompare;

                if (distancesToPokemon.Count < 1)
                {
                    break;
                }
            }

            Console.WriteLine(sum);
        }
    }
}
