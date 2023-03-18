namespace CarDealer.DTOs.Export;

using System.Xml.Serialization;

[XmlType("car")]
public class ExportCarsFromMakeBMWDto
{
    [XmlAttribute("id")]
    public int Id { get; set; }

    [XmlAttribute("model")]
    public string Model { get; set; }

    [XmlAttribute("traveled-distance")]
    public long TraveledDistance { get; set; }
}