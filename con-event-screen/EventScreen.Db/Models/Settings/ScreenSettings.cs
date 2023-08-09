namespace EventScreen.Db.Models.Settings;

public class ScreenSettings
{
	public int Id { get; set; }
	
	public IEnumerable<Screen> Screens { get; set; }
}