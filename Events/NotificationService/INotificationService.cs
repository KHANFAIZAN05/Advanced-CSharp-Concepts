using Events.Models;
namespace Events.NotificationService;

public interface INotificationService
{
    Task SendAsync(Product product, CancellationToken cancellationToken = default);
}