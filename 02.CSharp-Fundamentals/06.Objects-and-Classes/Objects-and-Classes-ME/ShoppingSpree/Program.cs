using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

            List<Person> people = new List<Person>();

            for (int i = 0; i < input.Length; i++)
            {
                string[] personStrings = input[i].Split("=", StringSplitOptions.RemoveEmptyEntries).ToArray();

                Person person = new Person
                {
                    Name = personStrings[0],
                    Money = decimal.Parse(personStrings[1])
                };

                people.Add(person);
            }

            ProductBag productBag = new ProductBag();

            input = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < input.Length; i++)
            {
                string[] productStrings = input[i].Split("=", StringSplitOptions.RemoveEmptyEntries).ToArray();

                Product product = new Product
                {
                    Name = productStrings[0],
                    Cost = decimal.Parse(productStrings[1])
                };

                productBag.Products.Add(product);
            }

            string commandString = Console.ReadLine();

            while (commandString != "END")
            {
                string[] inputsList = commandString.Split(" ").ToArray();
                string buyerName = inputsList[0];
                string productName = inputsList[1];

                int indexPerson = people.FindIndex(x => x.Name == buyerName);
                int indexProduct = productBag.Products.FindIndex(x => x.Name == productName);

                if (productBag.Products[indexProduct].Cost > people[indexPerson].Money)
                {
                    Console.WriteLine($"{people[indexPerson].Name} can't afford {productBag.Products[indexProduct].Name}");
                }
                else
                {
                    Console.WriteLine($"{people[indexPerson].Name} bought {productBag.Products[indexProduct].Name}");
                    people[indexPerson].Money -= productBag.Products[indexProduct].Cost;
                    people[indexPerson].ProductBag.Products.Add(productBag.Products[indexProduct]);
                }

                commandString = Console.ReadLine();
            }

            foreach (Person person in people)
            {
                if (person.ProductBag.Products.Count > 0)
                {
                    Console.WriteLine($"{person.Name} - {String.Join(", ", person.ProductBag.Products.Select(x => x.Name))}");
                }
                else
                {
                    Console.WriteLine($"{person.Name} - Nothing bought");
                }
            }
        }
    }

    class Person
    {
        public Person()
        {
            this.ProductBag = new ProductBag();
        }

        public string Name { get; set; }
        public decimal Money { get; set; }
        public ProductBag ProductBag { get; set; }
    }

    class Product
    {
        public string Name { get; set; }
        public decimal Cost { get; set; }
    }

    class ProductBag
    {
        public ProductBag()
        {
            this.Products = new List<Product>();
        }

        public List<Product> Products { get; set; }
    }
}
