using EventScreen.Db.Models.Settings;
using EventScreen.Db.Repositories.Interfaces;
using EventScreen.Services.Interfaces;

namespace EventScreen.Services.Settings;

public class EventConfigService : IEventConfigService
{
	private readonly IEventConfigRepository _eventConfigRepository;
	private readonly IActiveSettingsRepository _activeSettingsRepository;

	public EventConfigService(IEventConfigRepository eventConfigRepository, 
							IActiveSettingsRepository activeSettingsRepository)
	{
		_eventConfigRepository = eventConfigRepository;
		_activeSettingsRepository = activeSettingsRepository;
		
		Load();
	}
	
	public event EventHandler? SettingsChanged;
	
	private ActiveSetting? Active { get; set; }
	
	public List<EventConfig> EventConfigs { get; set; } = new();

	public EventConfig? CurrentEvent { get; set; } = new();

	public void Load()
	{
		EventConfigs = _eventConfigRepository.GetAll().ToList();
		
		Active = _activeSettingsRepository.GetOrCreate();

		if (Active!.ActiveConfig != null)
		{
			CurrentEvent = EventConfigs.Find(x => x.Id == Active.ActiveConfig.Id);
		}
		
		SettingsChanged?.Invoke(this, EventArgs.Empty);
	}

	public void Save()
	{
		foreach (var eventConfig in EventConfigs)
		{
			_eventConfigRepository.Update(eventConfig);
		}
		
		Active!.ActiveConfig = CurrentEvent;

		_activeSettingsRepository.Update(Active);
	}
	
}