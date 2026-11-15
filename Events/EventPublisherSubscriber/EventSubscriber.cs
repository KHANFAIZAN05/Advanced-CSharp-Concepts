namespace EventPublisherSubscriber;
// classic Approach

//public static class EventSubscriber
//{
//    public static void EventPublisher_ViaMail(Product eventMessage)
//    {
//        Console.WriteLine($"MAIL Notification Sent for: {eventMessage}");
//    }

//    public static void EventPublisher_ViaSMS(Product eventMessage)
//    {
//        Console.WriteLine($"SMS Notification Sent for : {eventMessage}");
//    }
//}


//Modern Recomended approach
public static class EventSubscriber
{
    // STANDARD: Methods match the standard (object? sender, TEventArgs e) signature
    public static void EventPublisher_ViaMail(object? sender, ProductEventArgs e)
    {
        Console.WriteLine($"MAIL : Notification sent for {e.Product.Title} (Price: ${e.Product.Price})");
    }

    public static void EventPublisher_ViaSMS(object? sender, ProductEventArgs e)
    {
        Console.WriteLine($"SMS  : Notification sent for {e.Product.Title} (Category: {e.Product.Category})");
    }
}