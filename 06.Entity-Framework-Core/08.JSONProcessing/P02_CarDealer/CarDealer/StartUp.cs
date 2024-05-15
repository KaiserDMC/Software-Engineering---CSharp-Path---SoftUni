
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;

namespace CarDealer;

using Data;
using Models;
using DTOs.Import;
using Newtonsoft.Json;

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
        string jsonSuppliers = File.ReadAllText(@"../../../Datasets/suppliers.json");
        ImportSuppliers(context, jsonSuppliers);

        //Q10.
        string jsonParts = File.ReadAllText(@"../../../Datasets/parts.json");
        ImportParts(context, jsonParts);

        //Q11.
        string jsonCars = File.ReadAllText(@"../../../Datasets/cars.json");
        ImportCars(context, jsonCars);

        //Q12.
        string jsonCustomers = File.ReadAllText(@"../../../Datasets/customers.json");
        ImportCustomers(context, jsonCustomers);

        //Q13.
        string jsonSales = File.ReadAllText(@"../../../Datasets/sales.json");
        ImportSales(context, jsonSales);

        // II. Export Data

        //Q14.
        //Console.WriteLine(GetOrderedCustomers(context));
        //File.WriteAllText(@"../../../Results/ordered-customers.json", GetOrderedCustomers(context));

        //Q15.
        //Console.WriteLine(GetCarsFromMakeToyota(context));
        //File.WriteAllText(@"../../../Results/toyota-cars.json", GetCarsFromMakeToyota(context));

        //Q16.
        //Console.WriteLine(GetLocalSuppliers(context));
        //File.WriteAllText(@"../../../Results/local-suppliers.json", GetLocalSuppliers(context));

        //Q17.
        //Console.WriteLine(GetCarsWithTheirListOfParts(context));
        //File.WriteAllText(@"../../../Results/cars-and-parts.json", GetCarsWithTheirListOfParts(context));

        //Q18.
        //Console.WriteLine(GetTotalSalesByCustomer(context));
        //File.WriteAllText(@"../../../Results/customers-total-sales.json", GetTotalSalesByCustomer(context));

        //Q19.
        Console.WriteLine(GetSalesWithAppliedDiscount(context));
        File.WriteAllText(@"../../../Results/sales-discounts.json", GetSalesWithAppliedDiscount(context));

    }

    // 09. Import Suppliers
    public static string ImportSuppliers(CarDealerContext context, string inputJson)
    {
        List<Supplier> suppliers = JsonConvert.DeserializeObject<List<Supplier>>(inputJson)!;
        context.AddRange(suppliers);
        context.SaveChanges();

        return $"Successfully imported {suppliers.Count}.";
    }

    // 10. Import Parts
    public static string ImportParts(CarDealerContext context, string inputJson)
    {
        List<int> supplierListIds = context.Suppliers
            .Select(s => s.Id)
            .ToList();

        List<Part> parts = JsonConvert
            .DeserializeObject<List<Part>>(inputJson)!
            .Where(p => supplierListIds.Contains(p.SupplierId))
            .ToList();

        context.AddRange(parts);
        context.SaveChanges();

        return $"Successfully imported {parts.Count}.";
    }

    // 11. Import Cars
    public static string ImportCars(CarDealerContext context, string inputJson)
    {
        List<CarDto> carsDtos = JsonConvert.DeserializeObject<List<CarDto>>(inputJson);

        List<Car> cars = new List<Car>();
        List<PartCar> parts = new List<PartCar>();

        foreach (var carDto in carsDtos)
        {
            Car car = new Car()
            {
                Make = carDto.Make,
                Model = carDto.Model,
                TraveledDistance = carDto.TravelledDistance
            };

            cars.Add(car);

            foreach (var carPart in carDto.PartIds.Distinct())
            {
                PartCar partCar = new PartCar()
                {
                    Car = car,
                    PartId = carPart
                };

                parts.Add(partCar);
            }
        }

        context.AddRange(cars);
        context.AddRange(parts);
        context.SaveChanges();

        return $"Successfully imported {cars.Count}.";
    }

    // 12. Import Customers
    public static string ImportCustomers(CarDealerContext context, string inputJson)
    {
        List<Customer> customers = JsonConvert.DeserializeObject<List<Customer>>(inputJson)!;
        context.AddRange(customers);
        context.SaveChanges();

        return $"Successfully imported {customers.Count}.";
    }

    // 13. Import Sales
    public static string ImportSales(CarDealerContext context, string inputJson)
    {
        List<Sale> sales = JsonConvert.DeserializeObject<List<Sale>>(inputJson)!;
        context.AddRange(sales);
        context.SaveChanges();

        return $"Successfully imported {sales.Count}.";
    }

    // 14. Export Ordered Customers
    public static string GetOrderedCustomers(CarDealerContext context)
    {
        var customers = context.Customers
            .OrderBy(c => c.BirthDate)
            .ThenBy(c => c.IsYoungDriver)
            .Select(c => new
            {
                Name = c.Name,
                BirthDate = c.BirthDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                IsYoungDriver = c.IsYoungDriver
            })
            .AsNoTracking()
            .ToArray();

        return JsonConvert.SerializeObject(customers, Formatting.Indented);
    }

    // 15. Export Cars from Make Toyota
    [SuppressMessage("ReSharper.DPA", "DPA0000: DPA issues")]
    public static string GetCarsFromMakeToyota(CarDealerContext context)
    {
        var carsToyota = context.Cars
            .Where(c => c.Make == "Toyota")
            .OrderBy(c => c.Model)
            .ThenByDescending(c => c.TraveledDistance)
            .Select(c => new
            {
                Id = c.Id,
                Make = c.Make,
                Model = c.Model,
                TraveledDistance = c.TraveledDistance,
            })
            .AsNoTracking()
            .ToArray();

        return JsonConvert.SerializeObject(carsToyota, Formatting.Indented);
    }

    // 16. Export Local Suppliers
    public static string GetLocalSuppliers(CarDealerContext context)
    {
        var localSuppliers = context.Suppliers
            .Where(s => !s.IsImporter)
            .Select(s => new
            {
                Id = s.Id,
                Name = s.Name,
                PartsCount = context.Parts
                    .Count(p => p.SupplierId == s.Id)
            })
            .AsNoTracking()
            .ToArray();

        return JsonConvert.SerializeObject(localSuppliers, Formatting.Indented);
    }

    // 17. Export Cars with Their List of Parts
    [SuppressMessage("ReSharper.DPA", "DPA0000: DPA issues")]
    public static string GetCarsWithTheirListOfParts(CarDealerContext context)
    {
        var carsWithParts = context.Cars
            .Select(c => new
            {
                car = new
                {
                    Make = c.Make,
                    Model = c.Model,
                    TraveledDistance = c.TraveledDistance
                },
                parts = c.PartsCars.Select(p => new
                {
                    Name = p.Part.Name,
                    Price = p.Part.Price.ToString("0.00"),
                })
            })
            .AsNoTracking()
            .ToArray();

        return JsonConvert.SerializeObject(carsWithParts, Formatting.Indented);
    }

    // 18. Export Total Sales by Customer
    public static string GetTotalSalesByCustomer(CarDealerContext context)
    {
        var customers = context.Customers
            .Where(cus => cus.Sales.Any())
            .Select(cus => new
            {
                fullName = cus.Name,
                boughtCars = cus.Sales.Count(),
                moneyCars = cus.Sales
                    .SelectMany(c => c.Car.PartsCars.Select(p => p.Part.Price))
            })
            .AsNoTracking()
            .ToArray();

        var output = customers
            .Select(o => new
            {
                o.fullName,
                o.boughtCars,
                spentMoney = o.moneyCars.Sum()
            })
            .OrderByDescending(o => o.spentMoney)
            .ThenByDescending(o => o.boughtCars)
            .ToArray();

        return JsonConvert.SerializeObject(output, Formatting.Indented);
    }

    // 19. Export Sales with Applied Discount
    public static string GetSalesWithAppliedDiscount(CarDealerContext context)
    {
        var sales = context.Sales
            .Take(10)
            .Select(s => new
            {
                car = new
                {
                    Make = s.Car.Make,
                    Model = s.Car.Model,
                    TraveledDistance = s.Car.TraveledDistance,
                },

                customerName = s.Customer.Name,
                discount = s.Discount.ToString("0.00"),
                price = s.Car.PartsCars.Sum(p => p.Part.Price).ToString("0.00"),
                priceWithDiscount = (s.Car.PartsCars.Sum(p => p.Part.Price) * (1 - (s.Discount / 100))).ToString("0.00")
            })
            .AsNoTracking()
            .ToArray();

        return JsonConvert.SerializeObject(sales, Formatting.Indented);
    }
}