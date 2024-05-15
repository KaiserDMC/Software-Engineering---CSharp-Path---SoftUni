using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage.Models.Interfaces
{
    public interface IBuyer
    {
        public string Name { get; }
        public int Age { get; }

        int BuyFood();
    }
}
