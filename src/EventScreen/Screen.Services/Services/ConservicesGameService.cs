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
		Games = await gameRepository.GetAllGames("c0689650-3dbe-43c5-b9d0-7795b597774f");
		GamesNotStarted = Games.Where(x => x.Start > DateTime.Now).ToList();
	}
}