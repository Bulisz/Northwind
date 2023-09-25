namespace Northwind.WebApi.Models;

public class Category
{
    public int CategoryId { get; set; }
    public string CategoryName { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public byte[] Picture { get; set; } = Array.Empty<byte>();
}
