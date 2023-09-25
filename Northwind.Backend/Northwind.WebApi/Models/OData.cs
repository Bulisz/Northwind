using Newtonsoft.Json;

namespace Northwind.WebApi.Models;

public class OData
{
    [JsonProperty("@odata.context")]
    public string Metadata { get; set; } = string.Empty;

    [JsonProperty("value")]
    public ICollection<dynamic> Value { get; set; }

    [JsonProperty("@odata.nextLink")]
    public string Nextlink { get; set; } = string.Empty;
}
