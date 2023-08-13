namespace EventScreen.Db.Models.Settings;

public class ActiveSetting
{
	public int Id { get; set; }

	public EventConfig? ActiveConfig { get; set; }
}