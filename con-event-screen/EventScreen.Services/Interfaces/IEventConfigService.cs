using EventScreen.Db.Models.Settings;

namespace EventScreen.Services.Interfaces;

public interface IEventConfigService : ISettingsService
{
	public List<EventConfig> EventConfigs { get; set; }
	
	public EventConfig CurrentEvent { get; set; }
}