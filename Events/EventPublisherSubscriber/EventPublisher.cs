using Events.Models;
using System.Net.Http.Json;

namespace EventPublisherSubscriber;
public class ProductEventArgs : EventArgs
{
    public Product Product { get; }
    public ProductEventArgs(Product product) => Product = product;
}

public class EventPublisher
{
    //classic
    //public event PublisherEventHandler? ProductPublished;

    //modern
    // public event Action<Product>? ProductPublished;

    //recommended pattern
    public event EventHandler<ProductEventArgs>? ProductPublished;

    private static readonly HttpClient _httpClient = new HttpClient();
    public async Task<Product?> GetDataAsync(CancellationToken cancellationToken)
    {
        try
        {
            var response = await _httpClient.GetAsync("https://fakestoreapi.com/products/1", cancellationToken);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Product>(cancellationToken: cancellationToken);
            }

            return null;
        }
        catch (Exception)
        {
            throw;
        }
    }
    public void Publish(Product product)
    {
        Console.WriteLine("\n--- Starting Event Publishing ---");

        //ProductPublished?.Invoke(product);

        ProductPublished?.Invoke(this, new ProductEventArgs(product));
    }
    public void PublishWithCallback(Product product, Action<Product> callbackMethod)
    {
        Console.WriteLine("\n--- Starting Event Publishing ---");

        callbackMethod(product);
    }
}
