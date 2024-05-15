namespace DefiningClasses
{
    public class Cargo
    {
        private string type;
        private int weight;

        public Cargo(int weight, string type)
        {
            this.Type = type;
            this.Weight = weight;
        }

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        public int Weight
        {
            get { return weight; }
            set { weight = value; }
        }
    }
}