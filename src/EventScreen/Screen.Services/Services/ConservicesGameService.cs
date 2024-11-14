using Screen.Api.Interfaces;
using Screen.Api.Models;
using Screen.Services.Interfaces;

namespace Screen.Services.Services;

public class ConservicesGameService(IConservicesGameRepository gameRepository) : IConservicesGameService
{
	public List<Game> Games { get; set; } = [];

	public List<Game> GamesNotStarted { get; set; } = [];

	public event EventHandler? GamesUpdated;

	public async Task LoadGamesAsync()
	{
		Games = await gameRepository.GetAllGames("1aa9a5ca-aab3-41ec-8891-e09749992275");
		GamesNotStarted = Games.Where(x => x.Start > DateTime.Now).ToList();
	}
}