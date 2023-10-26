using Screen.Db.Interfaces;
using Screen.Db.Models;
using Screen.Services.Interfaces;

namespace Screen.Services.Implementation;

public class ConfigurationService : IConfigurationService
{
    private readonly IConfigurationRepository _configurationRepository;

    public ConfigurationService(IConfigurationRepository configurationRepository)
    {
        _configurationRepository = configurationRepository;
        ConfigurationEditService.ConfigurationsChanged += (_, _) => Init();
        Init();
    }
    
    public event EventHandler? ConfigUpdated;

    private void Init()
    {
        CurrentConfiguration = _configurationRepository.GetCustom(x => x.IsActive);
        ConfigUpdated?.Invoke(this, EventArgs.Empty);
    }

    public Configuration? CurrentConfiguration { get; set; }
}