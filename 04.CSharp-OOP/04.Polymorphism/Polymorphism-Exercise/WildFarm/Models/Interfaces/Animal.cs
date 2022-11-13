using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Models.Interfaces
{
    public abstract class Animal
    {
        protected abstract string Name { get; set; }
        protected abstract double Weight { get; set; }
        protected abstract int FoodEaten { get; set; }

        public Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
            this.FoodEaten = 0;
        }

        public virtual string ProduceSound()
        {
            return "";
        }

        public virtual void Eat(Food food)
        {

        }
    }
}
