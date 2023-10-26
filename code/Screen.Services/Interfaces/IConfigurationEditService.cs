using Screen.Db.Models;

namespace Screen.Services.Interfaces;

public interface IConfigurationEditService
{
    public List<Configuration> Configurations { get; set; }
    
    public Configuration? CurrentConfiguration { get; set; }
    
    public static event EventHandler? ConfigurationsChanged;

    public bool Save();

    public void Init();
}