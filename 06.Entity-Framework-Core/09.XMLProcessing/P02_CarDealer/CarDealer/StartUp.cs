namespace CarDealer;

using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;
using DTOs.Export;
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

        // II. Export Data

        //Q14.
        //Console.WriteLine(GetCarsWithDistance(context));
        //File.WriteAllText(@"../../../Results/cars.xml", GetCarsWithDistance(context));

        //Q15.
        //Console.WriteLine(GetCarsFromMakeBmw(context));
        //File.WriteAllText(@"../../../Results/bmw-cars.xml", GetCarsFromMakeBmw(context));

        //Q16.
        //Console.WriteLine(GetLocalSuppliers(context));
        //File.WriteAllText(@"../../../Results/local-suppliers.xml", GetLocalSuppliers(context));

        //Q17.
        //Console.WriteLine(GetCarsWithTheirListOfParts(context));
        //File.WriteAllText(@"../../../Results/cars-and-parts.xml", GetCarsWithTheirListOfParts(context));

        //Q18.
        //Console.WriteLine(GetTotalSalesByCustomer(context));
        //File.WriteAllText(@"../../../Results/customers-total-sales.xml", GetTotalSalesByCustomer(context));

        //Q19.
        Console.WriteLine(GetSalesWithAppliedDiscount(context));
        File.WriteAllText(@"../../../Results/sales-discounts.xml", GetSalesWithAppliedDiscount(context));
    }

    private static string Serializer<T>(T dataTransferObjects, string xmlRootAttributeName)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(T), new XmlRootAttribute(xmlRootAttributeName));

        StringBuilder sb = new StringBuilder();
        using var write = new StringWriter(sb);

        XmlSerializerNamespaces xmlNamespaces = new XmlSerializerNamespaces();
        xmlNamespaces.Add(string.Empty, string.Empty);

        serializer.Serialize(write, dataTransferObjects, xmlNamespaces);

        return sb.ToString();
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

    // 14. Export Cars With Distance
    public static string GetCarsWithDistance(CarDealerContext context)
    {
        var cars = context.Cars
            .Where(c => c.TraveledDistance > 2000000)
            .OrderBy(c => c.Make)
            .ThenBy(c => c.Model)
            .Take(10)
            .Select(c => new ExportCarsWithDistanceDto()
            {
                Make = c.Make,
                Model = c.Model,
                TraveledDistance = c.TraveledDistance,
            })
            .ToArray();

        return Serializer<ExportCarsWithDistanceDto[]>(cars, "cars");
    }

    // 15. Export Cars from Make BMW
    public static string GetCarsFromMakeBmw(CarDealerContext context)
    {
        var bmwCars = context.Cars
            .Where(c => c.Make == "BMW")
            .OrderBy(c => c.Model)
            .ThenByDescending(c => c.TraveledDistance)
            .Select(c => new ExportCarsFromMakeBMWDto()
            {
                Id = c.Id,
                Model = c.Model,
                TraveledDistance = c.TraveledDistance
            })
            .ToArray();

        return Serializer<ExportCarsFromMakeBMWDto[]>(bmwCars, "cars");
    }

    // 16. Export Local Suppliers
    public static string GetLocalSuppliers(CarDealerContext context)
    {
        var localSuppliers = context.Suppliers
            .Where(s => !s.IsImporter)
            .Select(s => new ExportLocalSuppliersDto()
            {
                Id = s.Id,
                Name = s.Name,
                PartsCount = s.Parts.Count
            })
            .ToArray();

        return Serializer<ExportLocalSuppliersDto[]>(localSuppliers, "suppliers");
    }

    // 17. Export Cars with Their List of Parts
    public static string GetCarsWithTheirListOfParts(CarDealerContext context)
    {
        var carsWithParts = context.Cars
            .OrderByDescending(c => c.TraveledDistance)
            .ThenBy(c => c.Model)
            .Take(5)
            .Select(c => new ExportCarsWithTheirListOfPartsDto()
            {
                Make = c.Make,
                Model = c.Model,
                TraveledDistance = c.TraveledDistance,
                PartsFromCars = c.PartsCars
                    .Select(p => new PartsFromCars()
                    {
                        Name = p.Part.Name,
                        Price = p.Part.Price,
                    })
                    .OrderByDescending(p => p.Price)
                    .ToArray()
            })
            .ToArray();

        return Serializer<ExportCarsWithTheirListOfPartsDto[]>(carsWithParts, "cars");
    }

    // 18. Export Total Sales by Customer
    public static string GetTotalSalesByCustomer(CarDealerContext context)
    {
        var customerSales = context.Customers
            .Where(cus => cus.Sales.Any())
            .Select(cus => new
            {
                fullName = cus.Name,
                boughtCars = cus.Sales.Count(),
                moneyCars = cus.IsYoungDriver
                    ? cus.Sales.SelectMany(s => s.Car.PartsCars.Select(p => Math.Round(p.Part.Price * 0.95m, 2)))
                    : cus.Sales.SelectMany(s => s.Car.PartsCars.Select(p => Math.Round(p.Part.Price, 2)))
            })
            .ToArray();

        var output = customerSales
            .Select(o => new ExportTotalSalesByCustomerDto()
            {
                FullName = o.fullName,
                BoughtCars = o.boughtCars,
                SpentMoney = o.moneyCars.Sum()
            })
            .OrderByDescending(o => o.SpentMoney)
            .ToArray();

        return Serializer<ExportTotalSalesByCustomerDto[]>(output, "customers");
    }

    // 19. Export Sales with Applied Discount
    public static string GetSalesWithAppliedDiscount(CarDealerContext context)
    {
        var sales = context.Sales
            .Select(s => new ExportSalesWithAppliedDiscountDto()
            {
                CarDtoSales = new CarDtoSales()
                {
                    Make = s.Car.Make,
                    Model = s.Car.Model,
                    TraveledDistance = s.Car.TraveledDistance
                },

                Discount = (int)s.Discount,
                CustomerName = s.Customer.Name,
                Price = s.Car.PartsCars.Sum(p => p.Part.Price).ToString("0.00"),
                PriceWithDiscount = Math.Round((double)(s.Car.PartsCars.Sum(p => p.Part.Price) * (1 - (s.Discount / 100))), 4)
            })
            .ToArray();

        return Serializer<ExportSalesWithAppliedDiscountDto[]>(sales, "sales");
    }
}