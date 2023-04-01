namespace Boardgames.DataProcessor.ExportDto;

using Newtonsoft.Json;

public class ExportSellersWithMostBoardgamesDto
{
    [JsonProperty("Name")]
    public string Name { get; set; }

    [JsonProperty("Website")]
    public string Website { get; set; }

    [JsonProperty("Boardgames")]
    public ExportBoardgameDto_Json[] Boardgames { get; set; }
}

public class ExportBoardgameDto_Json
{
    [JsonProperty("Name")]
    public string Name { get; set; }

    [JsonProperty("Rating")]
    public decimal Rating { get; set; }

    [JsonProperty("Mechanics")]
    public string Mechanics { get; set; }

    [JsonProperty("Category")]
    public string Category { get; set; }
}