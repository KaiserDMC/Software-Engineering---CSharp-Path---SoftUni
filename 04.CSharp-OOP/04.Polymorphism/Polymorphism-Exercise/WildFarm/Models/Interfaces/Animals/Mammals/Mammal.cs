namespace WildFarm.Models.Interfaces.Animals.Mammals
{
    public abstract class Mammal : Animal
    {
        protected override string Name { get; set; }
        protected override double Weight { get; set; }
        protected override int FoodEaten { get; set; }
        protected string LivingRegion { get; set; }

        public Mammal(string name, double weight, string livingRegion) : base(name, weight)
        {
            this.LivingRegion = livingRegion;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
