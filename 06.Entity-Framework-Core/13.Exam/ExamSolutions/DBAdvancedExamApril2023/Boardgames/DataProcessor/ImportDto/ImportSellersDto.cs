namespace Boardgames.DataProcessor.ImportDto;

using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

public class ImportSellersDto
{
    [Required]
    [JsonProperty("Name")]
    [MinLength(ValidationConstants.SellerNameLengthMin)]
    [MaxLength(ValidationConstants.SellerNameLengthMax)]
    public string Name { get; set; }

    [Required]
    [JsonProperty("Address")]
    [MinLength(ValidationConstants.SellerAddressLengthMin)]
    [MaxLength(ValidationConstants.SellerAddressLengthMax)]
    public string Address { get; set; }

    [Required]
    [JsonProperty("Country")]
    public string Country { get; set; }

    [Required]
    [JsonProperty("Website")]
    [RegularExpression(ValidationConstants.SellerWebsiteRegex)]
    public string Website { get; set; }

    [JsonProperty("Boardgames")]
    public int[] Boardgames { get; set; }
}