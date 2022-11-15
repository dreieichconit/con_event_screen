using System.Diagnostics;
using con_event_api.Classes;

namespace con_event_api;

public static class ConservicesRepository
{
    private static readonly HttpClient _client = new HttpClient();

    public static async Task<IEnumerable<Game>> GetGames()
    {
        var games = new List<Game>();

        var response =
            await _client.GetAsync(
                new Uri("https://api.conservices.de/external_gamelist.php?api_key=201730d4278e576b25515bd90c6072d3&con_id=14")
                );
        
        Trace.WriteLine(await response.Content.ReadAsStringAsync());
        
        return games;
    }
}