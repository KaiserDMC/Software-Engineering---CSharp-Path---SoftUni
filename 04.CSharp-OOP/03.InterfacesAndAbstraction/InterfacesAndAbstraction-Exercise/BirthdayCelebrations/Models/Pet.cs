using System;
using System.Collections.Generic;
using System.Text;
using BirthdayCelebrations.Models.Interfaces;

namespace BirthdayCelebrations.Models
{
    public class Pet : IBirthable
    {
        public string Name { get; private set; }
        public string Birthdate { get; private set; }

        public Pet()
        {
            
        }

        public Pet(string name, string birthdate)
        {
            Name = name;
            Birthdate = birthdate;
        }
        public string CheckBirthdate(string date)
        {
            if (this.Birthdate.EndsWith(date))
            {
                return $"{this.Birthdate}";
            }

            return null;
        }
    }
}
