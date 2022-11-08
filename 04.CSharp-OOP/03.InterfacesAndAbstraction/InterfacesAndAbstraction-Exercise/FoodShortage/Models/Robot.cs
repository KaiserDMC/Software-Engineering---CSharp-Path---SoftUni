using System;
using System.Collections.Generic;
using System.Text;
using FoodShortage.Models.Interfaces;

namespace FoodShortage.Models
{
    public class Robot : IIdentifiable
    {
        public string Id { get; private set; }
        public string Name { get; private set; }

        public Robot()
        {

        }

        public Robot(string name, string id)
        {
            Name = name;
            Id = id;
        }

        public string CheckFakeID(string idString)
        {
            if (this.Id.EndsWith(idString))
            {
                return $"{this.Id}";
            }

            return null;
        }
    }
}
