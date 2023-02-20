namespace ConfigClass
{
    public class ConfigString
    {
        public const string ConnectionStringDocker =
            @"Data Source = xxxxxxxxxxxxxxxx, 1433; Initial Catalog = MinionsDB; User ID = SA; Password = xxxxxxxxxxxxxxxxx; TrustServerCertificate=True";

        public const string ConnectionStringLocal =
            @"Server=(LocalDB)\CSharpDB SoftUni; Database=MinionsDB; Integrated Security=true";
    }
}