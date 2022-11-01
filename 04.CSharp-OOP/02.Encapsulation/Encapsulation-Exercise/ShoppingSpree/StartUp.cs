using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();
            List<Product> products = new List<Product>();
           
            string[] peopleStrings = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries).ToArray();
            string[] productStrings = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries).ToArray();


            foreach (var people in peopleStrings)
            {
                string[] tokens = people.Split("=", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string name = tokens[0];
                decimal money = decimal.Parse(tokens[1]);

                try
                {
                    Person person = new Person(name, money);
                    persons.Add(person);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }
            }

            foreach (var product in productStrings)
            {
                string[] tokens = product.Split("=", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string name = tokens[0];
                decimal cost = decimal.Parse(tokens[1]);

                try
                {
                    Product prod = new Product(name, cost);
                    products.Add(prod);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }
            }

            while (true)
            {
                string[] tryToBuy = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (tryToBuy[0] == "END")
                {
                    break;
                }

                string personName = tryToBuy[0];
                string productName = tryToBuy[1];

                Person tempPerson = persons.Find(p => p.Name == personName);
                Product tempProduct = products.Find(p => p.Name == productName);
                if (tempPerson != null && tempProduct != null)
                {
                    tempPerson.Buy(tempProduct);
                }
            }

            foreach (var per in persons)
            {
                if (!per.Bag.Any())
                {
                    Console.WriteLine($"{per.Name} - Nothing bought");
                }
                else
                {
                    Console.WriteLine($"{per.Name} - {String.Join(", ", per.Bag)}");
                }
            }
        }
    }
}
