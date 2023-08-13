using EventScreen.Db.Enums;

namespace EventScreen.Db.Models.Settings;

public class Screen
{
	public int Id { get; set; }
	
	public int Order { get; set; }
	
	public ScreenType Type { get; set; }
    
	public string? ImageUrl { get; set; }

	public int DisplayTimeSeconds { get; set; }
}