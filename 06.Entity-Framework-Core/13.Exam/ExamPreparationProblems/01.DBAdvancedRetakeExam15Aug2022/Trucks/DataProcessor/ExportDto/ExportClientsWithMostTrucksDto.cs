namespace Trucks.DataProcessor.ExportDto;

using Newtonsoft.Json;

public class ExportClientsWithMostTrucksDto
{
    [JsonProperty("Name")]
    public string ClientName { get; set; }

    [JsonProperty("Trucks")]
    public TruckJson[] Trucks { get; set; }
}

public class TruckJson
{
    [JsonProperty("TruckRegistrationNumber")]
    public string RegistrationNumber { get; set; }

    [JsonProperty("VinNumber")]
    public string VinNumber { get; set; }

    [JsonProperty("TankCapacity")]
    public int TankCapacity { get; set; }

    [JsonProperty("CargoCapacity")]
    public int CargoCapacity { get; set; }

    [JsonProperty("CategoryType")]
    public string CategoryType { get; set; }

    [JsonProperty("MakeType")]
    public string MakeType { get; set; }
}