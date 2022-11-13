using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WildFarm.Models.Interfaces;
using WildFarm.Models.Interfaces.Animals.Birds;
using WildFarm.Models.Interfaces.Animals.Mammals;
using WildFarm.Models.Interfaces.Animals.Mammals.Felines;
using WildFarm.Models.Interfaces.Foods;

namespace WildFarm.Models
{
    public class ClassCollector
    {
        public static Animal ReturnAnimal(string input)
        {
            string[] infoStrings = input.Split(" ").ToArray();

            string type = infoStrings[0];
            string name = infoStrings[1];
            double weight = double.Parse(infoStrings[2]);

            switch (type)
            {
                case "Mouse": return new Mouse(name, weight, infoStrings[3]);
                case "Dog": return new Dog(name, weight, infoStrings[3]);
                case "Hen": return new Hen(name, weight, double.Parse(infoStrings[3]));
                case "Owl": return new Owl(name, weight, double.Parse(infoStrings[3]));
                case "Cat": return new Cat(name, weight, infoStrings[3], infoStrings[4]);
                case "Tiger": return new Tiger(name, weight, infoStrings[3], infoStrings[4]);
                default: return null;
            }
        }

        public static Food ReturnFood(string input)
        {
            string[] infoStrings = input.Split(" ").ToArray();

            string type = infoStrings[0];
            int quantity = int.Parse(infoStrings[1]);

            switch (type)
            {
                case "Fruit": return new Fruit(quantity);
                case "Meat": return new Meat(quantity);
                case "Seeds": return new Seeds(quantity);
                case "Vegetable": return new Vegetable(quantity);
                default: return null;
            }
        }
    }
}
