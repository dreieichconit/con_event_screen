using EventScreen.Db.Models.Settings;

namespace EventScreen.Services.Interfaces;

public interface IPagesService : ISettingsService
{
	public IEnumerable<Screen> Pages { get; set; }
	
	public IEnumerable<Screen> AvailablePages { get; set; }
}