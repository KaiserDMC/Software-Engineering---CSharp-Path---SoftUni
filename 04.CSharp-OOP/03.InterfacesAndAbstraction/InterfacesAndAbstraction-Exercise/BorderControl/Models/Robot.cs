using System;
using System.Collections.Generic;
using System.Text;
using BorderControl.Models.Interfaces;

namespace BorderControl.Models
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

        public string CheckForFakeID(string idString)
        {
            if (this.Id.EndsWith(idString))
            {
                return $"{this.Id}";
            }

            return null;
        }
    }
}
