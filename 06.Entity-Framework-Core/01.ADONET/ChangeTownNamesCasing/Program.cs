using Microsoft.Data.SqlClient;

namespace ChangeTownNamesCasing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countryId = 0;
            string countryName = Console.ReadLine();
            List<string> updatedTowns = new List<string>();

            SqlConnection connectionDb = new SqlConnection(ConfigClass.ConfigString.ConnectionString);

            connectionDb.Open();

            using (connectionDb)
            {
                SqlCommand findCountryId = new SqlCommand(
                        @"SELECT c.Id FROM Countries AS c WHERE c.Name = @countryName", connectionDb);

                findCountryId.Parameters.AddWithValue("@countryName", countryName);

                SqlDataReader readerCountry = findCountryId.ExecuteReader();

                using (readerCountry)
                {
                    while (readerCountry.Read())
                    {
                        countryId = (int)readerCountry["Id"];
                    }

                    if (countryId == 0)
                    {
                        Console.WriteLine($"No town names were affected.");
                        return;
                    }
                }

                SqlCommand findAllTownsInCountry = new SqlCommand(
                    @" SELECT t.Name 
                              FROM Towns as t
                              JOIN Countries AS c ON c.Id = t.CountryCode
                              WHERE c.Name = @countryName", connectionDb);

                findAllTownsInCountry.Parameters.AddWithValue("@countryName", countryName);

                SqlDataReader readerTowns = findAllTownsInCountry.ExecuteReader();

                using (readerTowns)
                {
                    while (readerTowns.Read())
                    {
                        string townName = (string)readerTowns["Name"];

                        SqlCommand townNameToUpper = new SqlCommand(
                            @"UPDATE Towns
                                     SET Name = UPPER(Name)
                                     WHERE Name = @townName", connectionDb);

                        townNameToUpper.Parameters.AddWithValue("@townName", townName);

                        townNameToUpper.ExecuteNonQueryAsync();
                    }
                }

                SqlCommand getUpdatedValues = new SqlCommand(
                    @"SELECT t.Name 
                             FROM Towns as t
                             JOIN Countries AS c ON c.Id = t.CountryCode
                             WHERE c.Name = @countryName", connectionDb);

                getUpdatedValues.Parameters.AddWithValue("@countryName", countryName);

                SqlDataReader readerAfterUpdate = getUpdatedValues.ExecuteReader();

                using (readerAfterUpdate)
                {
                    while (readerAfterUpdate.Read())
                    {
                        string upperTownName = (string)readerAfterUpdate["Name"];

                        updatedTowns.Add(upperTownName);
                    }
                }

                if (updatedTowns.Any())
                {
                    Console.WriteLine($"{ updatedTowns.Count} town names were affected.");
                    Console.WriteLine($"[" + string.Join(", ", updatedTowns) + $"]");
                }
                else
                {
                    Console.WriteLine($"No town names were affected.");
                }
            }
        }
    }
}