using System.Diagnostics.CodeAnalysis;

namespace ProductShop;

using System.Text;
using System.Xml.Linq;
using DTOs.Export;
using Data;
using Models;
using System.Xml.Serialization;

public class StartUp
{
    public static void Main()
    {
        ProductShopContext context = new ProductShopContext();

        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();

        // I. Import Data

        //Q01.
        string xmlUsers = @"../../../Datasets/users.xml";
        ImportUsers(context, xmlUsers);

        //Q02.
        string xmlProducts = File.ReadAllText(@"../../../Datasets/products.xml");
        ImportProducts(context, xmlProducts);

        //Q03.
        string xmlCategories = File.ReadAllText(@"../../../Datasets/categories.xml");
        ImportCategories(context, xmlCategories);

        //Q04.
        string xmlCategoryProducts = File.ReadAllText(@"../../../Datasets/categories-products.xml");
        ImportCategoryProducts(context, xmlCategoryProducts);

        // II. Export Data

        //Q05.
        string xmlProductsInRange = GetProductsInRange(context);
        File.WriteAllText(@"../../../Results/products-in-range.xml", xmlProductsInRange);

        //Q06.
        string xmlSoldProducts = GetSoldProducts(context);
        File.WriteAllText(@"../../../Results/users-sold-products.xml", xmlSoldProducts);

        //Q07.
        string xmlCategoriesByProductsCount = GetCategoriesByProductsCount(context);
        File.WriteAllText(@"../../../Results/categories-by-products.xml", xmlCategoriesByProductsCount);

        //Q08.
        string xmlUsersWithProducts = GetUsersWithProducts(context);
        File.WriteAllText(@"../../../Results/users-and-products.xml", xmlUsersWithProducts);

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

    // 01. Import Users
    public static string ImportUsers(ProductShopContext context, string inputXml)
    {
        XDocument xmlDocument = XDocument.Load(inputXml);

        var users = xmlDocument.Root.Elements();

        foreach (var user in users)
        {
            User u = new User()
            {
                FirstName = user.Element("firstName").Value,
                LastName = user.Element("lastName").Value,
                Age = int.Parse(user.Element("age").Value)
            };

            context.Users.Add(u);
        }

        context.SaveChanges();

        return $"Successfully imported {users.Count()}";
    }

    // 02. Import Products
    public static string ImportProducts(ProductShopContext context, string inputXml)
    {
        XDocument xmlDocument = XDocument.Parse(inputXml);

        var products = xmlDocument.Root.Elements();

        foreach (var product in products)
        {
            Product p = new Product()
            {
                Name = product.Element("name").Value,
                Price = decimal.Parse(product.Element("price").Value),
                SellerId = int.Parse(product.Element("sellerId").Value),
                BuyerId = product.Elements().Count() > 3 ? int.Parse(product.Element("buyerId")!.Value) : null
            };

            context.Products.Add(p);
        }

        context.SaveChanges();

        return $"Successfully imported {products.Count()}";
    }

    // 03. Import Categories
    public static string ImportCategories(ProductShopContext context, string inputXml)
    {
        XDocument xmlDocument = XDocument.Parse(inputXml);

        var categories = xmlDocument.Root.Elements();

        foreach (var category in categories)
        {
            Category c = new Category()
            {
                Name = category.Element("name").Value
            };

            context.Categories.Add(c);
        }

        context.SaveChanges();

        return $"Successfully imported {categories.Count()}";
    }

    // 04. Import Categories and Products
    public static string ImportCategoryProducts(ProductShopContext context, string inputXml)


    {
        XDocument xmDocument = XDocument.Parse(inputXml);

        var categoryProducts = xmDocument.Root.Elements();

        foreach (var categoryProduct in categoryProducts)
        {
            CategoryProduct cp = new CategoryProduct()
            {
                CategoryId = int.Parse(categoryProduct.Element("CategoryId").Value),
                ProductId = int.Parse(categoryProduct.Element("ProductId").Value)
            };

            context.CategoryProducts.Add(cp);
        }

        context.SaveChanges();

        return $"Successfully imported {categoryProducts.Count()}";
    }

    // 05. Export Products In Range
    public static string GetProductsInRange(ProductShopContext context)
    {
        var productsInRange = context.Products
            .Where(p => p.Price >= 500 && p.Price <= 1000)
            .OrderBy(p => p.Price)
            .Take(10)
            .Select(p => new ExportProductsInRangeDto()
            {
                Price = p.Price,
                Name = p.Name,
                Buyer = p.Buyer.FirstName + " " + p.Buyer.LastName
            })
            .ToArray();

        return Serializer<ExportProductsInRangeDto[]>(productsInRange, "Products");
    }

    // 06. Export Sold Products
    public static string GetSoldProducts(ProductShopContext context)
    {
        var products = context.Users
            .Where(u => u.ProductsSold.Any(p => p.BuyerId != null))
            .OrderBy(u => u.LastName)
            .ThenBy(u => u.FirstName)
            .Take(5)
            .Select(u => new ExportSoldProductsDto()
            {
                FirstName = u.FirstName,
                LastName = u.LastName,
                Products = u.ProductsSold
                    .Select(p => new ProductDto()
                    {
                        Name = p.Name,
                        Price = p.Price
                    })
                    .ToArray()
            })
            .ToArray();

        return Serializer<ExportSoldProductsDto[]>(products, "Users");
    }

    // 07. Export Categories By Products Count
    public static string GetCategoriesByProductsCount(ProductShopContext context)
    {
        var categories = context.Categories
            .Select(c => new ExportCategoriesByProductsCountDto()
            {
                Name = c.Name,
                Count = c.CategoryProducts.Count,
                AveragePrice = c.CategoryProducts.Average(p => p.Product.Price),
                TotalRevenue = c.CategoryProducts.Sum(p => p.Product.Price)
            })
            .OrderByDescending(p => p.Count)
            .ThenBy(p => p.TotalRevenue)
            .ToArray();

        return Serializer<ExportCategoriesByProductsCountDto[]>(categories, "Categories");
    }

    // 08. Export Users and Products
    [SuppressMessage("ReSharper.DPA", "DPA0000: DPA issues")]
    public static string GetUsersWithProducts(ProductShopContext context)
    {
        var users = context.Users
            .Where(u => u.ProductsSold.Any(p => p.BuyerId != null))
            .OrderByDescending(u => u.ProductsSold.Count(p => p.BuyerId != null))
            .Select(u => new UserInfo()
            {
                FirstName = u.FirstName,
                LastName = u.LastName,
                Age = u.Age,
                SoldProducts = new SoldProducts()
                {
                    Count = u.ProductsSold.Count(p => p.BuyerId != null),
                    Products = u.ProductsSold
                        .Where(p => p.BuyerId != null)
                        .Select(p => new ProductX()
                        {
                            Name = p.Name,
                            Price = p.Price
                        })
                        .OrderByDescending(p => p.Price)
                        .ToArray()
                }
            })
            .Take(10)
            .ToArray();

        ExportUsersAndProductsDto info = new ExportUsersAndProductsDto()
        {
            Count = context.Users.Count(u => u.ProductsSold.Any(p => p.BuyerId != null)),
            Users = users
        };

        return Serializer<ExportUsersAndProductsDto>(info, "Users");
    }

}