namespace EventScreen.Db.Models.Settings;

public class ScheduledAlert
{
	public int Id { get; set; }
	
	public string AlertTitle { get; set; }
	
	public string AlertMessage { get; set; }
	
	public DateTime AlertTime { get; set; }
}