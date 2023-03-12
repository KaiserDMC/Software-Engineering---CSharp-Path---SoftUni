namespace CarDealer.Models
{
    public class PartCar
    {
        public int PartId { get; set; }
        public Part Part { get; set; } = null!; 

        public int CarId { get; set; }
        public Car Car { get; set; } = null!; 
    }
}
