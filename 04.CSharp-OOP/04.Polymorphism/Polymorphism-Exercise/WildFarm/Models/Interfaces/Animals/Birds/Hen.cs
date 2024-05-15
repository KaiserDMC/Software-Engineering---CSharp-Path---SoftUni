using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Models.Interfaces.Animals.Birds
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        public override string ProduceSound()
        {
            return $"Cluck";
        }

        public override void Eat(Food food)
        {
            this.FoodEaten += food.Quantity;
            this.Weight += 0.35 * food.Quantity;
        }
    }
}
