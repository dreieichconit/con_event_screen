namespace EventScreen.Db.Models.Settings;

public class EventConfig
{
	public int Id { get; set; }
	
	public string EventName { get; set; }
	
	public MarqueeSettings EventMarquee { get; set; }

	public ScreenSettings EventScreens { get; set; }

	public ThemeSettings EventTheme { get; set; }
	
	public ApiSettings EventApiSettings { get; set; }
	
	public AlertSettings EventAlertSettings { get; set; }

	public static EventConfig Create()
	{
		return new EventConfig()
		{
			EventName = "Please enter the event name",
			EventMarquee = new MarqueeSettings(),
			EventScreens = new ScreenSettings(),
			EventTheme = new ThemeSettings()
			{
				CurrentTheme = new Theme(),
			},
			EventApiSettings = new ApiSettings(),
			EventAlertSettings = new AlertSettings(),
		};
	}
}