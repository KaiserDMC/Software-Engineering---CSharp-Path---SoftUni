namespace ProductShop.Models;

using System.Collections.Generic;

public class Category
{
    public Category()
    {
        CategoriesProducts = new List<CategoryProduct>();
    }

    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public ICollection<CategoryProduct> CategoriesProducts { get; set; }
}
