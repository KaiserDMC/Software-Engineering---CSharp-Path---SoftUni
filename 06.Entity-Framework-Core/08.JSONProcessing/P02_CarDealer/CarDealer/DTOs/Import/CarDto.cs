using Newtonsoft.Json;

namespace CarDealer.DTOs.Import;

public class CarDto
{
    [JsonProperty("make")]
    public string Make { get; set; }

    [JsonProperty("model")]
    public string Model { get; set; }

    [JsonProperty("traveledDistance")]
    public long TravelledDistance { get; set; }

    [JsonProperty("partsId")]
    public int[] PartIds { get; set; }
}