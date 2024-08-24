using System.Text.Json.Serialization;

namespace Screen.Api.Models;

public class GameMaster
{
    [JsonPropertyName("name")]
    public string Name { get; set; }
}