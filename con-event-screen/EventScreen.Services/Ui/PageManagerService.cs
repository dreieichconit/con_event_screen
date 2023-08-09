using EventScreen.Services.Interfaces;

namespace EventScreen.Services.Ui;

public class PageManagerService : IPageManagerService
{
	private int _maxPages;
	
	public PageManagerService(IGlobalTimerService globalTimerService)
	{
		globalTimerService.HalfMinuteElapsed += (_, _) => SwitchPage();

		_maxPages = 1;
	}

	private void SwitchPage()
	{
		if (CurrentPage < _maxPages) CurrentPage++;
		else CurrentPage = 0;
		
		PageChanged?.Invoke(this, EventArgs.Empty);
	}

	public event EventHandler? PageChanged; 
	
	public int CurrentPage { get; set; }
}