namespace Northwind.WebApi.Models.DTOs;

public record SupplierDTO
{
    public int SupplierId { get; set; }
    public string CompanyName { get; set; } = string.Empty;
}
