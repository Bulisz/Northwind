using Northwind.WebApi.Models.DTOs;

namespace Northwind.WebApi.Abstractions;

public interface INorthwindService
{
    Task<IEnumerable<ProductDetailsDTO>> GetAllProductsAsync();
    Task<IEnumerable<SupplierDTO>> GetAllSupplierAsync();
    Task<IEnumerable<SupplierOrdersDTO>> GetOrdersOfSupplierAsync(int supplierName);
}
