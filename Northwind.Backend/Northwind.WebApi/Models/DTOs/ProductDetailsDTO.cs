namespace Northwind.WebApi.Models.DTOs;

public record ProductDetailsDTO(
    int ProductId,
    string ProductName,
    string? SupplierName,
    string? CategoryName,
    string QuantityPerUnit,
    decimal? UnitPrice);
