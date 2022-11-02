using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {
        private string flourType;
        private string bakingTechnique;
        private double grams;

        public Dough(string flourType, string bakingTechnique, double grams)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Grams = grams;
        }
        private double Grams
        { 
            set
            {
                if (value < 1 && value > 200)
                {
                    throw new ArgumentException($"Dough weight should be in the range [1..200].");
                }
                grams = value;
            }
        }
        private string BakingTechnique
        {
            set
            {
                if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")
                {
                    throw new ArgumentException($"Invalid type of dough.");
                }
                bakingTechnique = value;
            }
        }
        private string FlourType
        {
            
            set
            {
                if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
                {
                    throw new ArgumentException($"Invalid type of dough.");
                }
                flourType = value;
            }
        }

        public double GetDoughCalories
        {
            get
            {
                double doughModifier = 0;
                double bakingModifier = 0;

                if (this.flourType.ToLower() == "white")
                {
                    doughModifier = 1.5;
                }
                else if (this.flourType.ToLower() == "wholegrain")
                {
                    doughModifier = 1;
                }

                switch (this.bakingTechnique.ToLower())
                {
                    case "crispy":
                        bakingModifier = 0.9;
                        break;
                    case "chewy":
                        bakingModifier = 1.1;
                        break;
                    case "homemade":
                        bakingModifier = 1;
                        break;
                }

                double totalCalories = this.grams * 2 * doughModifier * bakingModifier;

                return totalCalories;
            }
        }

        public double CalculateCalories()
        {
            return this.GetDoughCalories;
        }
    }
}
