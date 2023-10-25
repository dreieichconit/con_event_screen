using Screen.Db.Interfaces;
using Screen.Db.Models;
using Screen.Services.Interfaces;

namespace Screen.Services.Implementation;

public class ConfigurationEditService : IConfigurationEditService
{
    private readonly IConfigurationRepository _configurationRepository;

    public ConfigurationEditService(IConfigurationRepository configurationRepository)
    {
        _configurationRepository = configurationRepository;
        Init();
    }

    public List<Configuration> Configurations { get; set; }
    
    public Configuration? CurrentConfiguration { get; set; }
    
    private void Init()
    {
        Configurations = _configurationRepository.GetAll().ToList();
        CurrentConfiguration = Configurations.Find(x => x.IsActive);
    }
}