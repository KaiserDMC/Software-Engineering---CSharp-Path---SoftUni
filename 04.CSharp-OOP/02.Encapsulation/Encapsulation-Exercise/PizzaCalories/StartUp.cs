using System;
using System.Linq;

namespace PizzaCalories
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                string pizzaName = Console.ReadLine().Split(" ").Last();

                string[] doughStrings = Console.ReadLine().Split(" ").ToArray();
                string flour = doughStrings[1];
                string bakingTechnique = doughStrings[2];
                double weight = double.Parse(doughStrings[3]);

                Dough dough = new Dough(flour, bakingTechnique, weight);
                Pizza pizza = new Pizza(pizzaName, dough);

                while (true)
                {
                    string[] inputTopping = Console.ReadLine().Split(" ").ToArray();

                    if (inputTopping[0] == "END")
                    {
                        break;
                    }

                    string toppingType = inputTopping[1];
                    double toppingWeight =double.Parse(inputTopping[2]);

                    Topping topping = new Topping(toppingType, toppingWeight);
                    pizza.AddTopping(topping);
                }

                Console.WriteLine(pizza);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
