using System.Text.Json;
using Screen.Api.Helpers;
using Screen.Api.Models;
using Serilog;

namespace Screen.Api.Connectors;

public static class ConservicesGameRepository
{
	private static readonly HttpClient Client = new();

	public static async Task<IEnumerable<Game>> GetGamesAsync(string request)
	{
		var games = new List<Game>();

		var response = await Client.GetAsync(new Uri(request));

		var content = await response.Content.ReadAsStringAsync();

		try
		{
			var gd = JsonSerializer.Deserialize<Dictionary<string,Game>>(content, JsonHelper.CreateConservicesConfiguration());
			games = gd!.Select(x => x.Value).ToList();
		}
		catch (Exception ex)
		{
			Log.Error("Error while deserializing: {Exception}", ex);
		}
		

		Log.Debug("Found {Count} Games", games.Count);

		return games;
	}
}