using Northwind.WebApi.Abstractions;
using Northwind.WebApi.Models;
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
        var products = await _repository.GetAllEntriesAsync<Product>();
        var suppliers = await _repository.GetAllEntriesAsync<Supplier>();
        var categories = await _repository.GetAllEntriesAsync<Category>();

        return products.Select(p => new ProductDetailsDTO(
            p.ProductId,
            p.ProductName,
            suppliers.FirstOrDefault(s => s.SupplierId == p.SupplierId)!.CompanyName,
            categories.FirstOrDefault(c => c.CategoryId == p.CategoryId)!.CategoryName,
            p.QuantityPerUnit,
            p.UnitPrice));
    }

    public async Task<IEnumerable<SupplierDTO>> GetAllSupplierAsync()
    {
        var suppliers = await _repository.GetAllEntriesAsync<Supplier>();

        return suppliers.Select(s => new SupplierDTO(
            s.SupplierId,
            s.CompanyName));
    }

    public async Task<IEnumerable<SupplierOrdersDTO>> GetOrdersOfSupplierAsync(int supplierId)
    {
        var products = await _repository.GetAllEntriesAsync<Product>();
        var orderDetails = await _repository.GetAllEntriesAsync<OrderDetail>();

        return products.Where(p => p.SupplierId == supplierId)
                       .Select(p => new SupplierOrdersDTO(
                           p.ProductName,
                           orderDetails.Where(od => od.ProductId == p.ProductId)
                                                 .Aggregate(0M, (result, od) => result + (od.Quantity * od.UnitPrice))));
    }
}