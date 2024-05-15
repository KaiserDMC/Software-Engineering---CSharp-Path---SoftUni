using System;
using System.Collections.Generic;
using System.Text;
using Raiding.IO.Interfaces;
using Raiding.Models;
using Raiding.Models.Interfaces;

namespace Raiding.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private List<BaseHero> heroes;

        public Engine()
        {
            this.heroes = new List<BaseHero>();
        }

        public Engine(IReader reader, IWriter writer) : this()
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            int numberOfInputs = int.Parse(this.reader.ReadLine());

            while (heroes.Count < numberOfInputs)
            {
                string heroName = this.reader.ReadLine();
                string heroType = this.reader.ReadLine();

                try
                {
                    BaseHero heroToAdd = CollectionOfHeroes.ReturnHero(heroName, heroType);
                    heroes.Add(heroToAdd);
                }
                catch (ArgumentException e)
                {
                    this.writer.WriteLine(e.Message);
                }
            }

            int bossPower = int.Parse(this.reader.ReadLine());

            foreach (var hero in heroes)
            {
                this.writer.WriteLine(hero.CastAbility());
                bossPower -= hero.Power;
            }

            if (bossPower <= 0)
            {
                this.writer.WriteLine($"Victory!");
            }
            else
            {
                this.writer.WriteLine($"Defeat...");
            }
        }
    }
}

