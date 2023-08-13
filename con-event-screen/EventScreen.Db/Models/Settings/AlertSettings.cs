namespace EventScreen.Db.Models.Settings;

public class AlertSettings
{
	public int Id { get; set; }
	
	public IEnumerable<ScheduledAlert> ScheduledAlerts { get; set; }
}