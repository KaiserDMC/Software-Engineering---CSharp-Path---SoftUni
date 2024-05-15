namespace Trucks.DataProcessor.ImportDto;

using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using Data;

[XmlType("Despatcher")]
public class ImportDespatchersDto
{
    [Required]
    [MinLength(ValidationConstants.despatcherMinNameLength)]
    [MaxLength(ValidationConstants.despatcherMaxNameLength)]
    [XmlElement("Name")]
    public string Name { get; set; }

    [XmlElement("Position")]
    public string Position { get; set; }

    [XmlArray("Trucks")]
    public TruckDesp[] Trucks { get; set; }
}

[XmlType("Truck")]
public class TruckDesp
{
    [Required]
    [StringLength(ValidationConstants.truckLength)]
    [RegularExpression(@"[A-Z]{2}\d{4}[A-Z]{2}$")]
    [XmlElement("RegistrationNumber")]
    public string RegistrationNumber { get; set; }

    [Required]
    [StringLength(ValidationConstants.vinLength)]
    [XmlElement("VinNumber")]
    public string VinNumber { get; set; }

    [Range(ValidationConstants.tankCapacityMin, ValidationConstants.tankCapacityMax)]
    [XmlElement("TankCapacity")]
    public int TankCapacity { get; set; }

    [Range(ValidationConstants.cargoCapacityMin, ValidationConstants.cargoCapacityMax)]
    [XmlElement("CargoCapacity")]
    public int CargoCapacity { get; set; }

    [Required]
    [Range(ValidationConstants.categoryTypeMin, ValidationConstants.categoryTypeMax)]
    [XmlElement("CategoryType")]
    public int CategoryType { get; set; }

    [Required]
    [Range(ValidationConstants.makeTypeMin, ValidationConstants.makeTypeMax)]
    [XmlElement("MakeType")]
    public int MakeType { get; set; }
}