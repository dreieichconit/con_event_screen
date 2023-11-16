using System.Text;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Components;

namespace Screen.Api.Models;

public class Game
{
	[JsonPropertyName("title")]
	public string Title { get; set; } = string.Empty;
	
	[JsonPropertyName("system")]
	public string System { get; set; } = string.Empty;
	
	[JsonPropertyName("start")]
	public DateTime Start { get; set; }
	
	[JsonPropertyName("player_max")]
	public int MaxPlayers { get; set; }
	
	[JsonPropertyName("player")]
	public List<Player> Players { get; set; }
	
	[JsonPropertyName("public")]
	public bool Public { get; set; }
	
	[JsonPropertyName("game_master")]
	public GameMaster GameMaster { get; set; }
	
	[JsonPropertyName("alias_game_master")]
	public string? GameMasterAlias { get; set; }
	
	[JsonPropertyName("label")]
	public List<GameLabel>? GameLabels { get; set; }
	
	[JsonPropertyName("table")]
	public List<Table>? Tables { get; set; }
	
	[JsonIgnore]
	public MarkupString TableText => Tables != null ? new MarkupString(string.Join("<br>", Tables.Select(x => x.Name))) : new MarkupString("");

	[JsonIgnore]
	public bool Accessible => Tables?.Exists(x => x.Accessible) ?? false;

	[JsonIgnore]
	public string GameMasterString => GameMasterAlias ?? GameMaster.Name;
	
	[JsonIgnore]
	public MarkupString LabelText => GameLabels != null ? new MarkupString(string.Join("<br>", GameLabels.Select(x => x.Name))) : new MarkupString("");

	[JsonIgnore]
	public TimeSpan TimeUntilStart => Start - DateTime.Now;

	[JsonIgnore]
	public string TimeUntilStartString
	{
		get
		{
			var sb = new StringBuilder();
			
			var days = TimeUntilStart.Days;
			var hours = TimeUntilStart.Hours;
			var minutes = TimeUntilStart.Minutes;
			
			if (TimeUntilStart.TotalDays > 1)
			{
				sb.Append($"{days:0} Tag");
				if (days > 1) sb.Append("e");
			}

			if (hours > 0)
			{
				sb.Append($" {hours:00} Stunde");
				if (hours > 1) sb.Append("n");
			}
            
			if (TimeUntilStart.TotalHours < 48)
			{
				sb.Append($" {minutes:00} Minute");
				if (minutes > 1) sb.Append("n");
			}

			return sb.ToString();
		}
	}
}