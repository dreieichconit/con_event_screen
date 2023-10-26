using Screen.Db.Models;

namespace Screen.Services.Interfaces;

public interface IConfigurationService
{
    public Configuration? CurrentConfiguration { get; set; }

    public event EventHandler? ConfigUpdated;
}