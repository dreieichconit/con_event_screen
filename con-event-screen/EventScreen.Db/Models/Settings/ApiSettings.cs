namespace EventScreen.Db.Models.Settings;

public class ApiSettings
{
	public int Id { get; set; }

	public string GamesEndpoint { get; set; } = string.Empty;

	public string ProgramEndpoint { get; set; } = string.Empty;
}