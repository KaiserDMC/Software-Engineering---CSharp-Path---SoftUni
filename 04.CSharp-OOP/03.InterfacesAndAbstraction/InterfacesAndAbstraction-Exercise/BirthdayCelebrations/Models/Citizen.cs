using BirthdayCelebrations.Models.Interfaces;

namespace BirthdayCelebrations.Models
{
    public class Citizen : IIdentifiable, IBirthable
    {
        public string Id { get; private set; }
        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Birthdate { get; private set; }

        public Citizen()
        {

        }

        public Citizen(string name,int age, string id, string birthdate)
        {
            Name = name;
            Age = age;
            Id = id;
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
