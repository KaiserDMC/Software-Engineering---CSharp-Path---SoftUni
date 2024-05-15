namespace BirthdayCelebrations.Models.Interfaces
{
   public interface IBirthable
    {
        public string Name { get; }
        public string Birthdate { get; }

        string CheckBirthdate(string date);
    }
}
