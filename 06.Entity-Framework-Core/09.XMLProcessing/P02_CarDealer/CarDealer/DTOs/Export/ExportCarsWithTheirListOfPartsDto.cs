namespace CarDealer.DTOs.Export;

using System.Xml.Serialization;

[XmlType("car")]
public class ExportCarsWithTheirListOfPartsDto
{
    [XmlAttribute("make")]
    public string Make { get; set; }

    [XmlAttribute("model")]
    public string Model { get; set; }

    [XmlAttribute("traveled-distance")]
    public long TraveledDistance { get; set; }

    [XmlArray("parts")]
    public PartsFromCars[] PartsFromCars { get; set; }
}

[XmlType("part")]
public class PartsFromCars
{
    [XmlAttribute("name")]
    public string Name { get; set; }

    [XmlAttribute("price")]
    public decimal Price { get; set; }
}