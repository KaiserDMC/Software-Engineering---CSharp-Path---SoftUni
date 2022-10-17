using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;

namespace DefiningClasses
{
    public class Family
    {
        private List<Person> familyMembers = new List<Person>();

        public void AddMember(Person member)
        {
            familyMembers.Add(member);
        }

        public List<Person> PeopleAboveThirty()
        {
            List<Person> oldPeople = new List<Person>();

            oldPeople = familyMembers.FindAll(m => m.Age > 30).OrderBy(m=>m.Name).ToList();

            return oldPeople;
        }
    }
}