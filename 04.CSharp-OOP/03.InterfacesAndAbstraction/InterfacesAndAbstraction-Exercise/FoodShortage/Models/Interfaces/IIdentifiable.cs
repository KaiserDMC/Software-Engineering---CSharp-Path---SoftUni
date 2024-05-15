using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage.Models.Interfaces
{
    public interface IIdentifiable
    {
        public string Id { get; }
        public string Name { get; }

        string CheckFakeID(string idString);
    }
}
