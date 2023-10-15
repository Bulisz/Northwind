using Northwind.WebApi.Models;
using Northwind.WebApi.Models.Base;

namespace Northwind.WebApi.Abstractions;

public interface INorthwindRepository
{
    Task<List<T>> GetAllEntriesAsync<T>() where T : NorthwindEntry;
}
