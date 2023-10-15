using Northwind.WebApi.Abstractions;
using Northwind.WebApi.Models.Base;
using Simple.OData.Client;

namespace Northwind.WebApi.Repositories;

public class NorthwindRepository : INorthwindRepository
{
    private readonly string _northWindURL = "https://services.odata.org/V4/Northwind/Northwind.svc/";

    public async Task<List<T>> GetAllEntriesAsync<T>() where T : NorthwindEntry
    {
        var annotations = new ODataFeedAnnotations();
        var client = new ODataClient(_northWindURL);

        var entryList = (await client.For<T>().FindEntriesAsync(annotations)).ToList();
        while (annotations.NextPageLink != null)
        {
            entryList.AddRange(await client
                .For<T>()
                .FindEntriesAsync(annotations.NextPageLink, annotations));
        }

        return entryList;
    }
}
