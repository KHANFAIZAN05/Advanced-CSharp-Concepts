class OrderStatusChangedEventArgs : EventArgs
{
    public int OrderId { get; }
    public string PreviousStatus { get; } = String.Empty;
    public string NewStatus { get; } = String.Empty;
    public DateTime ChangedAtUtc { get; }

    public OrderStatusChangedEventArgs(int orderId, string previousStatus, string newStatus, DateTime changedAtUtc)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(orderId);
        ArgumentException.ThrowIfNullOrWhiteSpace(previousStatus);
        ArgumentException.ThrowIfNullOrWhiteSpace(newStatus);
        
        OrderId = orderId;
        PreviousStatus = previousStatus;
        NewStatus = newStatus;
        ChangedAtUtc = changedAtUtc;
    }
}
