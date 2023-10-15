using Northwind.WebApi.Models.Base;

namespace Northwind.WebApi.Models;

public sealed class OrderDetail : NorthwindEntry
{
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public decimal UnitPrice { get; set; }
    public short Quantity { get; set; }
    public float Discount { get; set; }
}
