using BorderControl.Models.Interfaces;

namespace BorderControl.Models
{
    public class Citizen : IIdentifiable
    {
        public string Id { get; private set; }
        public int Age { get; private set; }
        public string Name { get; private set; }

        public Citizen()
        {

        }

        public Citizen(string name,int age, string id)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
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
