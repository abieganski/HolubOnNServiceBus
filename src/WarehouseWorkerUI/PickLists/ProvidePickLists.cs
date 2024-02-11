using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using WarehouseWorkerUI.PickLists.DataModels;

namespace WarehouseWorkerUI.PickLists;

public class ProvidePickLists : IProvidePickLists
{
    private readonly Uri baseUrl = new Uri("http://localhost:5148/"); // todo: this should be in a config file
    
    private static HttpClient client = new HttpClient();

    
    public async Task<List<PickList>> GetPickLists()
    {
        HttpResponseMessage response = await client.GetAsync(new Uri(baseUrl, "picklists"));
        response.EnsureSuccessStatusCode();
        
        List<PickList> pickLists = await response.Content.ReadFromJsonAsync<List<PickList>>(
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        
        return pickLists;
    }
}