using System.Text;

namespace DefiningClasses
{
    public class Car
    {
        private string model;
        private Engine engine;
        private int weight;
        private string color;

        public Car()
        {
            this.Weight = int.MinValue;
            this.Color = "n/a";
        }

        public Car(string model, Engine engine) : this()
        {
            this.Model = model;
            this.Engine = engine;
        }

        public Car(string model, Engine engine, int weight) : this(model, engine)
        {
            this.Weight = weight;
        }

        public Car(string model, Engine engine, int weight, string color) : this(model, engine, weight)
        {
            this.Color = color;
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public Engine Engine
        {
            get { return engine; }
            set { engine = value; }
        }

        public int Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        public string Color
        {
            get { return color; }
            set { color = value; }
        }

        public override string ToString()
        {
            StringBuilder text = new StringBuilder();

            string weight = this.weight == int.MinValue ? "n/a" : this.weight.ToString();

            text.AppendLine($"{this.Model}:");
            text.Append($"{this.Engine.ToString()}");
            text.AppendLine($"  Weight: {weight}");
            text.Append($"  Color: {this.Color}");

            return text.ToString();
        }
    }
}