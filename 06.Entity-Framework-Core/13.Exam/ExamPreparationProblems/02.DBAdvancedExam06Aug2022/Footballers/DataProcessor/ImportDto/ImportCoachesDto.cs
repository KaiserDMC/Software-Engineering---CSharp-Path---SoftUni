namespace Footballers.DataProcessor.ImportDto;

using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

using Data;

[XmlType("Coach")]
public class ImportCoachesDto
{
    [Required]
    [MinLength(ValidationConstants.CoachNameLengthMin)]
    [MaxLength(ValidationConstants.CoachNameLengthMax)]
    [XmlElement("Name")]
    public string Name { get; set; }

    [Required]
    [XmlElement("Nationality")]
    public string Nationality { get; set; }

    [XmlArray("Footballers")]
    public ImportFootballerDto[] Footballers { get; set; }
}

[XmlType("Footballer")]
public class ImportFootballerDto
{
    [Required]
    [MinLength(ValidationConstants.FootballerNameLengthMin)]
    [MaxLength(ValidationConstants.FootballerNameLengthMax)]
    [XmlElement("Name")]
    public string Name { get; set; }

    [Required]
    [XmlElement("ContractStartDate")]
    public string ContractStartDate { get; set; }

    [Required]
    [XmlElement("ContractEndDate")]
    public string ContractEndDate { get; set; }

    [Required]
    [XmlElement("BestSkillType")]
    public int BestSkillType { get; set; }

    [Required]
    [XmlElement("PositionType")]
    public int PositionType { get; set; }
}