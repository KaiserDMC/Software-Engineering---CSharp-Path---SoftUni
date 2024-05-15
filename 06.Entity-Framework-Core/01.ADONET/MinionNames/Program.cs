using Microsoft.Data.SqlClient;

namespace MinionNames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SqlConnection connectionDb = new SqlConnection(ConfigClass.ConfigString.ConnectionStringDocker);

            connectionDb.Open();

            string villianId = Console.ReadLine();
            string villainName = String.Empty;

            using (connectionDb)
            {
                SqlCommand commandVillain = new SqlCommand(
                    @"SELECT Name FROM Villains WHERE Id = @Id", connectionDb);

                commandVillain.Parameters.AddWithValue("@Id", villianId);

                SqlDataReader readerVillain = commandVillain.ExecuteReader();

                using (readerVillain)
                {
                    while (readerVillain.Read())
                    {
                        villainName = (string)readerVillain["Name"];
                    }

                    if (string.IsNullOrEmpty(villainName))
                    {
                        Console.WriteLine($"No villain with ID {villianId} exists in the database.");
                        return;
                    }
                }
            }

            SqlConnection connection = new SqlConnection(ConfigClass.ConfigString.ConnectionStringDocker);

            connection.Open();

            using (connection)
            {
                SqlCommand command = new SqlCommand(
                    $@"SELECT ROW_NUMBER() OVER (ORDER BY m.Name) AS RowNum,
                                     m.Name, 
                                     m.Age
                              FROM MinionsVillains AS mv
                              JOIN Minions As m ON mv.MinionId = m.Id
                              WHERE mv.VillainId = @Id
                              ORDER BY m.Name", connection);

                command.Parameters.AddWithValue("@Id", villianId);

                SqlDataReader reader = command.ExecuteReader();

                using (reader)
                {
                    Console.WriteLine($"Villain: {villainName}");

                    bool hasMinions = false;

                    while (reader.Read())
                    {
                        long rowNumber = (long)reader["RowNum"];
                        string minionName = (string)reader["Name"];
                        int minionAge = (int)reader["Age"];

                        Console.WriteLine($"{rowNumber}. {minionName} {minionAge}");

                        hasMinions = true;
                    }

                    if (!hasMinions)
                    {
                        Console.WriteLine($"(no minions)");
                    }
                }
            }
        }
    }
}