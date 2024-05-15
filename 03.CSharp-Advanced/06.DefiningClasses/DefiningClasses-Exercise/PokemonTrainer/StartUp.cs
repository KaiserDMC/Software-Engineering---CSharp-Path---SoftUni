using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Trainer> trainers = new List<Trainer>();

            while (true)
            {
                string inputCommand = Console.ReadLine();

                if (inputCommand == "Tournament")
                {
                    break;
                }

                string[] tokens = inputCommand.Split(" ").ToArray();

                Trainer currentTrainer = new Trainer();
                currentTrainer.Name = tokens[0];

                Pokemon currentPokemon = new Pokemon();
                currentPokemon.Name = tokens[1];
                currentPokemon.Element = tokens[2];
                currentPokemon.Health = int.Parse(tokens[3]);

                if (!trainers.Any(t => t.Name == tokens[0]))
                {
                    currentTrainer.Pokemons.Add(currentPokemon);
                    trainers.Add(currentTrainer);
                }
                else
                {
                    trainers.Find(t => t.Name == tokens[0]).Pokemons.Add(currentPokemon);
                }
            }

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "End")
                {
                    break;
                }

                switch (command)
                {
                    case "Fire":
                        foreach (var trainer in trainers)
                        {
                            bool elements = false;

                            foreach (var pokemon in trainer.Pokemons)
                            {
                                if (pokemon.Element == command)
                                {
                                    elements = true;
                                    trainer.NumberOfBadges++;
                                    break;
                                }
                            }

                            int index = 0;

                            if (!elements)
                            {
                                for (int i = 0; i < trainer.Pokemons.Count; i++)
                                {
                                    trainer.Pokemons[i].Health -= 10;
                                    if (trainer.Pokemons.Any(p => p.Health <= 0))
                                    {
                                        for (int j = 0; j < trainer.Pokemons.FindAll(p => p.Health <= 0).Count; j++)
                                        {
                                            index = trainer.Pokemons.FindIndex(p => p.Health <= 0);
                                            trainer.Pokemons.RemoveAt(index);
                                        }
                                    }
                                }
                            }
                        }

                        break;
                    case "Water":
                        foreach (var trainer in trainers)
                        {
                            bool elements = false;

                            foreach (var pokemon in trainer.Pokemons)
                            {
                                if (pokemon.Element == command)
                                {
                                    elements = true;
                                    trainer.NumberOfBadges++;
                                    break;
                                }
                            }

                            int index = 0;

                            if (!elements)
                            {
                                for (int i = 0; i < trainer.Pokemons.Count; i++)
                                {
                                    trainer.Pokemons[i].Health -= 10;
                                    if (trainer.Pokemons.Any(p => p.Health <= 0))
                                    {
                                        for (int j = 0; j < trainer.Pokemons.FindAll(p => p.Health <= 0).Count; j++)
                                        {
                                            index = trainer.Pokemons.FindIndex(p => p.Health <= 0);
                                            trainer.Pokemons.RemoveAt(index);
                                        }
                                    }
                                }
                            }
                        }

                        break;
                    case "Electricity":
                        foreach (var trainer in trainers)
                        {
                            bool elements = false;

                            foreach (var pokemon in trainer.Pokemons)
                            {
                                if (pokemon.Element == command)
                                {
                                    elements = true;
                                    trainer.NumberOfBadges++;
                                    break;
                                }
                            }

                            int index = 0;

                            if (!elements)
                            {
                                for (int i = 0; i < trainer.Pokemons.Count; i++)
                                {
                                    trainer.Pokemons[i].Health -= 10;
                                    if (trainer.Pokemons.Any(p => p.Health <= 0))
                                    {
                                        for (int j = 0; j < trainer.Pokemons.FindAll(p => p.Health <= 0).Count; j++)
                                        {
                                            index = trainer.Pokemons.FindIndex(p => p.Health <= 0);
                                            trainer.Pokemons.RemoveAt(index);
                                        }
                                    }
                                }
                            }
                        }

                        break;
                }
            }

            foreach (var trainer in trainers.OrderByDescending(t => t.NumberOfBadges))
            {
                Console.WriteLine($"{trainer.Name} {trainer.NumberOfBadges} {trainer.Pokemons.Count}");
            }
        }
    }
}