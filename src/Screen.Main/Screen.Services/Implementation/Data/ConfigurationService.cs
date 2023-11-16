using EfExtensions.Core.Interfaces.Result;
using Screen.Data.Interfaces;
using Screen.Data.Models;
using Screen.Services.Interfaces.Data;
using Screen.Services.Util;

namespace Screen.Services.Implementation.Data;

public class ConfigurationService : IConfigurationService
{
	private readonly IConfigurationRepository _configurationRepository;
	private readonly IMarqueeRepository _marqueeRepository;
	private readonly IPageRepository _pageRepository;

	public static event EventHandler? ItemsUpdated;
	
	public ConfigurationService(
		IConfigurationRepository configurationRepository, 
		IMarqueeRepository marqueeRepository,
		IPageRepository pageRepository)
	{
		_configurationRepository = configurationRepository;
		_marqueeRepository = marqueeRepository;
		_pageRepository = pageRepository;

		Load();
	}

	public List<Configuration> Items { get; set; } = new();

	public IEnumerable<IDbResult<Configuration>> Save()
	{
		foreach (var config in Items)
		{
			SaveMarquees(config);
			SavePages(config);
		}

		var results = _configurationRepository.CrudMany(Items);

		if (results.All(x => x.Success)) Load();
		
		ItemsUpdated?.Invoke(null, EventArgs.Empty);

		return results;
	}

	public void Load()
	{
		var configurations = _configurationRepository.GetAll().SetUpdated();

		foreach (var config in configurations)
		{
			LoadMarquees(config);
			LoadPages(config);
		}

		Items = configurations.ToList();
	}

	public Configuration GetActive()
	{
		return Items.Find(x => x.Active)!;
	}

	private void LoadMarquees(Configuration config)
	{
		config.Marquees = _marqueeRepository.GetAllCustom(x => x.ConfigurationId == config.Id).SetUpdated().ToList();
	}

	private void LoadPages(Configuration config)
	{
		config.Pages = _pageRepository.GetAllCustom(x => x.ConfigurationId == config.Id).SetUpdated().ToList();
	}

	private bool SaveMarquees(Configuration config)
	{
		var results = _marqueeRepository.CrudMany(config.Marquees);
		return results.All(x => x.Success);
	}

	private bool SavePages(Configuration config)
	{
		var results = _pageRepository.CrudMany(config.Pages);

		return results.All(x => x.Success);
	}
}