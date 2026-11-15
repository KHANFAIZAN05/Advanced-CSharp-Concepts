#region using Classic Old Patterns
//public delegate void PublisherEventHandler(Product eventMessage);

//public class Program
//{


//public static async Task Main(string[] args)
//{
//    EventPublisher publisher = new EventPublisher();

//    publisher.ProductPublished += EventSubscriber.EventPublisher_ViaSMS;
//    publisher.ProductPublished += EventSubscriber.EventPublisher_ViaMail;

//    using CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

//    var responseData = await publisher.GetDataAsync(cancellationTokenSource.Token);

//    if (responseData is not null)
//    {
//        publisher.Publish(responseData);
//        publisher.PublishWithCallback(responseData, EventSubscriber.EventPublisher_ViaMail);
//    }
//    else
//    {
//        Console.WriteLine("No Data Received");
//    }
//}

#endregion

#region using Modern Pattern
//public class Program
//{
//    public event Action<Product>? ProductPublished;

//    public static async Task Main(string[] args)
//    {

//        using CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

//        EventPublisher publisher = new EventPublisher();

//        //same as Before

//        publisher.ProductPublished += EventSubscriber.EventPublisher_ViaSMS;
//        publisher.ProductPublished += EventSubscriber.EventPublisher_ViaMail;

//        // Now easily attach quick inline methods (Lambda expressions)

//        publisher.ProductPublished += (product) =>
//        {
//            Console.WriteLine($"LOG : Product '{product.Title}' was processed at {DateTime.Now}");
//        };


//        var responseData = await publisher.GetDataAsync(cancellationTokenSource.Token);

//        if (responseData is not null)
//        {
//            publisher.Publish(responseData);
//            publisher.PublishWithCallback(responseData, EventSubscriber.EventPublisher_ViaSMS);
//        }
//        else
//        {
//            Console.WriteLine("No Data Received");
//        }

//    }
//}

#endregion

#region using Recommended pattern
//public class Program
//{
//    public static async Task Main(string[] args)
//    {

//        using CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

//        EventPublisher publisher = new EventPublisher();

//        publisher.ProductPublished += EventSubscriber.EventPublisher_ViaSMS;
//        publisher.ProductPublished += EventSubscriber.EventPublisher_ViaMail;


//        var responseData = await publisher.GetDataAsync(cancellationTokenSource.Token);

//        if (responseData is not null)
//        {
//            publisher.Publish(responseData);
//        }
//        else
//        {
//            Console.WriteLine("No Data Received");
//        }
//    }
//}

#endregion

#region Notification service Example With Interfaces (DI) Loosely Coupled System

using Events.NotificationService;

using var sharedHttpClient = new HttpClient();

IEnumerable<INotificationService> notificationService = [
    new SMSService(),
    new EmailService()
    ];

NotificationService publisher = new NotificationService(notificationService);

CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

ProductApiClient apiClient = new ProductApiClient(sharedHttpClient);

var responseData = await apiClient.GetProductByIdAsync(1, cancellationTokenSource.Token);

if (responseData is not null)
{
    await publisher.PublishParallelAsync(responseData, cancellationTokenSource.Token);
}
else
{
    Console.WriteLine("No Data Received");
}

#endregion

