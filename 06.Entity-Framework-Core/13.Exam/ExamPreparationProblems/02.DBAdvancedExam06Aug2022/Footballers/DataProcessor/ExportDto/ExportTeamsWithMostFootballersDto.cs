namespace Footballers.DataProcessor.ExportDto;

using Newtonsoft.Json;

public class ExportTeamsWithMostFootballersDto
{
    [JsonProperty("Name")]
    public string Name { get; set; }

    [JsonProperty("Footballers")]
    public FootballerJsonExport[] Footballers { get; set; }
}

public class FootballerJsonExport
{
    [JsonProperty("FootballerName")]
    public string FootballerName { get; set; }

    [JsonProperty("ContractStartDate")]
    public string ContractStartDate { get; set; }

    [JsonProperty("ContractEndDate")]
    public string ContractEndDate { get; set; }

    [JsonProperty("BestSkillType")]
    public string BestSkillType { get; set; }

    [JsonProperty("PositionType")]
    public string PositionType { get; set; }
}