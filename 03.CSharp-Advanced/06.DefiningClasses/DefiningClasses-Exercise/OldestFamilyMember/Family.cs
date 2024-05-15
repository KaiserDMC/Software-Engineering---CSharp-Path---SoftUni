using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;

namespace DefiningClasses
{
    public class Family
    {
        private List<Person> familyMembers = new List<Person>();

        public Family()
        {
            this.familyMembers = new List<Person>();
        }

        public void AddMember(Person member)
        {
            familyMembers.Add(member);
        }

        public Person GetOldestMember()
        {
            return this.familyMembers.OrderByDescending(m => m.Age).First();
        }
    }
}