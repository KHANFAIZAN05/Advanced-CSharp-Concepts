using Events.Models;
using System.Net.Http.Json;

namespace Events.NotificationService;

public class NotificationService 
{   
    private readonly IEnumerable<INotificationService> _notificationServices;
    public NotificationService(IEnumerable<INotificationService> notificationServices)
    {
        _notificationServices = notificationServices;
    }
    public async Task PublishParallelAsync(Product product ,CancellationToken cancellationToken)
    {
        var tasks = _notificationServices.Select(service => service.SendAsync(product, cancellationToken));
    
        await Task.WhenAll(tasks);
    }
}
