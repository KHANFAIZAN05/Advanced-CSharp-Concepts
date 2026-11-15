namespace Generic_In_Memory_Cache;

public class TimedCache<TKey, TValue> where TKey : notnull
{
    private Dictionary<TKey, (TValue Value, DateTime Expiration)> _cache = new ();
    private TimeSpan _defaultTtl;
    public TimedCache(TimeSpan defaultTtl)
    {
        if (defaultTtl <= TimeSpan.Zero)
        {
            throw new ArgumentOutOfRangeException(nameof(defaultTtl), "Default TTL must be greater than zero.");
        }
        _defaultTtl = defaultTtl;
    }

    public void Set(TKey key, TValue value, TimeSpan? customTtl = null)
    {
        ArgumentNullException.ThrowIfNull(key);

        if (customTtl.HasValue && customTtl.Value < TimeSpan.Zero)
        {
            throw new ArgumentOutOfRangeException(nameof(customTtl), "Custom TTL must be greater than zero.");
        }
        else
        {
            _cache[key] = (value, DateTime.UtcNow + (customTtl ?? _defaultTtl));
        }
    }
    public bool TryGet(TKey key, out TValue value)
    {
        ArgumentNullException.ThrowIfNull(key);

        if (!_cache.TryGetValue(key, out var entry))
        {
            value = default!;
            return false;
        }

        if (entry.Expiration < DateTime.UtcNow)
        {
            _cache.Remove(key);
            value = default!;
            return false;
        }

        value = entry.Value;
        return true;
    }

    public TValue GetOrAdd(TKey key, Func<TKey, TValue> valueFactory, TimeSpan? customTtl = null)
    {
        ArgumentNullException.ThrowIfNull(valueFactory);

        if (TryGet(key, out var existing))
        {
            return existing;
        }

        var newValue = valueFactory(key);
        Set(key, newValue, customTtl);
        return newValue;
    }

    public int PurgeExpired()
    {
        var expiredKeys = _cache.Where(key => key.Value.Expiration < DateTime.UtcNow)
            .Select(key => key.Key)
            .ToList();
        foreach (var key in expiredKeys)
        {
            _cache.Remove(key);
        }
        return expiredKeys.Count;
    }
}
