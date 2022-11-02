using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Topping
    {
        private string toppingType;
        private double grams;

        public Topping(string toppingType, double grams)
        {
            this.ToppingType = toppingType;
            this.Grams = grams;
        }

        private double Grams
        {
            set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException($"{this.toppingType} weight should be in the range [1..50].");
                }
                this.grams = value;
            }
        }
        private string ToppingType
        {
            set
            {
                if (value.ToLower() != "meat" && value.ToLower() != "veggies" && value.ToLower() != "cheese" && value.ToLower() != "sauce")
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                toppingType = value;
            }
        }

        public double GetToppingCalories
        {
            get
            {
                double totalCalories;
                double toppingModifier = 0;

                switch (this.toppingType.ToLower())
                {
                    case "meat":
                        toppingModifier = 1.2;
                        break;
                    case "veggies":
                        toppingModifier = 0.8;
                        break;
                    case "cheese":
                        toppingModifier = 1.1;
                        break;
                    case "sauce":
                        toppingModifier = 0.9;
                        break;
                }

                totalCalories = this.grams * 2 * toppingModifier;

                return totalCalories;
            }
        }

        public double CalculateCalories()
        {
            return this.GetToppingCalories;
        }
    }
}
