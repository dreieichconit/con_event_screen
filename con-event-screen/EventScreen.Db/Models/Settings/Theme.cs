namespace EventScreen.Db.Models.Settings;

public class Theme
{
	public int Id { get; set; }

	public string ThemeName { get; set; } = string.Empty;

	public string Primary { get; set; } = string.Empty;

	public string Secondary { get; set; } = string.Empty;

	public string Background { get; set; } = string.Empty;

	public string Text { get; set; } = string.Empty;

	public static Theme Create()
	{
		return new Theme()
		{
			ThemeName = "Please set a name",
		};
	}
}