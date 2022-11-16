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
                new Uri("https://api.conservices.de/external_gamelist.php?api_key=201730d4278e576b25515bd90c6072d3&con_id=14")
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