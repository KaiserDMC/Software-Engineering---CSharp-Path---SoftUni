namespace DefiningClasses
{
    public class Pokemon
    {
        private string name;
        private string element;
        private int health;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Element
        {
            get { return element; }
            set { element = value; }
        }

        public int Health
        {
            get { return health; }
            set { health = value; }
        }
    }
}