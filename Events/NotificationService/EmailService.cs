using Events.Models;

namespace Events.NotificationService
{
    public class EmailService : INotificationService
    {
        public async Task SendAsync(Product product, CancellationToken cancellationToken)
        {
            await Task.Yield();
            Console.WriteLine($"MAIL : Notification sent for {product.Title} (Price: ${product.Price})");
        }
    }
}
