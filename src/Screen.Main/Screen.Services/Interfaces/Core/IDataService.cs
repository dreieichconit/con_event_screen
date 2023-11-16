using EfExtensions.Core.Interfaces.Result;

namespace Screen.Services.Interfaces.Core;

public interface IDataService<T>
{
	public static event EventHandler? ItemsUpdated; 
	
	public List<T> Items { get; set; }

	public IEnumerable<IDbResult<T>> Save();

	public void Load();
}