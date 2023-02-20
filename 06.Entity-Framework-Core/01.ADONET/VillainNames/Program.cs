using Microsoft.Data.SqlClient;

namespace VillainNames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SqlConnection connectionDb = new SqlConnection(ConfigClass.ConfigString.ConnectionStringDocker);

            connectionDb.Open();

            using (connectionDb)
            {
                SqlCommand command = new SqlCommand(
                    @"SELECT v.Name, COUNT(mv.VillainId) AS MinionsCount
                             FROM Villains AS v
                             JOIN MinionsVillains AS mv ON v.Id = mv.VillainId
                             GROUP BY v.Id, v.Name
                             HAVING COUNT(mv.VillainId) > 3
                             ORDER BY COUNT(mv.VillainId)", connectionDb);

                SqlDataReader reader = command.ExecuteReader();

                using (reader)
                {
                    while (reader.Read())
                    {
                        string villainName = (string)reader["Name"];
                        int minionsNumber = (int)reader["MinionsCount"];

                        Console.WriteLine($"{villainName} - {minionsNumber}");
                    }
                }
            }
        }
    }
}