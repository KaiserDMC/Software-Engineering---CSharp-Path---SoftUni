namespace Boardgames.DataProcessor;

using System.Text;
using System.Xml.Serialization;
using System.Diagnostics.CodeAnalysis;

using Newtonsoft.Json;

using Data;
using ExportDto;

public class Serializer
{
    [SuppressMessage("ReSharper.DPA", "DPA0000: DPA issues")]
    public static string ExportCreatorsWithTheirBoardgames(BoardgamesContext context)
    {
        var creatorsWithTheirBoardgames = context.Creators
            .Where(c => c.Boardgames.Any())
            .ToArray()
            .Select(c => new ExportCreatorsWithTheirBoardgamesDto()
            {
                BoardgamesCount = c.Boardgames.Count(),
                CreatorName = c.FirstName + " " + c.LastName,
                Boardgames = c.Boardgames
                    .Select(bg => new ExportBoardgameDto_Xml()
                    {
                        BoardgameName = bg.Name,
                        BoardgameYearPublished = bg.YearPublished
                    })
                    .OrderBy(bg => bg.BoardgameName)
                    .ToArray()
            })
            .OrderByDescending(c => c.Boardgames.Count())
            .ThenBy(c => c.CreatorName)
            .ToArray();

        return Serialize<ExportCreatorsWithTheirBoardgamesDto[]>(creatorsWithTheirBoardgames, "Creators");
    }

    [SuppressMessage("ReSharper.DPA", "DPA0000: DPA issues")]
    public static string ExportSellersWithMostBoardgames(BoardgamesContext context, int year, double rating)
    {
        var sellersWithMostBoardgames = context.Sellers
            .Where(s => s.BoardgamesSellers.Any(bg => bg.Boardgame.YearPublished >= year) &&
                        s.BoardgamesSellers.Any(bg => (double)bg.Boardgame.Rating <= rating))
            .ToArray()
            .Select(s => new ExportSellersWithMostBoardgamesDto()
            {
                Name = s.Name,
                Website = s.Website,
                Boardgames = s.BoardgamesSellers
                    .Where(bs => bs.Boardgame.YearPublished >= year && bs.Boardgame.Rating <= rating)
                    .Select(bg => new ExportBoardgameDto_Json()
                    {
                        Name = bg.Boardgame.Name,
                        Rating = (decimal)bg.Boardgame.Rating,
                        Mechanics = bg.Boardgame.Mechanics,
                        Category = bg.Boardgame.CategoryType.ToString()
                    })
                    .OrderByDescending(bg => bg.Rating)
                    .ThenBy(bg => bg.Name)
                    .ToArray()
            })
            .OrderByDescending(s => s.Boardgames.Count())
            .ThenBy(s => s.Name)
            .Take(5)
            .ToArray();

        return JsonConvert.SerializeObject(sellersWithMostBoardgames, Formatting.Indented);
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