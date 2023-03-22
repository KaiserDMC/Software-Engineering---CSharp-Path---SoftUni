namespace Footballers.DataProcessor.ImportDto;

using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

using Data;

public class ImportTeamsDto
{
    [Required]
    [RegularExpression(ValidationConstants.TeamNameRegexValidation)]
    [JsonProperty("Name")]
    public string Name { get; set; }

    [Required]
    [MinLength(ValidationConstants.TeamNationalityLengthMin)]
    [MaxLength(ValidationConstants.TeamNationalityLengthMax)]
    [JsonProperty("Nationality")]
    public string Nationality { get; set; }

    [Required]
    [JsonProperty("Trophies")]
    public int Trophies { get; set; }

    [JsonProperty("Footballers")]
    public int[] Footballers { get; set; }
}