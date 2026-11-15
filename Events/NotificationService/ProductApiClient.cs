using Events.Models;
using System.Net.Http.Json;

namespace Events.NotificationService;

public class ProductApiClient
{
    private readonly HttpClient _httpClient;
    public ProductApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<Product?> GetProductByIdAsync(int id, CancellationToken cancellationToken)
    {
        var response = await _httpClient.GetAsync($"https://fakestoreapi.com/products/{id}", cancellationToken);
        
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<Product>(cancellationToken: cancellationToken);
        }
        return null;
    }
}
