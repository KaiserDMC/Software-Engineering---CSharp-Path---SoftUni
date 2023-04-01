namespace Boardgames.DataProcessor;

using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

using Newtonsoft.Json;

using Data;
using ImportDto;
using Data.Models;
using Data.Models.Enums;

public class Deserializer
{
    private const string ErrorMessage = "Invalid data!";

    private const string SuccessfullyImportedCreator
        = "Successfully imported creator – {0} {1} with {2} boardgames.";

    private const string SuccessfullyImportedSeller
        = "Successfully imported seller - {0} with {1} boardgames.";

    public static string ImportCreators(BoardgamesContext context, string xmlString)
    {
        ImportCreatorsDto[] creators = Deserialize<ImportCreatorsDto[]>(xmlString, "Creators");

        StringBuilder stringBuilder = new StringBuilder();

        foreach (var creatorDto in creators)
        {
            if (!IsValid(creatorDto))
            {
                stringBuilder.AppendLine(ErrorMessage);
                continue;
            }

            Creator creator = new Creator()
            {
                FirstName = creatorDto.FirstName,
                LastName = creatorDto.LastName
            };

            List<Boardgame> boardgames = new List<Boardgame>();
            foreach (var boardgameDto in creatorDto.Boardgames)
            {
                if (!IsValid(boardgameDto) || string.IsNullOrEmpty(boardgameDto.Name))
                {
                    stringBuilder.AppendLine(ErrorMessage);
                    continue;
                }

                Boardgame boardgame = new Boardgame()
                {
                    Name = boardgameDto.Name,
                    Rating = (double)boardgameDto.Rating,
                    YearPublished = boardgameDto.YearPublished,
                    CategoryType = (CategoryType)boardgameDto.CategoryType,
                    Mechanics = boardgameDto.Mechanics
                };

                boardgames.Add(boardgame);
            }

            creator.Boardgames = boardgames;
            context.Creators.Add(creator);

            stringBuilder.AppendLine(string.Format(SuccessfullyImportedCreator, creator.FirstName, creator.LastName,
                creator.Boardgames.Count()));
        }

        context.SaveChanges();

        return stringBuilder.ToString().TrimEnd();
    }

    [SuppressMessage("ReSharper.DPA", "DPA0000: DPA issues")]
    public static string ImportSellers(BoardgamesContext context, string jsonString)
    {
        ImportSellersDto[] sellers = JsonConvert.DeserializeObject<ImportSellersDto[]>(jsonString);

        StringBuilder stringBuilder = new StringBuilder();

        foreach (var sellerDto in sellers)
        {
            if (!IsValid(sellerDto) || string.IsNullOrEmpty(sellerDto.Country))
            {
                stringBuilder.AppendLine(ErrorMessage);
                continue;
            }

            Seller seller = new Seller()
            {
                Name = sellerDto.Name,
                Address = sellerDto.Address,
                Country = sellerDto.Country,
                Website = sellerDto.Website
            };

            foreach (var boardgameId in sellerDto.Boardgames.Distinct())
            {
                if (!context.Boardgames.Any(b => b.Id == boardgameId))
                {
                    stringBuilder.AppendLine(ErrorMessage);
                    continue;
                }

                seller.BoardgamesSellers.Add(new BoardgameSeller()
                {
                    Seller = seller,
                    Boardgame = context.Boardgames.FirstOrDefault(b => b.Id == boardgameId)
                });
            }

            context.Sellers.Add(seller);
            stringBuilder.AppendLine(string.Format(SuccessfullyImportedSeller, seller.Name,
                seller.BoardgamesSellers.Count()));
        }

        context.SaveChanges();

        return stringBuilder.ToString().TrimEnd();
    }

    private static bool IsValid(object dto)
    {
        var validationContext = new ValidationContext(dto);
        var validationResult = new List<ValidationResult>();

        return Validator.TryValidateObject(dto, validationContext, validationResult, true);
    }

    private static T Deserialize<T>(string inputXml, string rootName)
    {
        XmlRootAttribute root = new XmlRootAttribute(rootName);
        XmlSerializer serializer = new XmlSerializer(typeof(T), root);

        using StringReader reader = new StringReader(inputXml);

        T dtos = (T)serializer.Deserialize(reader);
        return dtos;
    }
}