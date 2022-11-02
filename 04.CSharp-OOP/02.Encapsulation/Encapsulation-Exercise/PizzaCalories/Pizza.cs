using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Pizza
    {
        private string name;
        private Dough dough;
        private List<Topping> toppings;

        public Pizza(string name, Dough dough)
        {
            this.Name = name;
            this.Dough = dough;
            this.Toppings = new List<Topping>();
        }

        public double TotalCalories
        {
            get
            {
                double totalCalories = this.Dough.CalculateCalories();
                foreach (var topping in toppings)
                {
                    totalCalories += topping.CalculateCalories();
                }

                return totalCalories;
            }
        }
        public int Count
        {
            get { return toppings.Count; }
        }
        public Dough Dough
        {
            get { return dough; }
            set { dough = value; }
        }
        public List<Topping> Toppings
        {
            get { return toppings; }
            set { toppings = value; }
        }
        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value) || value.Length > 15)
                {
                    throw new ArgumentException($"Pizza name should be between 1 and 15 symbols.");
                }
                name = value;
            }
        }

        public void AddTopping(Topping currenTopping)
        {
            if (this.Count == 10)
            {
                throw new ArgumentException($"Number of toppings should be in range [0..10].");
            }

            toppings.Add(currenTopping);
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.TotalCalories:f2} Calories.";
        }
    }
}
