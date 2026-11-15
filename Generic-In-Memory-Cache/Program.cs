using Generic_In_Memory_Cache;

TimedCache<string, string> cache = new(TimeSpan.FromSeconds(5));

int callNumber = 1;

Console.WriteLine("Generic In-Memory Cache Example");
Console.WriteLine("Cache TTL is set to 5 seconds. After that, the cache will expire and a new DB call will be made.");
while (true)
{
    Console.WriteLine($"\nCall {callNumber}");
    string user = GetUser("42");
    Console.WriteLine($"Result: {user}");

    Console.WriteLine("Press Enter for next call or type q to quit:");
    string? input = Console.ReadLine();
    if (string.Equals(input, "q", StringComparison.OrdinalIgnoreCase))
    {
        break;
    }

    callNumber++;
}


string GetUser(string userId)
{
    if (cache.TryGet(userId, out var cachedValue))
    {
        Console.WriteLine("Fetched from cache.");
        return cachedValue;
    }
    Console.WriteLine("Not found in cache or expired. DB call invoked.");
    return cache.GetOrAdd(userId, LoadUserFromDatabase);
}
string LoadUserFromDatabase(string userId)
{
    Console.WriteLine($"DB query for {userId}");
    return $"User_{userId}";
}


