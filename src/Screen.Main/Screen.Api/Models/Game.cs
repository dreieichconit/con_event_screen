using System.Text.Json.Serialization;

namespace Screen.Api.Models;

public class Game
{
	[JsonPropertyName("title")]
	public string Title { get; set; } = string.Empty;
	
	[JsonPropertyName("system")]
	public string System { get; set; } = string.Empty;
	
	[JsonPropertyName("start")]
	public DateTime Start { get; set; }
}