namespace Footballers.DataProcessor.ExportDto;

using System.Xml.Serialization;

[XmlType("Coach")]
public class ExportCoachesWithTheirFootballersDto
{
    [XmlAttribute("FootballersCount")]
    public int FootballersCount { get; set; }

    [XmlElement("CoachName")]
    public string CoachName { get; set; }

    [XmlArray("Footballers")]
    public FootballerXmlExport[] Footballers { get; set; }
}

[XmlType("Footballer")]
public class FootballerXmlExport
{
    [XmlElement("Name")]
    public string FootballerName { get; set; }

    [XmlElement("Position")]
    public string Position { get; set; }
}