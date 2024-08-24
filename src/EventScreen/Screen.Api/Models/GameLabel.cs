using System.Text.Json.Serialization;

namespace Screen.Api.Models;

public class GameLabel
{
    [JsonPropertyName("name")]
    public string Name { get; set; }
}