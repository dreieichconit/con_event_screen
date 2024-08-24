using System.Text.Json.Serialization;

namespace Screen.Api.Models;

public class Table
{
    [JsonPropertyName("name")]
    public string Name { get; set; }
    
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("wheelchair_accessible")]
    public int WheelChairAccessible { get; set; }

    public bool Accessible => WheelChairAccessible > 0;
}