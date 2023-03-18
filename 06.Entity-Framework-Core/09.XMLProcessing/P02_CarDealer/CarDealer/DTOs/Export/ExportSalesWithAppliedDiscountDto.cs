namespace CarDealer.DTOs.Export;

using System.Xml.Serialization;

[XmlType("sale")]
public class ExportSalesWithAppliedDiscountDto
{
    [XmlElement("car")]
    public CarDtoSales CarDtoSales { get; set; }

    [XmlElement("discount")]
    public int Discount { get; set; }

    [XmlElement("customer-name")]
    public string CustomerName { get; set; }

    [XmlElement("price")]
    public string Price { get; set; }

    [XmlElement("price-with-discount")]
    public double PriceWithDiscount { get; set; }
}

[XmlType("car")]
public class CarDtoSales
{
    [XmlAttribute("make")]
    public string Make { get; set; }

    [XmlAttribute("model")]
    public string Model { get; set; }

    [XmlAttribute("traveled-distance")]
    public long TraveledDistance { get; set; }
}