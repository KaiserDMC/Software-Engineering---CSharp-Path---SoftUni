namespace Footballers.DataProcessor;

using Data;
using System.Text;
using System.Xml.Serialization;

public class Serializer
{
    public static string ExportCoachesWithTheirFootballers(FootballersContext context)
    {
        return "";
    }

    public static string ExportTeamsWithMostFootballers(FootballersContext context, DateTime date)
    {
        return "";
    }

    private static string Serialize<T>(T dataTransferObjects, string xmlRootAttributeName)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(T), new XmlRootAttribute(xmlRootAttributeName));

        StringBuilder sb = new StringBuilder();
        using var write = new StringWriter(sb);

        XmlSerializerNamespaces xmlNamespaces = new XmlSerializerNamespaces();
        xmlNamespaces.Add(string.Empty, string.Empty);

        serializer.Serialize(write, dataTransferObjects, xmlNamespaces);

        return sb.ToString();
    }
}