using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Models.Interfaces.Animals.Mammals.Felines
{
    public class Tiger : Feline
    {
        protected override string Breed { get; set; }
        public Tiger(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
        }

        public override string ProduceSound()
        {
            return $"ROAR!!!";
        }

        public override void Eat(Food food)
        {
            if (food.GetType().Name == "Meat")
            {
                this.FoodEaten += food.Quantity;
                this.Weight += 1 * food.Quantity;
            }
            else
            {
                Console.WriteLine($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }
        }
    }
}
