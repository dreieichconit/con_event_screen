using Screen.Api.Models;

namespace Screen.Api.Interfaces;

public interface IConservicesGameRepository
{
	public Task<List<Game>> GetAllGames(string eventId);
}