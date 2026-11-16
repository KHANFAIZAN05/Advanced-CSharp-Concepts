OrderProcessor orderProcessor = new OrderProcessor();


orderProcessor.StatusChanged += NotificationHandler;   // Subscribe NotificationHandler to the StatusChanged event
orderProcessor.StatusChanged += AuditHandler;  // Subscribe AuditHandler to the StatusChanged event


orderProcessor.UpdateStatus(101, "Pending", "Paid"); // This will trigger both NotificationHandler and AuditHandler
orderProcessor.StatusChanged -= AuditHandler;   // Unsubscribe AuditHandler from the event

orderProcessor.UpdateStatus(101, "Paid", "Shipped"); // This will trigger only NotificationHandler since AuditHandler has been unsubscribed

// Event handler methods
void NotificationHandler(object? sender, OrderStatusChangedEventArgs e)
{
    Console.WriteLine($"Notification: Order {e.OrderId} status changed from {e.PreviousStatus} to {e.NewStatus} at {e.ChangedAtUtc}");

}

// AuditHandler method to log the status change
void AuditHandler(object? sender, OrderStatusChangedEventArgs e)
{
    Console.WriteLine($"Audit: Order {e.OrderId} status changed from {e.PreviousStatus} to {e.NewStatus} at {e.ChangedAtUtc}");

}

