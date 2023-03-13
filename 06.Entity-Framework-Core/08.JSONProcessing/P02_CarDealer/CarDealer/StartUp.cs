namespace CarDealer;

using Data;
using Models;
using Newtonsoft.Json;

public class StartUp
{
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
        List<Car> cars = JsonConvert.DeserializeObject<List<Car>>(inputJson)!;
        context.AddRange(cars);
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
}