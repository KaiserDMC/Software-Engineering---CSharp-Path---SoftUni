using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace ProductShop;

using Newtonsoft.Json;
using Data;
using Models;

public class StartUp
{
    [SuppressMessage("ReSharper.DPA", "DPA0000: DPA issues")]
    public static void Main()
    {
        ProductShopContext context = new ProductShopContext();

        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();

        // I. Import Data

        //Q01.
        string jsonUsers = File.ReadAllText(@"../../../Datasets/users.json");
        ImportUsers(context, jsonUsers);

        //Q02.
        string jsonProducts = File.ReadAllText(@"../../../Datasets/products.json");
        ImportProducts(context, jsonProducts);

        //Q03.
        string jsonCategories = File.ReadAllText(@"../../../Datasets/categories.json");
        ImportCategories(context, jsonCategories);

        //Q04.
        string jsonCategoryProducts = File.ReadAllText(@"../../../Datasets/categories-products.json");
        ImportCategoryProducts(context, jsonCategoryProducts);

        // II. Export Data

        //Q05.
        //Console.WriteLine(GetProductsInRange(context));
        //File.WriteAllText(@"../../../Results/products-in-range.json", GetProductsInRange(context));

        //Q06.
        //Console.WriteLine(GetSoldProducts(context));
        //File.WriteAllText(@"../../../Results/user-sold-products.json", GetSoldProducts(context));

        //Q07.
        //Console.WriteLine(GetCategoriesByProductsCount(context));
        //File.WriteAllText(@"../../../Results/categories-by-products.json", GetCategoriesByProductsCount(context));

        //Q08.
        Console.WriteLine(GetUsersWithProducts(context).Substring(900, 20));
        Console.WriteLine(GetUsersWithProducts(context).Length);
        Console.WriteLine(GetUsersWithProducts(context));
        File.WriteAllText(@"../../../Results/users-and-products.json", GetUsersWithProducts(context));


    }

    // 01. Import Users
    public static string ImportUsers(ProductShopContext context, string inputJson)
    {
        List<User> users = JsonConvert.DeserializeObject<List<User>>(inputJson)!;
        context.AddRange(users);
        context.SaveChanges();

        return $"Successfully imported {users.Count}";
    }

    // 02. Import Products
    public static string ImportProducts(ProductShopContext context, string inputJson)
    {
        List<Product> products = JsonConvert.DeserializeObject<List<Product>>(inputJson)!;
        context.AddRange(products);
        context.SaveChanges();

        return $"Successfully imported {products.Count}";
    }

    // 03. Import Categories
    public static string ImportCategories(ProductShopContext context, string inputJson)
    {
        List<Category> categories =
            JsonConvert.DeserializeObject<List<Category>>(inputJson)
            .Where(c => c.Name != null)
            .ToList();

        context.AddRange(categories);
        context.SaveChanges();

        return $"Successfully imported {categories.Count}";
    }

    // 04. Import Categories and Products
    public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
    {
        List<CategoryProduct> categoryProducts = JsonConvert.DeserializeObject<List<CategoryProduct>>(inputJson);

        context.AddRange(categoryProducts);
        context.SaveChanges();

        return $"Successfully imported {categoryProducts.Count}";
    }

    // 05. Export Products in Range
    public static string GetProductsInRange(ProductShopContext context)
    {
        var products = context.Products
            .Where(p => p.Price >= 500 && p.Price <= 1000)
            .Select(p => new
            {
                name = p.Name,
                price = p.Price,
                seller = p.Seller.FirstName + " " + p.Seller.LastName
            })
            .OrderBy(p => p.price)
            .AsNoTracking()
            .ToArray();

        string jsonOutput = JsonConvert.SerializeObject(products, Formatting.Indented);

        return jsonOutput;
    }

    // 06. Export Sold Products
    public static string GetSoldProducts(ProductShopContext context)
    {
        var soldProducts = context.Users
            .Where(u => u.ProductsSold.Any(p => p.BuyerId != null))
            .Select(u => new
            {
                firstName = u.FirstName,
                lastName = u.LastName,
                soldProducts = u.ProductsSold
                    .Select(p => new
                    {
                        name = p.Name,
                        price = p.Price,
                        buyerFirstName = p.Buyer.FirstName,
                        buyerLastName = p.Buyer.LastName,
                    })
            })
            .OrderBy(x => x.lastName)
            .ThenBy(x => x.firstName)
            .AsNoTracking()
            .ToArray();

        string jsonOutput = JsonConvert.SerializeObject(soldProducts, Formatting.Indented);

        return jsonOutput;
    }

    // 07. Export Categories by Products Count
    public static string GetCategoriesByProductsCount(ProductShopContext context)
    {
        var categories = context.Categories
            .Select(cp => new
            {
                category = cp.Name,
                productsCount = cp.CategoriesProducts.Count,
                averagePrice = Math.Round((double)cp.CategoriesProducts.Average(p => p.Product.Price), 2),
                totalRevenue = Math.Round((double)cp.CategoriesProducts.Sum(p => p.Product.Price), 2)
            })
            .OrderByDescending(x => x.productsCount)
            .AsNoTracking()
            .ToArray();

        return JsonConvert.SerializeObject(categories, Formatting.Indented);
    }

    // 08. Export Users and Products
    public static string GetUsersWithProducts(ProductShopContext context)
    {
        var users = context.Users
            .Where(u => u.ProductsSold.Any(p => p.BuyerId != null))
            .OrderByDescending(u => u.ProductsSold.Count(p => p.BuyerId != null))
            .Select(u => new
            {
                firstName = u.FirstName,
                lastName = u.LastName,
                age = u.Age,
                soldProducts = new
                {
                    count = u.ProductsSold
                            .Count(p => p.BuyerId != null),
                    products = u.ProductsSold
                            .Where(p => p.BuyerId != null)
                            .Select(p => new
                            {
                                name = p.Name,
                                price = p.Price
                            })
                }
            })
            .AsNoTracking()
            .ToArray();

        var info = new
        {
            usersCount = users.Count(),
            users = users
        };

        string jsonOutput = JsonConvert.SerializeObject(info, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

        return jsonOutput;
    }
}