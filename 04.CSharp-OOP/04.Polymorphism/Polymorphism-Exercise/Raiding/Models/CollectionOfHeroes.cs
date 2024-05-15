using System;
using System.Collections.Generic;
using System.Text;
using Raiding.Models.Interfaces;

namespace Raiding.Models
{
    public class CollectionOfHeroes
    {
        public static BaseHero ReturnHero(string name, string type)
        {
            switch (type)
            {
                case "Druid":
                    return new Druid(name);
                case "Paladin":
                    return new Paladin(name);
                case "Rogue":
                    return new Rogue(name);
                case "Warrior":
                    return new Warrior(name);
                default:
                    throw new ArgumentException($"Invalid hero!");
            }
        }
    }
}
