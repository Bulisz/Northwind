namespace Northwind.WebApi.Models.DTOs;

public record SupplierOrdersDTO(
    string ProductName,
    decimal Amount);