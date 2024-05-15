using System;
using System.Collections.Generic;

namespace ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> bag;

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.bag = new List<Product>();
        }

        public decimal Money
        {
            get { return money; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException($"Money cannot be negative");
                }
                money = value;
            }
        }
        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException($"Name cannot be empty");
                }
                name = value;
            }
        }

        public IReadOnlyCollection<Product> Bag
        {
            get { return bag.AsReadOnly(); }
        }
        public void Buy(Product product)
        {
            if (this.money >= product.Cost)
            {
                Console.WriteLine($"{this.Name} bought {product}");
                this.money -= product.Cost;
                this.bag.Add(product);
            }
            else
            {
                Console.WriteLine($"{this.Name} can't afford {product}");
            }
        }
    }
}
