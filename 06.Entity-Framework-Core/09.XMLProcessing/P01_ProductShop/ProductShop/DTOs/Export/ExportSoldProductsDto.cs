namespace ProductShop.DTOs.Export;

using System.Xml.Serialization;

[XmlType("User")]
public class ExportSoldProductsDto
{

    [XmlElement("firstName")]
    public string FirstName { get; set; }

    [XmlElement("lastName")] 
    public string LastName { get; set; }

    [XmlArray("soldProducts")]
    public ProductDto[] Products { get; set; }
}

[XmlType("Product")]
public class ProductDto
{
    [XmlElement("name")]
    public string Name { get; set; }

    [XmlElement("price")]
    public decimal Price { get; set; }
}