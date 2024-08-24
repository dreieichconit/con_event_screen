using Screen.Api.Models;

namespace Screen.Services.Interfaces;

public interface IConservicesGameService
{
	public List<Game> Games { get; set; }

	public List<Game> GamesNotStarted { get; set; }
	

	public event EventHandler? GamesUpdated;

	public Task LoadGamesAsync();
}