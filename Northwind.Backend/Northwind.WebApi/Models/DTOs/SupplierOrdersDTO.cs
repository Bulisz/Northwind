namespace Northwind.WebApi.Models.DTOs;

public record SupplierOrdersDTO
{
    public string ProductName { get; set; } = string.Empty;
    public decimal Amount { get; set; }
}