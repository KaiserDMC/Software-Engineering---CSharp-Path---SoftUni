using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage.Models.Interfaces
{
    public interface IBirthable
    {
        public string Name { get; }
        public string Birthdate { get; }

        string CheckBirthdate(string date);
    }
}
