using EfExtensions.Core.Enum;
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

    public static event EventHandler? ConfigurationsChanged; 

    public List<Configuration> Configurations { get; set; }
    
    public Configuration? CurrentConfiguration { get; set; }

    public bool Save()
    {
        var results = _configurationRepository.CrudMany(Configurations);
        return results.All(x => x.Success);
    }
    
    public void Init()
    {
        Configurations = _configurationRepository.GetAll().ToList();
        CurrentConfiguration = Configurations.Find(x => x.IsActive);

        if (CurrentConfiguration is null)
        {
            var config = Configuration.Create();
            config.IsActive = true;
            config.OperationType = Operation.Created;
            Configurations.Add(config);
            CurrentConfiguration = config;
        }
        Configurations.ForEach(x => x.OperationType = Operation.Updated);
        
        ConfigurationsChanged?.Invoke(null, EventArgs.Empty);
    }
}