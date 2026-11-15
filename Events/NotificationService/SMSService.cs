using Events.Models;
namespace Events.NotificationService;

public class SMSService : INotificationService
{
    public async Task SendAsync(Product product, CancellationToken cancellationToken = default)
    {
        await Task.Yield();
        Console.WriteLine($"SMS  : Notification sent for {product.Title} (Category: {product.Category})");
    }
}
