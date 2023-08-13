namespace EventScreen.Db.Models.Settings;

public class Marquee
{
	public int Id { get; set; }

	public string Text { get; set; } = string.Empty;
	
	public int Order { get; set; }
}