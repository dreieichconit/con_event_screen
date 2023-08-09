using EventScreen.Db.Models.Settings;
using EventScreen.Db.Repositories.Interfaces;
using EventScreen.Services.Interfaces;

namespace EventScreen.Services.Settings;

public class PagesService : IPagesService
{
	private readonly IScreenRepository _screenRepository;
	private readonly IScreenSettingsRepository _screenSettingsRepository;

	public IEnumerable<Screen> Pages { get; set; } = new List<Screen>();
	public IEnumerable<Screen> AvailablePages { get; set; } = new List<Screen>();

	private ScreenSettings _screenSettings = null!;
	

	public PagesService(IScreenRepository screenRepository, IScreenSettingsRepository screenSettingsRepository)
	{
		_screenRepository = screenRepository;
		_screenSettingsRepository = screenSettingsRepository;

		Load();
	}

	public event EventHandler? SettingsChanged;

	public void Load()
	{
		_screenSettings = _screenSettingsRepository.GetOrCreate()!;
		
		Pages = _screenSettings.Screens;
		AvailablePages = _screenRepository.GetAll().Where(x => Pages.All(y => x.Id != y.Id));
		
		SettingsChanged?.Invoke(this, EventArgs.Empty);
	}

	public void Save()
	{
		_screenSettingsRepository.Update(_screenSettings);
	}
}