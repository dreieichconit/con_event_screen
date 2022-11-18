using con_event_api;
using con_event_api.Classes;
using Serilog;

namespace con_event_services.Interfaces;

public interface IContentController
{
	public IEnumerable<Game> Games { get; set; }

	public IEnumerable<ProgramItem> ProgramItems { get; set; }

	public ProgramItem? CurrentItem { get; set; }
}