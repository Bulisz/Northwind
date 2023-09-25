using Northwind.WebApi.Abstractions;
using Northwind.WebApi.Models.DTOs;

namespace Northwind.WebApi.Services;

public class NorthwindService : INorthwindService
{
    private readonly INorthwindRepository _repository;

    public NorthwindService(INorthwindRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<ProductDetailsDTO>> GetAllProductsAsync()
    {
        var products = await _repository.GetAllProductsAsync();
        var suppliers = await _repository.GetAllSuppliersAsync();
        var categories = await _repository.GetAllCategoriesAsync();

        return products.Select(p => new ProductDetailsDTO()
        {
            ProductId = p.ProductId,
            ProductName = p.ProductName,
            CategoryName = categories.FirstOrDefault(c => c.CategoryId == p.CategoryId)!.CategoryName,
            SupplierName = suppliers.FirstOrDefault(s => s.SupplierId == p.SupplierId)!.CompanyName,
            QuantityPerUnit = p.QuantityPerUnit,
            UnitPrice = p.UnitPrice
        });
    }

    public async Task<IEnumerable<SupplierDTO>> GetAllSupplierAsync()
    {
        var suppliers = await _repository.GetAllSuppliersAsync();

        return suppliers.Select(s => new SupplierDTO()
        {
            SupplierId = s.SupplierId,
            CompanyName = s.CompanyName
        });
    }

    public async Task<IEnumerable<SupplierOrdersDTO>> GetOrdersOfSupplierAsync(int supplierId)
    {
        var products = await _repository.GetAllProductsAsync();
        var orderDetails = await _repository.GetAllOrderDetailsAsync();

        return products.Where(p => p.SupplierId == supplierId)
                       .Select(p => new SupplierOrdersDTO()
                       {
                           ProductName = p.ProductName,
                           Amount = orderDetails.Where(od => od.ProductId == p.ProductId)
                                                 .Aggregate(0M, (result, od) => result + (od.Quantity * od.UnitPrice))
                       });
    }
}