namespace Trucks.DataProcessor.ExportDto;

using System.Xml.Serialization;

[XmlType("Despatcher")]
public class ExportDespatchersWithTheirTrucksDto
{
    [XmlAttribute("TrucksCount")]
    public int TruckCount { get; set; }

    [XmlElement("DespatcherName")]
    public string Name { get; set; }

    [XmlArray("Trucks")]
    public TruckXML[] Trucks { get; set; }
}

[XmlType("Truck")]
public class TruckXML
{
    [XmlElement("RegistrationNumber")]
    public string RegistrationNumber { get; set; }

    [XmlElement("Make")]
    public string Make { get; set; }
}