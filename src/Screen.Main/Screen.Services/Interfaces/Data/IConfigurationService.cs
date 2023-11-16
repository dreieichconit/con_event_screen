using Screen.Data.Models;
using Screen.Services.Interfaces.Core;

namespace Screen.Services.Interfaces.Data;

public interface IConfigurationService : IDataService<Configuration>
{
	public Configuration GetActive();
}