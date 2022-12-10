using System;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Utilities.Messages;

namespace ChristmasPastryShop.Models.Cocktails
{
    public abstract class Cocktail : ICocktail
    {
        private string name;
        private string size;
        private double price;

        protected Cocktail(string name, string size, double price)
        {
            this.Name = name;
            this.Size = size;
            this.Price = price;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.NameNullOrWhitespace));
                }

                name = value;
            }
        }

        public string Size
        {
            get => size;
            private set { size = value; }
        }

        public double Price
        {
            get => price;
            private set
            {
                if (this.Size == "Large")
                {
                    price = value;
                }
                else if (this.Size == "Middle")
                {
                    price = ((double)2 / 3.0) * value;
                }
                else if (this.Size == "Small")
                {
                    price = ((double)1 / 3.0) * value;
                }
            }
        }

        public override string ToString()
        {
            return $"{this.Name} ({this.Size}) - {this.Price:f2} lv";
        }
    }
}