using System.Collections;

namespace Bounded_Priority_Queue_with_Eviction;

public class BoundedPriorityQueue<TItem, TPriority> : IEnumerable<TItem> where TPriority : IComparable<TPriority>
{
    private readonly List<(TItem Item, TPriority Priority)> _queueItems = new();
    public int Capacity { get; }  // Maximum number of items the queue can hold
    public int Count => _queueItems.Count;  // Current number of items in the queue
    public BoundedPriorityQueue(int capacity)
    {
        if (capacity <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(capacity), "Capacity must be greater than zero.");
        }
        Capacity = capacity;
    }
    public void Enqueue(TItem item, TPriority priority)
    {
        ArgumentNullException.ThrowIfNull(priority);

        if (Count < Capacity)
        {
            InserSortedItem(item, priority);
        }
        else
        {
            EvictLowestPriorityItem(item, priority);
        }
    }
    private void InserSortedItem(TItem item, TPriority priority)
    {
        int index = _queueItems.FindIndex(x => priority.CompareTo(x.Priority) > 0);

        if (index == -1)
        {
            _queueItems.Add((item, priority)); // Empty list or lowest priority so far -> goes at the end
        }
        else
        {
            _queueItems.Insert(index, (item, priority)); // Insert right before the first smaller priority
        }

    }
    private void EvictLowestPriorityItem(TItem item, TPriority newItemPriority)
    {
        if (Count == Capacity)
        {
            if (newItemPriority.CompareTo(_queueItems[^1].Priority) > 0)
            {
                var itemToRemove = _queueItems[^1];  // Get the item with the lowest priority (last item in the sorted list)
                _queueItems.Remove(itemToRemove);  // Remove the item with the lowest priority

                InserSortedItem(item, newItemPriority);  // Insert the new item in the correct position based on its priority
            }
        }

    }
    public TItem Dequeue()
    {
        if (Count == 0)
            throw new InvalidOperationException("The queue is empty.");

        var item = _queueItems[0].Item;  // Get the item with the highest priority (first item in the sorted list)
        _queueItems.RemoveAt(0); // Remove the item with the highest priority

        return item;  //    Return the item with the highest priority
    }
    public TItem Peek()
    {
        if (Count == 0)
        {
            throw new InvalidOperationException("The queue is empty.");
        }
        return _queueItems[0].Item;  // Return the item with the highest priority (first item in the sorted list)
    }
    public IEnumerator<TItem> GetEnumerator()
    {
        foreach (var entry in _queueItems)
        {
            yield return entry.Item;
        }
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
