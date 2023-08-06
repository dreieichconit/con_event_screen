using System.Diagnostics;
using con_event_api.Classes;
using Newtonsoft.Json;
using Serilog;

namespace con_event_api;

public static class ConservicesRepository
{
    private static readonly HttpClient _client = new HttpClient();

    public static async Task<IEnumerable<Game>> GetGamesAsync()
    {
        
        Log.Information("Fetching Games from Conservices");
        
        var games = new List<Game>();

        var response =
            await _client.GetAsync(
                new Uri("https://api.conservices.de/external_gamelist.php?api_key=Kupd7y1lNUoss8utRWdVP1SIna16zpgXJylway9tGCBNC0lG&con_id=22")
                );

        var content = await response.Content.ReadAsStringAsync();

        games = JsonConvert.DeserializeObject<List<Game>>(content);
        
        Log.Debug("Found {count} Games", games.Count);
        
        return games;
    }

    public static IEnumerable<Game> GetGames()
    {
        return Task.Run(async () => await GetGamesAsync()).Result;
    }
}