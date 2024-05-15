namespace Trucks.DataProcessor;

using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Xml.Serialization;
using Newtonsoft.Json;

using Data;
using ExportDto;

public class Serializer
{
    public static string ExportDespatchersWithTheirTrucks(TrucksContext context)
    {
        var despatchersWithTrucks = context.Despatchers
            .Where(d => d.Trucks.Any())
            .ToArray()
            .Select(d => new ExportDespatchersWithTheirTrucksDto()
            {
                TruckCount = d.Trucks.Count(),
                Name = d.Name,
                Trucks = d.Trucks
                    .Select(t => new TruckXML()
                    {
                        RegistrationNumber = t.RegistrationNumber,
                        Make = t.MakeType.ToString()
                    })
                    .OrderBy(t => t.RegistrationNumber)
                    .ToArray()
            })
            .OrderByDescending(d => d.TruckCount)
            .ThenBy(d => d.Name)
            .ToArray();

        return Serialize<ExportDespatchersWithTheirTrucksDto[]>(despatchersWithTrucks, "Despatchers");
    }

    [SuppressMessage("ReSharper.DPA", "DPA0000: DPA issues")]
    public static string ExportClientsWithMostTrucks(TrucksContext context, int capacity)
    {
        var clientsWithTrucks = context.Clients
            .Where(c => c.ClientsTrucks.Any(t => t.Truck.TankCapacity >= capacity))
            .ToArray()
            .Select(c => new ExportClientsWithMostTrucksDto()
            {
                ClientName = c.Name,
                Trucks = c.ClientsTrucks
                    .Where(t => t.Truck.TankCapacity >= capacity)
                    .Select(t => new TruckJson()
                    {
                        RegistrationNumber = t.Truck.RegistrationNumber,
                        VinNumber = t.Truck.VinNumber,
                        TankCapacity = t.Truck.TankCapacity,
                        CargoCapacity = t.Truck.CargoCapacity,
                        CategoryType = t.Truck.CategoryType.ToString(),
                        MakeType = t.Truck.MakeType.ToString()
                    })
                    .OrderBy(t => t.MakeType)
                    .ThenByDescending(t => t.CargoCapacity)
                    .ToArray()
            })
            .OrderByDescending(c => c.Trucks.Count())
            .ThenBy(c => c.ClientName)
            .Take(10)
            .ToArray();

        return JsonConvert.SerializeObject(clientsWithTrucks, Formatting.Indented);
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