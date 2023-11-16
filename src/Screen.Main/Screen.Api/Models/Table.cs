using System.Text.Json.Serialization;

namespace Screen.Api.Models;

public class Table
{
    [JsonPropertyName("name")]
    public string Name { get; set; }
    
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonIgnore]
    public bool Accessible => Description?.ToLower() == "barrierefrei";
}