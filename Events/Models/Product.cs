namespace Events.Models;

using System.Text.Json.Serialization;

public record Product
{
    [JsonPropertyName("id")] public int Id { get; set; }
    [JsonPropertyName("title")] public string? Title { get; set; }
    [JsonPropertyName("price")] public decimal Price { get; set; }
    [JsonPropertyName("description")] public string? Description { get; set; }
    [JsonPropertyName("category")] public string? Category { get; set; }
    [JsonPropertyName("rating")] public Rating? Rating { get; set; }
}
