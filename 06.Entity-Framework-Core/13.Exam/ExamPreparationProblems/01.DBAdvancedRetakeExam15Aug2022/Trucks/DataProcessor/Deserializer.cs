namespace Trucks.DataProcessor;

using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using Newtonsoft.Json;

using Data;
using Data.Models;
using Data.Models.Enums;
using ImportDto;

public class Deserializer
{
    private const string ErrorMessage = "Invalid data!";

    private const string SuccessfullyImportedDespatcher
        = "Successfully imported despatcher - {0} with {1} trucks.";

    private const string SuccessfullyImportedClient
        = "Successfully imported client - {0} with {1} trucks.";

    public static string ImportDespatcher(TrucksContext context, string xmlString)
    {
        ImportDespatchersDto[] despatchers = Deserialize<ImportDespatchersDto[]>(xmlString, "Despatchers");

        StringBuilder stringBuilder = new StringBuilder();

        foreach (var despatcherDto in despatchers)
        {
            if (!IsValid(despatcherDto))
            {
                stringBuilder.AppendLine(ErrorMessage);
                continue;
            }

            if (string.IsNullOrEmpty(despatcherDto.Position))
            {
                stringBuilder.AppendLine(ErrorMessage);
                continue;
            }

            Despatcher despatcher = new Despatcher()
            {
                Name = despatcherDto.Name,
                Position = despatcherDto.Position
            };

            List<Truck> trucks = new List<Truck>();
            foreach (var truckDto in despatcherDto.Trucks)
            {
                if (!IsValid(truckDto))
                {
                    stringBuilder.AppendLine(ErrorMessage);
                    continue;
                }

                Truck truck = new Truck()
                {
                    RegistrationNumber = truckDto.RegistrationNumber,
                    VinNumber = truckDto.VinNumber,
                    TankCapacity = truckDto.TankCapacity,
                    CargoCapacity = truckDto.CargoCapacity,
                    CategoryType = (CategoryType)truckDto.CategoryType,
                    MakeType = (MakeType)truckDto.MakeType,
                    Despatcher = despatcher
                };

                trucks.Add(truck);
            }

            despatcher.Trucks = trucks;
            context.Despatchers.Add(despatcher);
            context.SaveChanges();

            stringBuilder.AppendLine(string.Format(SuccessfullyImportedDespatcher, despatcher.Name, despatcher.Trucks.Count));
        }

        return stringBuilder.ToString().TrimEnd();
    }

    [SuppressMessage("ReSharper.DPA", "DPA0000: DPA issues")]
    public static string ImportClient(TrucksContext context, string jsonString)
    {
        ImportClientsDto[] clients = JsonConvert.DeserializeObject<ImportClientsDto[]>(jsonString);

        StringBuilder stringBuilder = new StringBuilder();

        foreach (var clientDto in clients)
        {
            if (!IsValid(clientDto) || string.IsNullOrEmpty(clientDto.Nationality) || clientDto.Type == "usual")
            {
                stringBuilder.AppendLine(ErrorMessage);
                continue;
            }

            Client client = new Client()
            {
                Name = clientDto.Name,
                Nationality = clientDto.Nationality,
                Type = clientDto.Type
            };

            foreach (var truckId in clientDto.TruckIds.Distinct())
            {
                if (!context.Trucks.Any(t => t.Id == truckId))
                {
                    stringBuilder.AppendLine(ErrorMessage);
                    continue;
                }

                client.ClientsTrucks.Add(new ClientTruck()
                {
                    Client = client,
                    Truck = context.Trucks.FirstOrDefault(t => t.Id == truckId)
                });
            }

            context.Clients.Add(client);
            context.SaveChanges();
            stringBuilder.AppendLine(String.Format(SuccessfullyImportedClient, client.Name,
                client.ClientsTrucks.Count));
        }

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