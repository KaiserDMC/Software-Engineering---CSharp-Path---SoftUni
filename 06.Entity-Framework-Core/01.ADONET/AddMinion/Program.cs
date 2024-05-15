using Microsoft.Data.SqlClient;

namespace AddMinion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] minionInformation = Console.ReadLine().Split(" ").ToArray();
            string[] villainInformation = Console.ReadLine().Split(" ").ToArray();

            string minionName = minionInformation[1];
            string minionAge = minionInformation[2];
            string minionTown = minionInformation[3];
            string villainName = villainInformation[1];
            int villainId = 0;
            int minionId = 0;
            int townId = 0;

            SqlConnection connect = new SqlConnection(ConfigClass.ConfigString.ConnectionStringDocker);

            connect.Open();

            using (connect)
            {
                SqlCommand commandTown = new SqlCommand(
                    @"SELECT Id FROM Towns WHERE Name = @townName", connect);

                commandTown.Parameters.AddWithValue("@townName", minionTown);

                SqlDataReader readerTown = commandTown.ExecuteReader();

                using (readerTown)
                {
                    while (readerTown.Read())
                    {
                        townId = (int)readerTown["Id"];
                    }

                    if (townId == 0)
                    {
                        SqlCommand insertTown = new SqlCommand(
                            @"INSERT INTO Towns (Name) VALUES (@townName)",
                            connect);

                        insertTown.Parameters.AddWithValue("@townName", minionTown);

                        insertTown.ExecuteNonQueryAsync();

                        Console.WriteLine($"Town {minionTown} was added to the database.");
                    }
                }
            }

            SqlConnection connection = new SqlConnection(ConfigClass.ConfigString.ConnectionStringDocker);

            connection.Open();

            using (connection)
            {
                SqlCommand commandMinion = new SqlCommand(
                    @"SELECT Id FROM Minions WHERE Name = @Name", connection);

                commandMinion.Parameters.AddWithValue("@Name", minionName);

                SqlDataReader readerMinion = commandMinion.ExecuteReader();

                using (readerMinion)
                {
                    while (readerMinion.Read())
                    {
                        minionId = (int)readerMinion["Id"];
                    }

                    if (minionId == 0)
                    {
                        SqlCommand insertMinion = new SqlCommand(
                            @"INSERT INTO Minions (Name, Age, TownId) VALUES (@name, @age, @townId)",
                            connection);

                        insertMinion.Parameters.AddWithValue("@name", minionName);
                        insertMinion.Parameters.AddWithValue("@age", minionAge);
                        insertMinion.Parameters.AddWithValue("@townId", townId);

                        insertMinion.ExecuteNonQueryAsync();
                    }
                }
            }

            SqlConnection connectionDb = new SqlConnection(ConfigClass.ConfigString.ConnectionStringDocker);

            connectionDb.Open();

            using (connectionDb)
            {
                SqlCommand commandVillain = new SqlCommand(
                    @"SELECT Id FROM Villains WHERE Name = @Name", connectionDb);

                commandVillain.Parameters.AddWithValue("@Name", villainName);

                SqlDataReader readerVillain = commandVillain.ExecuteReader();

                using (readerVillain)
                {
                    while (readerVillain.Read())
                    {
                        villainId = (int)readerVillain["Id"];
                    }

                    if (villainId == 0)
                    {
                        SqlCommand insertVillain = new SqlCommand(
                                @"INSERT INTO Villains (Name, EvilnessFactorId)  VALUES (@villainName, 4)",
                                connectionDb);

                        insertVillain.Parameters.AddWithValue("@villainName", villainName);

                        insertVillain.ExecuteNonQueryAsync();

                        Console.WriteLine($"Villain {villainName} was added to the database.");
                    }
                }
            }

            SqlConnection con = new SqlConnection(ConfigClass.ConfigString.ConnectionStringDocker);

            con.Open();

            using (con)
            {
                SqlCommand insertMinionToVillain = new SqlCommand(
                    @"INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (@minionId, @villainId)", con);

                insertMinionToVillain.Parameters.AddWithValue("@minionId", minionId);
                insertMinionToVillain.Parameters.AddWithValue("@villainId", villainId);

                insertMinionToVillain.ExecuteNonQueryAsync();

                Console.WriteLine($"Successfully added {minionName} to be minion of {villainName}.");
            }
        }
    }
}