using Northwind.WebApi.Models;

namespace Northwind.WebApi.Abstractions;

public interface INorthwindRepository
{
    Task<IEnumerable<Product>> GetAllProductsAsync();
    Task<IEnumerable<OrderDetail>> GetAllOrderDetailsAsync();
    Task<IEnumerable<Supplier>> GetAllSuppliersAsync();
    Task<IEnumerable<Category>> GetAllCategoriesAsync();
}
