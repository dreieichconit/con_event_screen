using con_event_api.Classes;
using Newtonsoft.Json;

namespace con_event_api;

public class HomepageRepository
{
	private static readonly HttpClient _client = new HttpClient();

	public static async Task<IEnumerable<ProgramItem>> GetProgramAsync()
	{
		var program = new List<ProgramItem>();
		
		var response =
			await _client.GetAsync(
				new Uri("https://editor.eventscreen.conservices.de/api/schedule")
			);
		
		program = JsonConvert.DeserializeObject<List<ProgramItem>>(await response.Content.ReadAsStringAsync());

		return program;
	}

}