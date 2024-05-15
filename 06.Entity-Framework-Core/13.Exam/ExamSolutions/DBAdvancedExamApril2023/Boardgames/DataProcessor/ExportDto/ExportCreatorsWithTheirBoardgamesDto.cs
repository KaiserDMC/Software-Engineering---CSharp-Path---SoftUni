namespace Boardgames.DataProcessor.ExportDto;

using System.Xml.Serialization;

[XmlType("Creator")]
public class ExportCreatorsWithTheirBoardgamesDto
{
    [XmlAttribute("BoardgamesCount")]
    public int BoardgamesCount { get; set; }

    [XmlElement("CreatorName")]
    public string CreatorName { get; set; }

    [XmlArray("Boardgames")]
    public ExportBoardgameDto_Xml[] Boardgames { get; set; }
}

[XmlType("Boardgame")]
public class ExportBoardgameDto_Xml
{
    [XmlElement("BoardgameName")]
    public string BoardgameName { get; set; }

    [XmlElement("BoardgameYearPublished")]
    public int BoardgameYearPublished { get; set; }
}