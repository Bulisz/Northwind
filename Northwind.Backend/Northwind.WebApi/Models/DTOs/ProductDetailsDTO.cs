namespace Northwind.WebApi.Models.DTOs;

public record ProductDetailsDTO
{
    public int ProductId { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public string? SupplierName { get; set; }
    public string? CategoryName { get; set; }
    public string QuantityPerUnit { get; set; } = string.Empty;
    public decimal? UnitPrice { get; set; }
}
