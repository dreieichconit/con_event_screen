using Screen.Data.Models;

namespace Screen.Services.Interfaces.Data;

public interface ICurrentConfigurationService
{
	public event EventHandler? ConfigurationUpdated;
	
	public Configuration? CurrentConfiguration { get; set; }

	public void Reload();
	
}