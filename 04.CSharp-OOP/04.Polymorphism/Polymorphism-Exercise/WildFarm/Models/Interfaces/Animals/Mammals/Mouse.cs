using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Models.Interfaces.Animals.Mammals
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }

        public override string ProduceSound()
        {
            return $"Squeak";
        }

        public override void Eat(Food food)
        {
            if (food.GetType().Name == "Fruit" || food.GetType().Name == "Vegetable")
            {
                this.FoodEaten += food.Quantity;
                this.Weight += 0.1 * food.Quantity;
            }
            else
            {
                Console.WriteLine($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }
        }
    }
}
