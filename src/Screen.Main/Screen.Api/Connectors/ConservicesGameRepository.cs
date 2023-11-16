using Newtonsoft.Json;
using Screen.Api.Models;
using Serilog;

namespace Screen.Api.Connectors;

public static class ConservicesGameRepository
{
	private static readonly HttpClient _client = new HttpClient();

	public static async Task<IEnumerable<Game>> GetGamesAsync(string request)
	{
		var games = new List<Game>();

		var response = await _client.GetAsync(new Uri(request));

		var content = await response.Content.ReadAsStringAsync();

		try
		{
			var gd = JsonConvert.DeserializeObject<Dictionary<string, Game>>(content);
			games = gd.Select(x => x.Value).ToList();
		}
		catch
		{
			Log.Debug(content);
		}
		

		Log.Debug("Found {count} Games", games.Count);

		return games;
	}
}