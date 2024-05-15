namespace Boardgames.DataProcessor.ImportDto;

using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

[XmlType("Creator")]
public class ImportCreatorsDto
{
    [Required]
    [XmlElement("FirstName")]
    [MinLength(ValidationConstants.CreatorAnyNameLengthMin)]
    [MaxLength(ValidationConstants.CreatorAnyNameLengthMax)]
    public string FirstName { get; set; }

    [Required]
    [XmlElement("LastName")]
    [MinLength(ValidationConstants.CreatorAnyNameLengthMin)]
    [MaxLength(ValidationConstants.CreatorAnyNameLengthMax)]
    public string LastName { get; set; }

    [XmlArray("Boardgames")]
    public ImportBoardgameDto_Xml[] Boardgames { get; set; }
}

[XmlType("Boardgame")]
public class ImportBoardgameDto_Xml
{
    [Required]
    [XmlElement("Name")]
    [MinLength(ValidationConstants.BoardgameNameLengthMin)]
    [MaxLength(ValidationConstants.BoardgameNameLengthMax)]
    public string Name { get; set; }

    [Required]
    [XmlElement("Rating")]
    [Range(ValidationConstants.BoardgameRatingRangeMin, ValidationConstants.BoardgameRatingRangeMax)]
    public decimal Rating { get; set; }

    [Required]
    [XmlElement("YearPublished")]
    [Range(ValidationConstants.BoardgameYearRangeMin, ValidationConstants.BoardgameYearRangeMax)]
    public int YearPublished { get; set; }

    [Required]
    [XmlElement("CategoryType")]
    public int CategoryType { get; set; }

    [Required]
    [XmlElement("Mechanics")]
    public string Mechanics { get; set; }
}