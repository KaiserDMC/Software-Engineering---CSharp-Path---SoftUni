namespace CarDealer;

using System.Diagnostics.CodeAnalysis;
using System.Xml.Linq;
using System.Xml.Serialization;
using DTOs.Import;
using Data;
using Models;


public class StartUp
{
    [SuppressMessage("ReSharper.DPA", "DPA0000: DPA issues")]
    public static void Main()
    {
        CarDealerContext context = new CarDealerContext();

        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();

        // I. Import Data

        //Q09.
        string xmlSuppliers = File.ReadAllText(@"../../../Datasets/suppliers.xml");
        ImportSuppliers(context, xmlSuppliers);

        //Q10.
        string xmlParts = File.ReadAllText(@"../../../Datasets/parts.xml");
        ImportParts(context, xmlParts);

        //Q11.
        string xmlCars = File.ReadAllText(@"../../../Datasets/cars.xml");
        ImportCars(context, xmlCars);

        //Q12.
        string xmlCustomers = File.ReadAllText(@"../../../Datasets/customers.xml");
        ImportCustomers(context, xmlCustomers);

        //Q13.
        string xmlSales = File.ReadAllText(@"../../../Datasets/sales.xml");
        ImportSales(context, xmlSales);
    }

    private static T Deserializer<T>(string inputXml, string rootName)
    {
        XmlRootAttribute root = new XmlRootAttribute(rootName);
        XmlSerializer serializer = new XmlSerializer(typeof(T), root);

        using StringReader reader = new StringReader(inputXml);

        T dtos = (T)serializer.Deserialize(reader);
        return dtos;
    }

    // 09. Import Suppliers
    public static string ImportSuppliers(CarDealerContext context, string inputXml)
    {
        XDocument xmDocument = XDocument.Parse(inputXml);

        var suppliers = xmDocument.Root.Elements();

        foreach (var supplier in suppliers)
        {
            Supplier s = new Supplier()
            {
                Name = supplier.Element("name").Value,
                IsImporter = bool.Parse(supplier.Element("isImporter").Value)
            };

            context.Suppliers.Add(s);
        }

        context.SaveChanges();

        return $"Successfully imported {suppliers.Count()}";
    }

    // 10. Import Parts
    [SuppressMessage("ReSharper.DPA", "DPA0000: DPA issues")]
    public static string ImportParts(CarDealerContext context, string inputXml)
    {
        XDocument xmDocument = XDocument.Parse(inputXml);

        var parts = xmDocument.Root.Elements();

        foreach (var part in parts)
        {
            int suppId = int.Parse(part.Element("supplierId").Value);
            if (!context.Suppliers.Any(s => s.Id == suppId))
            {
                continue;
            }

            Part p = new Part()
            {
                Name = part.Element("name").Value,
                Price = decimal.Parse(part.Element("price").Value),
                Quantity = int.Parse(part.Element("quantity").Value),
                SupplierId = int.Parse(part.Element("supplierId").Value)
            };

            context.Parts.Add(p);
        }

        context.SaveChanges();

        return $"Successfully imported {context.Parts.Count()}";
    }

    public static string ImportCars(CarDealerContext context, string inputXml)
    {
        XDocument xmlDocument = XDocument.Parse(inputXml);

        var cars = xmlDocument.Root.Elements();

        List<Car> carsX = new List<Car>();
        List<PartCar> partsX = new List<PartCar>();

        int carId = 1;

        int[] partInts = context.Parts.Select(p => p.Id).ToArray();
        var partIds = xmlDocument.Descendants("partId").Select(p => p.Attribute("id").Value);

        foreach (var car in cars)
        {
            Car c = new Car()
            {
                Make = car.Element("make").Value,
                Model = car.Element("model").Value,
                TraveledDistance = long.Parse(car.Element("traveledDistance").Value)
                //TraveledDistance = long.Parse(car.Element("TraveledDistance").Value)
                //For Judge use commented line
            };

            carsX.Add(c);

            foreach (var partId in car.Descendants("partId")
                         .Where(p => partIds.Contains(p.Attribute("id").Value))
                         .Select(p => p.Attribute("id").Value).Distinct())
            {
                PartCar partCar = new PartCar()
                {
                    CarId = carId,
                    Car = c,
                    PartId = int.Parse(partId)
                };

                partsX.Add(partCar);
            }

            carId++;
        }

        context.AddRange(carsX);
        context.AddRange(partsX);

        context.SaveChanges();

        return $"Successfully imported {carsX.Count}";
    }

    // 12. Import Customers
    public static string ImportCustomers(CarDealerContext context, string inputXml)
    {
        XDocument xmlDocument = XDocument.Parse(inputXml);

        var customers = xmlDocument.Root.Elements();

        foreach (var customer in customers)
        {
            Customer c = new Customer()
            {
                Name = customer.Element("name").Value,
                BirthDate = DateTime.Parse(customer.Element("birthDate").Value),
                IsYoungDriver = bool.Parse(customer.Element("isYoungDriver").Value)
            };

            context.Customers.Add(c);
        }

        context.SaveChanges();

        return $"Successfully imported {customers.Count()}";
    }

    // 13. Import Sales
    public static string ImportSales(CarDealerContext context, string inputXml)
    {
        XDocument xmlDocument = XDocument.Parse(inputXml);

        var sales = xmlDocument.Root.Elements();

        int[] allCarIds = context.Cars.Select(c => c.Id).ToArray();

        foreach (var sale in sales)
        {
            if (!allCarIds.Contains(int.Parse(sale.Element("carId").Value)))
            {
                continue;
            }

            Sale s = new Sale()
            {
                CarId = int.Parse(sale.Element("carId").Value),
                CustomerId = int.Parse(sale.Element("customerId").Value),
                Discount = decimal.Parse(sale.Element("discount").Value)
            };

            context.Sales.Add(s);
        }

        context.SaveChanges();

        return $"Successfully imported {context.Sales.Count()}";
    }
}