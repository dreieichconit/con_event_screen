namespace EventScreen.Services.Interfaces;

public interface ISettingsService
{
	public event EventHandler SettingsChanged;
	
	public void Load();

	public void Save();
}