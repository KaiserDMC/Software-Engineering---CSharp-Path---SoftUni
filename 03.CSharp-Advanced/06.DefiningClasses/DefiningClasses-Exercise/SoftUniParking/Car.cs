using System.Text;

namespace SoftUniParking
{
    public class Car
    {
        private string make;
        private string model;
        private int horsePower;
        private string registrationNumber;

        public Car(string make, string model, int horsePower, string registrationNumber)
        {
            this.Make = make;
            this.Model = model;
            this.HorsePower = horsePower;
            this.RegistrationNumber = registrationNumber;
        }

        public string Make
        {
            get { return make; }
            set { make = value; }
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public int HorsePower
        {
            get { return horsePower; }
            set { horsePower = value; }
        }

        public string RegistrationNumber
        {
            get { return registrationNumber; }
            set { registrationNumber = value; }
        }

        public override string ToString()
        {
            StringBuilder text = new StringBuilder();

            text.AppendLine($"Make: {this.Make}");
            text.AppendLine($"Model: {this.Model}");
            text.AppendLine($"HorsePower: {this.HorsePower}");
            text.Append($"RegistrationNumber: {this.RegistrationNumber}");

            return text.ToString();
        }
    }
}