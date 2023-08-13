namespace EventScreen.Db.Models.Settings;

public class MarqueeSettings
{
	public int Id { get; set; }

	public IEnumerable<Marquee> Marquees { get; set; }
	
	public bool Scroll { get; set; }
}