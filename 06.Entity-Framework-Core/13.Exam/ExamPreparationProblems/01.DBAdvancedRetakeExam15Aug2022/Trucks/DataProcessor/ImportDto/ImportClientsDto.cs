namespace Trucks.DataProcessor.ImportDto;

using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Data;

public class ImportClientsDto
{
    [JsonRequired]
    [JsonProperty("Name")]
    [MinLength(ValidationConstants.clientNameMinLength)]
    [MaxLength(ValidationConstants.clientNameMaxLength)]
    public string Name { get; set; }

    [JsonRequired]
    [MinLength(ValidationConstants.clientMinNationality)]
    [MaxLength(ValidationConstants.clientMaxNationality)]
    [JsonProperty("Nationality")]
    public string Nationality { get; set; }

    [JsonRequired]
    [JsonProperty("Type")]
    public string Type { get; set; }

    [JsonProperty("Trucks")]
    public int[] TruckIds { get; set; }
}