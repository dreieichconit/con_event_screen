namespace EventScreen.Db.Models.Settings;

public class MarqueeSettings
{
	public int Id { get; set; }

	public string Marquee { get; set; } = string.Empty;
	
	public bool Scroll { get; set; }
}