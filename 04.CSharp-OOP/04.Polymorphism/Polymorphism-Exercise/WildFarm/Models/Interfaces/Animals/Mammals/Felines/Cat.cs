using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Models.Interfaces.Animals.Mammals.Felines
{
    public class Cat : Feline
    {
        protected override string Breed { get; set; }

        public Cat(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
        }

        public override string ProduceSound()
        {
            return $"Meow";
        }

        public override void Eat(Food food)
        {
            if (food.GetType().Name == "Meat" || food.GetType().Name == "Vegetable")
            {
                this.FoodEaten += food.Quantity;
                this.Weight += 0.3 * food.Quantity;
            }
            else
            {
                Console.WriteLine($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }
        }
    }
}
