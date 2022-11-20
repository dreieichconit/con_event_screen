using con_event_api;
using con_event_api.Classes;
using con_event_services.Interfaces;
using Serilog;

namespace con_event_services.Classes;

public class ContentController : IContentController
{
	private readonly IStateController _stateController;

	public ContentController(IStateController stateController)
	{
		_stateController = stateController;
		_stateController.ContentChanged += async (e, ee) => await ReloadGames(e);
		_stateController.ContentChanged += async (e, ee) => await ReloadProgram(e);

		Task.Run(async () => await ReloadGames(0));
		Task.Run(async () => await ReloadProgram(0));
	}

	public IEnumerable<Game> Games { get; set; } = new List<Game>();
	public IEnumerable<ProgramItem> ProgramItems { get; set; } = new List<ProgramItem>();
	public ProgramItem? CurrentItem { get; set; }

	private async Task ReloadGames(object? e)
	{
		if (e is int order && order == 0)
		{
			try
			{
				Log.Debug("Triggering Reload of Games List");
				var allGames = await ConservicesRepository.GetGamesAsync();
				Games = allGames.Where(x => x.StartStamp > DateTime.UtcNow).OrderBy(x => x.StartStamp).Take(4);
			}
			catch
			{
				Log.Error("Could not Fetch Games List"); 
			}
		}
	}

	public async Task ReloadProgram(object? e)
	{
		if (e is int order && order == 0)
		{
			Log.Debug("Triggering Reload of Program List");
			try
			{
				var allItems = await HomepageRepository.GetProgramAsync();
				CurrentItem = allItems.LastOrDefault(x => x.StartStamp < DateTime.Now);
				ProgramItems = allItems.Where(x => x.StartStamp > DateTime.Now).OrderBy(x => x.StartStamp).Take(1);
			}
			catch
			{
				Log.Error("Could not Fetch Program List");
			}
		}
	}
}