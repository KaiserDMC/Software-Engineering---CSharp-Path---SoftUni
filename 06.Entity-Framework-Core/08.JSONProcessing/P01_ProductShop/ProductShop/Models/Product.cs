namespace ProductShop.Models;

using System.Collections.Generic;

public class Product
{
    public Product()
    {
        CategoriesProducts = new List<CategoryProduct>();
    }

    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public int SellerId { get; set; }
    public User Seller { get; set; } = null!;

    public int? BuyerId { get; set; }
    public User Buyer { get; set; } = null!;

    public ICollection<CategoryProduct> CategoriesProducts { get; set; }
}