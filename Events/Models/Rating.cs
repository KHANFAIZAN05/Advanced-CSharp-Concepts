namespace Events.Models;

using System.Text.Json.Serialization;

public record Rating
{
    [JsonPropertyName("rate")] public double Rate { get; set; }
    [JsonPropertyName("count")] public int Count { get; set; }
}
