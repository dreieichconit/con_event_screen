namespace EventScreen.Db.Models.Settings;

public class EventConfig
{
	public int Id { get; set; }
	
	public MarqueeSettings EventMarquee { get; set; }

	public ScreenSettings EventScreens { get; set; }

	public ThemeSettings EventTheme { get; set; }
	
	public ApiSettings EventApiSettings { get; set; }
	
	public AlertSettings EventAlertSettings { get; set; }
}