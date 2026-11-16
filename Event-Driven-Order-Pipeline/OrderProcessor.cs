class OrderProcessor
{
    public event EventHandler<OrderStatusChangedEventArgs>? StatusChanged;
    public void UpdateStatus(int orderId, string currentStatus, string newStatus)
    {
        if (orderId <= 0 || string.IsNullOrWhiteSpace(currentStatus) || string.IsNullOrWhiteSpace(newStatus))
        {
            throw new ArgumentException("Invalid orderId or status values.");
        }
        var eventArgs = new OrderStatusChangedEventArgs(orderId, currentStatus, newStatus, DateTime.UtcNow);
        OnStatusChanged(eventArgs);
    }
    protected virtual void OnStatusChanged(OrderStatusChangedEventArgs e)
    {
        StatusChanged?.Invoke(this, e);
    }
}
