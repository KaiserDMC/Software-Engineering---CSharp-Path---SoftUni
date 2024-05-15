namespace Footballers.DataProcessor;

using System.Text;
using Newtonsoft.Json;
using System.Globalization;
using System.Diagnostics.CodeAnalysis;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

using Data;
using ImportDto;
using Data.Models;
using Data.Models.Enums;

public class Deserializer
{
    private const string ErrorMessage = "Invalid data!";

    private const string SuccessfullyImportedCoach
        = "Successfully imported coach - {0} with {1} footballers.";

    private const string SuccessfullyImportedTeam
        = "Successfully imported team - {0} with {1} footballers.";

    public static string ImportCoaches(FootballersContext context, string xmlString)
    {
        ImportCoachesDto[] coaches = Deserialize<ImportCoachesDto[]>(xmlString, "Coaches");

        StringBuilder stringBuilder = new StringBuilder();

        foreach (var coachDto in coaches)
        {
            if (!IsValid(coachDto) || string.IsNullOrEmpty(coachDto.Nationality))
            {
                stringBuilder.AppendLine(ErrorMessage);
                continue;
            }

            Coach coach = new Coach()
            {
                Name = coachDto.Name,
                Nationality = coachDto.Nationality,
            };

            List<Footballer> footballers = new List<Footballer>();

            foreach (var footballerDto in coachDto.Footballers)
            {
                if (!IsValid(footballerDto) || string.IsNullOrEmpty(footballerDto.ContractStartDate) || string.IsNullOrEmpty(footballerDto.ContractEndDate))
                {
                    stringBuilder.AppendLine(ErrorMessage);
                    continue;
                }

                bool startDate = DateTime.TryParseExact(footballerDto.ContractStartDate, "dd/MM/yyyy",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime start);

                bool endDate = DateTime.TryParseExact(footballerDto.ContractEndDate, "dd/MM/yyyy",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime end);

                if (!startDate || !endDate || start > end)
                {
                    stringBuilder.AppendLine(ErrorMessage);
                    continue;
                }

                Footballer footballer = new Footballer()
                {
                    Name = footballerDto.Name,
                    ContractStartDate = start,
                    ContractEndDate = end,
                    BestSkillType = (BestSkillType)footballerDto.BestSkillType,
                    PositionType = (PositionType)footballerDto.PositionType
                };

                footballers.Add(footballer);
            }

            coach.Footballers = footballers;
            context.Coaches.Add(coach);

            stringBuilder.AppendLine(string.Format(SuccessfullyImportedCoach, coach.Name, coach.Footballers.Count));
        }

        context.SaveChanges();

        return stringBuilder.ToString().TrimEnd();
    }

    [SuppressMessage("ReSharper.DPA", "DPA0000: DPA issues")]
    public static string ImportTeams(FootballersContext context, string jsonString)
    {
        ImportTeamsDto[] teams = JsonConvert.DeserializeObject<ImportTeamsDto[]>(jsonString);

        StringBuilder stringBuilder = new StringBuilder();

        foreach (var teamDto in teams)
        {
            if (!IsValid(teamDto) || string.IsNullOrEmpty(teamDto.Nationality) || teamDto.Trophies == 0)
            {
                stringBuilder.AppendLine(ErrorMessage);
                continue;
            }

            Team team = new Team()
            {
                Name = teamDto.Name,
                Nationality = teamDto.Nationality,
                Trophies = teamDto.Trophies
            };

            foreach (var footballerId in teamDto.Footballers.Distinct())
            {
                if (!context.Footballers.Any(f => f.Id == footballerId))
                {
                    stringBuilder.AppendLine(ErrorMessage);
                    continue;
                }

                team.TeamsFootballers.Add(new TeamFootballer()
                {
                    Team = team,
                    Footballer = context.Footballers.FirstOrDefault(f => f.Id == footballerId)
                });
            }

            context.Teams.Add(team);

            stringBuilder.AppendLine(string.Format(SuccessfullyImportedTeam, team.Name, team.TeamsFootballers.Count));
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