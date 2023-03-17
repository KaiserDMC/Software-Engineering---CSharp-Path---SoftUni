namespace ProductShop.DTOs.Export;

using System.Xml.Serialization;

[XmlType("Users")]
public class ExportUsersAndProductsDto
{
    [XmlElement("count")]
    public int Count { get; set; }

    [XmlArray("users")]
    public UserInfo[] Users { get; set; }
}

[XmlType("User")]
public class UserInfo
{
    [XmlElement("firstName")]
    public string FirstName { get; set; }

    [XmlElement("lastName")]
    public string LastName { get; set; }

    [XmlElement("age")]
    public int? Age { get; set; }

    public SoldProducts SoldProducts { get; set; }
}

[XmlType("SoldProducts")]
public class SoldProducts
{
    [XmlElement("count")]
    public int Count { get; set; }

    [XmlArray("products")]
    public ProductX[] Products { get; set; }
}

[XmlType("Product")]
public class ProductX
{
    [XmlElement("name")]
    public string Name { get; set; }

    [XmlElement("price")]
    public decimal Price { get; set; }
}