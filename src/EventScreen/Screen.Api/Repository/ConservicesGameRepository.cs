using Flurl;
using Screen.Api.Interfaces;
using Screen.Api.Models;
using Flurl.Http;
using Flurl.Http.Configuration;
using Screen.Api.Json;

namespace Screen.Api.Repository;

public class ConservicesGameRepository : IConservicesGameRepository
{
	public ConservicesGameRepository()
	{
		FlurlHttp
			.ConfigureClientForUrl("https://conservices.de/api/event")
			.WithSettings(
				settings =>
				{
					settings.JsonSerializer = new DefaultJsonSerializer(SerializerOptions.GetConservicesOptions());
				}
			);
	}
	
	public async Task<List<Game>> GetAllGames(string eventId)
	{
		var result = await "https://conservices.de/api/event".AppendPathSegment(eventId).AppendPathSegment("game").GetAsync().ReceiveJson<Dictionary<string, Game>>();
		return result.Select(x => x.Value).ToList();
	}
}