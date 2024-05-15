using System;
using System.Collections.Generic;
using System.Text;
using FoodShortage.Models.Interfaces;

namespace FoodShortage.Models
{
    public class Rebel : IBuyer
    {
        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Group { get; private set; }

        public Rebel()
        {

        }

        public Rebel(string name, int age, string group)
        {
            Name = name;
            Age = age;
            Group = group;
        }

        public int BuyFood()
        {
            return 5;
        }
    }
}
