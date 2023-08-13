using EventScreen.Db.Models.Settings;
using EventScreen.Db.Repositories.Interfaces;
using EventScreen.Services.Interfaces;

namespace EventScreen.Services.Settings;

public class EventConfigService : IEventConfigService
{
	private readonly IEventConfigRepository _eventConfigRepository;
	private readonly IActiveSettingsRepository _activeSettingsRepository;

	public EventConfigService(IEventConfigRepository eventConfigRepository, IActiveSettingsRepository activeSettingsRepository)
	{
		_eventConfigRepository = eventConfigRepository;
		_activeSettingsRepository = activeSettingsRepository;
	}
	
	public event EventHandler? SettingsChanged;
	
	public List<EventConfig> EventConfigs { get; set; }

	public EventConfig? CurrentEvent { get; set; }

	public void Load()
	{
		EventConfigs = _eventConfigRepository.GetAll().ToList();
		
		var active = _activeSettingsRepository.GetOrCreate();

		if (active!.ActiveConfig != null)
		{
			CurrentEvent = EventConfigs.Find(x => x.Id == active.ActiveConfig.Id);
		}
	}

	public void Save()
	{
		foreach (var eventConfig in EventConfigs)
		{
			_eventConfigRepository.Update(eventConfig);
		}
	}
	
}