using Newtonsoft.Json;
using Northwind.WebApi.Abstractions;
using Northwind.WebApi.Models;

namespace Northwind.WebApi.Repositories;

public class NorthwindRepository : INorthwindRepository
{
    private readonly HttpClient _httpClient;
    private readonly string _northWindURL = "https://services.odata.org/V4/Northwind/Northwind.svc/";

    public NorthwindRepository()
    {
        _httpClient = new()
        {
            Timeout = TimeSpan.FromSeconds(3)
        };
    }

    public async Task<IEnumerable<Product>> GetAllProductsAsync()
    {
        OData odata;
        string query = "Products";
        var products = new List<Product>();
        do
        {
            odata = await GetOdataFromNorthwind(query);
            query = odata.Nextlink;

            foreach (var item in odata.Value)
            {
                products.Add(JsonConvert.DeserializeObject<Product>(item.ToString()));
            }
        }
        while (!string.IsNullOrEmpty(query));
        return products;
    }

    public async Task<IEnumerable<OrderDetail>> GetAllOrderDetailsAsync()
    {
        OData odata;
        string query = "Order_Details";
        var orderDetails = new List<OrderDetail>();
        do
        {
            odata = await GetOdataFromNorthwind(query);
            query = odata.Nextlink;

            foreach (var item in odata.Value)
            {
                orderDetails.Add(JsonConvert.DeserializeObject<OrderDetail>(item.ToString()));
            }
        }
        while (!string.IsNullOrEmpty(query));

        return orderDetails;
    }

    public async Task<IEnumerable<Supplier>> GetAllSuppliersAsync()
    {
        OData odata;
        string query = "Suppliers";
        var suppliers = new List<Supplier>();
        do
        {
            odata = await GetOdataFromNorthwind(query);
            query = odata.Nextlink;

            foreach (var item in odata.Value)
            {
                suppliers.Add(JsonConvert.DeserializeObject<Supplier>(item.ToString()));
            }
        }
        while (!string.IsNullOrEmpty(query));

        return suppliers;
    }

    public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
    {
        OData odata;
        string query = "Categories";
        var categories = new List<Category>();
        do
        {
            odata = await GetOdataFromNorthwind(query);
            query = odata.Nextlink;

            foreach (var item in odata.Value)
            {
                categories.Add(JsonConvert.DeserializeObject<Category>(item.ToString()));
            }
        }
        while (!string.IsNullOrEmpty(query));

        return categories;
    }

    private async Task<OData> GetOdataFromNorthwind(string query)
    {
        var json = await _httpClient.GetStringAsync(_northWindURL + query);
        return JsonConvert.DeserializeObject<OData>(json)!;
    }
}
