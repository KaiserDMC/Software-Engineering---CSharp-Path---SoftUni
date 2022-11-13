using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.IO.Interfaces;
using WildFarm.Models;
using WildFarm.Models.Interfaces;

namespace WildFarm.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private List<Animal> animals;

        public Engine()
        {
            this.animals = new List<Animal>();
        }

        public Engine(IReader reader, IWriter writer) : this()
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            string input = this.reader.ReadLine();

            while (input != "End")
            {

                Animal animal = ClassCollector.ReturnAnimal(input);

                this.writer.WriteLine(animal.ProduceSound());

                input = this.reader.ReadLine();

                Food food = ClassCollector.ReturnFood(input);
                animal.Eat(food);

                animals.Add(animal);

                input = this.reader.ReadLine();
            }

            foreach (var animal in animals)
            {
                this.writer.WriteLine(animal.ToString());
            }
        }
    }
}
