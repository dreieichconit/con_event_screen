namespace EventScreen.Db.Models.Settings;

public class Theme
{
	public int Id { get; set; }

	public string Primary { get; set; } = string.Empty;

	public string Secondary { get; set; } = string.Empty;

	public string Background { get; set; } = string.Empty;

	public string Text { get; set; } = string.Empty;
}